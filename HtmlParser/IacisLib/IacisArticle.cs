using BaseLib;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace IacisLib
{
    [Serializable]
    public class IacisArticle : ArticleBase
    {
        public IacisArticle() : base() { }
        public IacisArticle(string title, string text, string author, string date, string imageCaption, List<string> images) : base()
        {
            Link = "unknown";
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = DateTime.Parse(date);
            ImageCaption = imageCaption;
            Images = images;
        }
        public IacisArticle(string link, string title, string text, string author, string date, string imageCaption, List<string> images) : base()
        {
            Link = link;
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = DateTime.Parse(date);
            ImageCaption = imageCaption;
            Images = images;
        }
        public IacisArticle(MongoDatabase db, BsonDocument doc)
        {
            _mongoId = (ObjectId)doc.GetValue("_id");
            Title = doc.GetValue("title").ToString();
            Text = doc.GetValue("text").ToString();
            Link = doc.GetValue("link").ToString();
            Author = doc.GetValue("author").ToString();
            DateOfPublication = doc.GetValue("dateOfPublication").ToLocalTime();
            ImageCaption = doc.GetValue("imageCaption").ToString();
            Images = new List<string>();

            foreach (var imageId in doc.GetValue("images").AsBsonArray)
            {
                int i = 0;
                MongoGridFSFileInfo file = db.GridFS.FindOne(Query.EQ("_id", imageId));
                using (MongoGridFSStream stream = file.OpenRead())
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    using (var newFs = new FileStream(i + ".jpg", FileMode.Create))
                    {
                        newFs.Write(bytes, 0, bytes.Length);
                        Images.Add(Path.GetFullPath(i + ".jpg"));
                    }
                }
            }
        }

        public string Author { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string ImageCaption { get; set; }
        public List<string> Images { get; set; }

        public override BsonDocument toBson(MongoDatabase db)
        {
            var newDoc = new BsonDocument() {
                { "_id", _mongoId },
                { "title", Title },
                { "text", Text },
                { "link", Link },
                { "author", Author },
                { "dateOfPublication", DateOfPublication },
                { "imageCaption", ImageCaption },
            };
            if (Images.Count != 0)
            {
                newDoc.Add("images", uploadImagesToDb(db));
            }
            else
                newDoc.Add("images", null);
            return newDoc;
        }

        delegate Stream streamDelegate(string s);
        public BsonArray uploadImagesToDb(MongoDatabase db)
        {
            BsonArray dbImages = new BsonArray();
            if (Images.Count != 0)
            {
                streamDelegate openRead;
                bool fromWeb = Images.First().StartsWith("http");

                if (Images.First().StartsWith("http"))
                    openRead = new WebClient().OpenRead;
                else
                    openRead = File.OpenRead;

                foreach (var image in Images)
                    using (var fs = openRead(image))
                    {
                        MongoGridFSFileInfo gridFsInfo = db.GridFS.Upload(fs, image.Substring(image.LastIndexOf('/')));
                        dbImages.Add(gridFsInfo.Id);
                    }
            }
            
            return dbImages;
        }
    }
}
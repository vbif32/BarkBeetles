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

namespace NewsParsersLib
{
    public class MongoDbManager
    {

        public MongoDatabase CurDb { get; set; }

        public MongoDbManager(MongoDatabase mongoDB)
        {
            CurDb = mongoDB;
        }

        public MongoCursor DateSearch(string date)
        {
            DateTime dt = DateTime.Parse(date);
            var query = Query.EQ("dateOfPublication", dt);
            var curCollection = CurDb.GetCollection("articles");
            return curCollection.Find(query);
        }
        public MongoCursor DateSearch(DateTime dt)
        {
            var query = Query.EQ("dateOfPublication", dt);
            var curCollection = CurDb.GetCollection("articles");
            return curCollection.Find(query);
        }
        public MongoCursor Search(string field, string value)
        {
            var query = Query.Matches(field, value);
            var curCollection = CurDb.GetCollection("articles");
            var cursor = curCollection.Find(query);
            return curCollection.Find(query);
        }
        public bool DropCollection(string collectionName)
        {
            return CurDb.DropCollection(collectionName).Ok;
        }
        public void InsertToDatabase(List<ArticleBase> ArticleList )
        {
            var articleCollection = CurDb.GetCollection("articles");
            foreach (ArticleBase article in ArticleList)
            {
                articleCollection.Insert(article.getFields());
                var BsonDoc = new BsonDocument();
                var articleFields = article.getFields();
                foreach (var key in articleFields.Keys)
                {
                    if(articleFields[key].GetType() == List<string>)
                }
            }
        }

        delegate Stream streamDelegate(string s);
        public BsonArray uploadImagesToDatabase(List<string> images)
        {
            BsonArray dbImages = new BsonArray();
            if (images.Count != 0)
            {
                streamDelegate openRead;
                bool fromWeb = images.First().StartsWith("http");

                if (fromWeb)
                    openRead = new WebClient().OpenRead;
                else
                    openRead = File.OpenRead;

                foreach (var image in images)
                    using (var fs = openRead(image))
                    {
                        MongoGridFSFileInfo gridFsInfo = CurDb.GridFS.Upload(fs, image.Substring(image.LastIndexOf('/')));
                        dbImages.Add(gridFsInfo.Id);
                    }
            }
            return dbImages;
        }
    }
}

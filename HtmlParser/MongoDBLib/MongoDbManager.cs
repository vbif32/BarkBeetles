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

        public int InsertToCollection(MongoCollection articleCollection, List<ArticleBase> articleList )
        {
            int successLoad = 0;
            foreach (ArticleBase article in articleList)
            {
                var articleFields = article.getFields();
                if (Search("link", articleFields["link"].ToString()).Count() == 0)
                {
                    foreach (var key in articleFields.Keys)
                    {
                        var value = articleFields[key];
                        if (value.GetType() == Type.GetType("List<string>"))
                        {
                            value = uploadImagesToDatabase((List<string>)value);
                        }
                    }
                    var bsonDoc = new BsonDocument(articleFields);
                    articleCollection.Insert(bsonDoc);
                    successLoad++;
                }
            }
            return successLoad;
        }
        public int InsertToCollection(string collectionName, List<ArticleBase> articleList)
        {
            int successLoad = 0;
            foreach (ArticleBase article in articleList)
            {
                var articleFields = article.getFields();
                if (Search("link", articleFields["link"].ToString()).Count() == 0)
                {
                    foreach (var key in articleFields.Keys)
                    {
                        var value = articleFields[key];
                        if (value.GetType() == Type.GetType("List<string>"))
                        {
                            value = uploadImagesToDatabase((List<string>)value);
                        }
                    }
                    var bsonDoc = new BsonDocument(articleFields);
                    CurDb.GetCollection(collectionName).Insert(bsonDoc);
                    successLoad++;
                }
            }
            return successLoad;
        }

        public void DeleteFromCollection(MongoCollection articleCollection, IMongoQuery query)
        {
            articleCollection.Remove(query);
        }
        public void DeleteFromCollection(string collectionName, IMongoQuery query)
        {
            CurDb.GetCollection(collectionName).Remove(query);
        }

        public MongoCursor DateSearch(string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                var query = Query.EQ("dateOfPublication", dt);
                var curCollection = CurDb.GetCollection("articles");
                return curCollection.Find(query);
            }
            return null;
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

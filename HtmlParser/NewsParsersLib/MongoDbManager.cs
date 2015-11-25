using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

namespace NewsParsersLib
{
    public class MongoDbManager
    {

        public MongoDatabase curDb { get; set; }

        public MongoDbManager(MongoDatabase mongoDB)
        {
            curDb = mongoDB;
        }

        public MongoCursor DateSearch(string date)
        {
            DateTime dt = DateTime.Parse(date);
            var query = Query.EQ("dateOfPublication", dt);
            var curCollection = curDb.GetCollection("articles");
            return curCollection.Find(query);
        }
        public MongoCursor Search(string field,string value)
        {
            var query = Query.Matches(field, value);
            var curCollection = curDb.GetCollection("articles");
            var cursor = curCollection.Find(query);
            return curCollection.Find(query);
        }
        public bool DropCollection(string collectionName)
        {
            return curDb.DropCollection(collectionName).Ok;
        }

    }
}

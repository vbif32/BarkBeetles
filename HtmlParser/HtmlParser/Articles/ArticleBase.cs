using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace HtmlParser
{
    [Serializable]
    public abstract class ArticleBase
    {
        [NonSerialized] [BsonId]
        protected ObjectId _mongoId;

        protected ArticleBase()
        {
            _mongoId = ObjectId.GenerateNewId();
        }
        public ArticleBase(BsonDocument doc)
        {

        }
        public string Title { get; set; }

        public string Text { get; set; }
        public string Link { get; set; }
        public abstract BsonDocument toBson();
    }
}

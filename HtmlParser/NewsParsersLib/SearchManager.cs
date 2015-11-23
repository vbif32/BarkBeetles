
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace NewsParsersLib
{
    public class SearchManager
    {

        public MongoDatabase curDb { get; set; }

        public SearchManager(MongoDatabase mongoDB)
        {
            curDb = mongoDB;
        }

        public long TitleSearch(string title)
        {
            var query = Query.Matches("title", title);
            var curCollection = curDb.GetCollection("articles");
            var cursor = curCollection.Find(query);
            return cursor.Count();
        }
        public long TextSearch(string text)
        {
            var query = Query.Matches("text", text);
            var curCollection = curDb.GetCollection("articles");
            var cursor = curCollection.Find(query);
            return cursor.Count();
        }
        public void DateSearch(string date)
        {

        }

    }
}

using MongoDB.Driver;
using System;
using System.Net;
using System.Text;
using NewsParsersLib;

/**
Программу написал Федин Михаил из группы ИКБО-02-14.
Парсер написан для сайта http://www.iacis.ru/. В процессе написания также 
была поставлена цель создать максимально удобную для масштабирования архитектуру
и следовать соглашению по оформлению кода RSDN. Надеюсь получилось.
*/

namespace HtmlParser
{
    static class Program
    {
        public static ParserManager parserManager;
        public static SearchManager searchManager;
        public static WebClient wClient;
        public static Encoding encode = Encoding.GetEncoding("utf-8");
        public static MongoClient mongoClient;
        public static MongoDatabase mongoDb;
        private static string mongoConnectionString = "mongodb://localhost";

        [STAThread]
        static void Main(string[] args)
        {
            wClient = new WebClient();
            wClient.Proxy = null;
            wClient.Encoding = encode;
            mongoClient = new MongoClient(mongoConnectionString);
            mongoDb = mongoClient.GetServer().GetDatabase("iacis");
            parserManager = new ParserManager(mongoDb);
            searchManager = new SearchManager(mongoDb);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new NewsParserForm());
        }
    }

}

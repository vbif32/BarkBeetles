using HtmlParser.Parsers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

/**
Программу написал Федин Михаил из группы ИКБО-02-14.
Парсер написан для сайта http://www.iacis.ru/. В процессе написания также 
была поставлена цель создать максимально удобную для масштабирования архитектуру
и следовать соглашению по оформлению кода RSDN. Надеюсь получилось.

В программе есть баг. 
Суть бага: При создании объекта из html файла, лежащего на жестком диске, адреса картинок будут нерабочие. 
Других случаев неожиданного поведения не замечено. 
*/

namespace HtmlParser
{
    static class Program
    {
        public static List<ArticleBase> articleList;
        public static ParserManager parserManager;
        public static WebClient wClient;
        public static Encoding encode = Encoding.GetEncoding("utf-8");
        public static MongoClient mongoClient;
        public static MongoDatabase mongoDb;

        [STAThread]
        static void Main(string[] args)
        {
            wClient = new WebClient();
            wClient.Proxy = null;
            wClient.Encoding = encode;
            parserManager = new ParserManager();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new NewsParserForm());
        }
    }

}

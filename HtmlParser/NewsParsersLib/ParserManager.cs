﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MongoDB.Driver;
using BaseLib;

namespace NewsParsersLib
{
    public class ParserManager
    {
        public List<ArticleBase> ArticleList { get; private set; }
        public MongoDatabase MongoDb { get; set; }

        private ParserBase LastUsedParser;

        public ParserManager(MongoDatabase db)
        {
            MongoDb = db;
        }

        public string TryParse(string link)
        {
            try
            {
                if (Helper.IsLinkOk(link))
                {
                    string source = link.StartsWith("http") ? link : Helper.GetFileSourceLink(link);
                    ArticleList = ChooseParser(Helper.GetDomen(source)).ParseLink(link);
                    if (ArticleList != null && ArticleList.Count > 0)
                        return "Статьи извлечены в количестве " + ArticleList.Count;
                }
                else
                {
                    return "Неизвестный сайт";
                }
            }
            catch (System.Exception)
            {
                return "Ошибка при извлечении статьи";
            }
            return "Не удалось извлечь статью";
        }
        public ParserBase ChooseParser(string domen)
        {
            if (LastUsedParser != null && domen == LastUsedParser.SiteDomen)
                return LastUsedParser;
            Helper.knownSites.TryGetValue(domen,out LastUsedParser);
            return LastUsedParser;
        }

        public void ToXml(Stream а)
        {
            foreach (ArticleBase article in ArticleList)
            {
                XmlSerializer serializer = new XmlSerializer(article.GetType());
                serializer.Serialize(а, article);
            }
        }

    }
}

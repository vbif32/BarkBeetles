using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

using System.Linq;

namespace HtmlParser.Parsers
{
    public class ParserManager
    {
        private const string pattern = @"<!-- saved from url=.*-->$";
        private ParserBase LastUsedParser;
        private Dictionary<string, ParserBase> _knownSites = new Dictionary<string, ParserBase>
        {
            { IacisParser.SiteDomen, new IacisParser() }
        };

        public string TryParse(string link)
        {
            try
            {
                if (IsLinkOk(link))
                {
                    string source = link.StartsWith("http") ? link : GetFileSourceLink(link);
                    Program.articleList = ChooseParser(GetDomen(source)).ParseLink(link);
                    if (Program.articleList != null && Program.articleList.Count > 0)
                        return "Статьи извлечены в количестве " + Program.articleList.Count;
                }
                else
                {
                    return "Неизвестный сайт";
                }
            }
            catch (System.Exception ex)
            {
                return "Ошибка при извлечении статьи";
            }
            return "Не удалось извлечь статью";
        }
        public ParserBase ChooseParser(string domen)
        {
            if (LastUsedParser != null && domen == LastUsedParser.SiteDomen)
                return LastUsedParser;
            _knownSites.TryGetValue(domen,out LastUsedParser);
            return LastUsedParser;
        }

        private bool IsLinkOk(string link)
        {
            if (Regex.IsMatch(link, @"^http\w?://"))
                return IsSiteKnown(link);
            else if (Regex.IsMatch(link, @"^\w:\\"))
                return IsFileSourceKnown(link);
            return false;
        }
        public bool IsSiteKnown(string link)
        {
            link = GetDomen(link);
            if (_knownSites.ContainsKey(link))
                return true;
            return false;
        }
        public bool IsFileSourceKnown(string link)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(link);
            if (Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, pattern))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = GetDomen(link);
                if (_knownSites.ContainsKey(link))
                    return true;
            }
            return false;
        }

        public static string GetDomen(string link)
        {
            link = link.Remove(0, link.IndexOf('/') + 2);
            link = link.Remove(link.IndexOf('/'));
            if (link.StartsWith("www."))
                link = link.Remove(0, 4);
            return link;
        }
        public static string GetFileSourceLink(string link)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(link);
            if (Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, pattern))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = link.Remove(0, link.IndexOf('/') -5);
                link = link.Remove(link.LastIndexOf('/')+1);
                return link;
            }
            return null;
        }

        public static void ToXml(Stream а)
        {
            foreach (ArticleBase article in Program.articleList)
            {
                XmlSerializer serializer = new XmlSerializer(article.GetType());
                serializer.Serialize(а, article);
            }
        }
        public static void ToDatabase()
        {
            var articleCollection = Program.mongoDb.GetCollection("articles");
            foreach (ArticleBase article in Program.articleList)
            {
                articleCollection.Insert(article.toBson());
            }
            var test = new IacisArticle( articleCollection.FindAll().Last());
        }

    }
}

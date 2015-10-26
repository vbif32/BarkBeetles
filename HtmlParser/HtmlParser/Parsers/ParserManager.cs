using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace HtmlParser.Parsers
{
    public static class ParserManager
    {
        private const string pattern = @"^!-- saved from url.*--!$";

        public static List<string> GetArticlesLinks(HtmlDocument doc)
        {
            return IacisParser.GetArticlesLinks(doc);
        }

        public static IacisArticle ParseHtml(HtmlDocument doc)
        {
            return IacisParser.ParseHtml(doc);
        }

        public static bool ChooseOperation(string link)
        {
            if (link.Contains(IacisParser.SiteDomen))
                    return true;
            return false;
        }

        public static bool isLinkOk(string link)
        {
            return true;
        }

        public static string GetHtmlString(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response;
            request.Proxy = null;
            response = request.GetResponse();
            using (StreamReader sReader = new StreamReader(response.GetResponseStream(), Program.encode))
            {
                return sReader.ReadToEnd();
            }
        }

        public static void toXml()
        {
            
        }
    }
}

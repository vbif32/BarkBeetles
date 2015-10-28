using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlParser.Parsers
{
    public class ParserManager
    {
        private const string pattern = @"<!-- saved from url=.*-->$";
        private Type LastUsedParser;
        private static HashSet<string> _knownSitses = new HashSet<string>
        {
            { IacisParser._siteDomen }
        };

        public static List<string> GetArticlesLinks(HtmlDocument doc)
        {
            return null;
        }

        public static IacisArticle ParseHtml(HtmlDocument doc)
        {
            return null;
        }

        public static bool JustDoIt(string link)
        {
            return false;
        }

        public static bool IsSiteKnown(string link)
        {
            link.Remove(0, link.IndexOf('/') + 2);
            link.Remove(link.IndexOf('/'));
            if (link.StartsWith("www."))
                link.Remove(0, 4);

            if (_knownSitses.Contains(link))
                    return true;
            return false;
        }

        public static bool IsFileSourceKnown(string link)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(link);
            if(Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, pattern))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = link.Remove(0, link.IndexOf('/') + 2);
                link = link.Remove(link.IndexOf('/'));
                if (link.StartsWith("www."))
                    link = link.Remove(0, 4);

                if (_knownSitses.Contains(link))
                    return true;
            }
            return false;
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

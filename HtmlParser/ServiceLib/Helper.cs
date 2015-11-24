using BaseLib;
using HtmlAgilityPack;
using IacisLib;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ServiceLib
{
    internal static class Helper
    {

        private const string _pattern = @"<!-- saved from url=.*-->$";
        public static Dictionary<string, ParserBase> knownSites = new Dictionary<string, ParserBase>
        {
            { IacisParser.SiteDomen, new IacisParser() }
        };

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
            if (Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, _pattern))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = link.Remove(0, link.IndexOf('/') - 5);
                link = link.Remove(link.LastIndexOf('/') + 1);
                return link;
            }
            return null;
        }
        public static bool IsFileSourceKnown(string link)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(link);
            if (Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, _pattern))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = GetDomen(link);
                if (knownSites.ContainsKey(link))
                    return true;
            }
            return false;
        }
        public static bool IsLinkOk(string link)
        {
            if (Regex.IsMatch(link, @"^http\w?://"))
                return IsSiteKnown(link);
            else if (Regex.IsMatch(link, @"^\w:\\"))
                return IsFileSourceKnown(link);
            return false;
        }
        public static bool IsSiteKnown(string link)
        {
            link = GetDomen(link);
            if (knownSites.ContainsKey(link))
                return true;
            return false;
        }

    }
}

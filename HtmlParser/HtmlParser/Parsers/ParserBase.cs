using HtmlAgilityPack;
using System.Collections.Generic;

namespace HtmlParser.Parsers
{
    public abstract class ParserBase
    {
        private string _siteDomen;
        private string _newsMainPage;

        public abstract List<string> GetArticlesLinks(HtmlDocument doc);

        public abstract IacisArticle ParseHtml(HtmlDocument doc);


        public abstract void SerializeToXml(List<ArticleBase> jobList);

        public string SiteDomen
        {
            get { return _siteDomen; }
        }
    }
}

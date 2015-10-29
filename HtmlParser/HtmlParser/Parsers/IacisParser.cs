using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using System.Xml.Serialization;
using HtmlParser.Parsers;

namespace HtmlParser
{
    public class IacisParser : ParserBase
    {
        new public const string SiteDomen = "iacis.ru";
        new protected const string _newsMainPage = "/pressroom/news";

        protected override List<string> GetArticlesLinks(HtmlDocument doc)
        {
            HtmlNode html = doc.DocumentNode.Element("html");
            HtmlNode body = html.Element("body");
            HtmlNode wrapper = body.ChildNodes[3];
            HtmlNode main = wrapper.ChildNodes[15];
            HtmlNode mainHolder = main.ChildNodes[1];
            HtmlNode container = mainHolder.ChildNodes[1];
            HtmlNode contentNewsPage = container.ChildNodes[3];

            var divNodes = contentNewsPage.ChildNodes.Where(
                x => (x.Name == "div" && (x.Attributes[0].Value) == "news-box"));

            // 3 = количество статей в box
            List<string> articleLinkList = new List<string>(3 * (divNodes.Count()-1) + divNodes.Last().Element("ul").Elements("li").Count());

            foreach (var box in divNodes)
            {
                HtmlNode ul = box.Element("ul");
                var liNodes = ul.ChildNodes.Where(x => x.Name == "li");
                foreach (HtmlNode item in liNodes)
                {
                    HtmlNode a = item.Element("a");
                    articleLinkList.Add("http://" + SiteDomen + a.Attributes[0].Value);
                }
            }
            return articleLinkList;
        }

        protected override ArticleBase ParseArticle(HtmlDocument doc)
        {
            IacisArticle article;
            string title = "";
            string text = "";
            string author = "";
            string date = "";
            string imageCaption = "";
            List<string> imagesList = new List<string>();

            HtmlNode html = doc.DocumentNode.Element("html");
            HtmlNode body = html.Element("body");
            HtmlNode wrapper = body.ChildNodes[3];
            HtmlNode main = wrapper.ChildNodes[15];
            HtmlNode mainHolder = main.Element("div");
            HtmlNode container = mainHolder.Element("div");
            HtmlNode contentNewsPage = container.Element("div");
            author = contentNewsPage.Element("h1").InnerText;
            HtmlNode activityInside = contentNewsPage.ChildNodes[7];
            HtmlNode galleryHolder = activityInside.Element("div");
            date = activityInside.Element("em").InnerText;
            title = activityInside.Element("strong").InnerText;
            
            var pCollection = activityInside.Elements("p");
            foreach (HtmlNode p in pCollection)
            {
                text += p.InnerText;
            }
            if (text.StartsWith("\r"))
                text = text.Remove(0, 1);
            if (text.StartsWith("\n"))
                text = text.Remove(0, 1);

            if (galleryHolder != null)
            {
	            var ImageWithCaption = galleryHolder.ChildNodes.Where(x => x.Name != "#text");
	            if (galleryHolder.Id != "slides")
	            {
	                imageCaption = ImageWithCaption.Last().Element("div").Element("em").InnerText;
	                imagesList.Add("http://" + SiteDomen + ImageWithCaption.First().Element("li").Element("img").Attributes[0].Value);
	            }
	            else
	            {
	                imageCaption = ImageWithCaption.First().Element("li").Element("a").Element("img").Attributes[1].Value;
	                var images = ImageWithCaption.First().ChildNodes.Where(x => x.Name == "li");
	                foreach (HtmlNode image in images)
	                {
	                    imagesList.Add("http://" + SiteDomen + image.Element("a").Element("img").Attributes[0].Value);
	                }
	            }
            }
            article = new IacisArticle(title, text, author, date, imageCaption, imagesList);
            return article;
        }

        public override List<ArticleBase> ParseLink(string link)
        {
            HtmlDocument doc = new HtmlDocument();
            List<ArticleBase> articleList = new List<ArticleBase>();
            string articleSource;

            List<string> newArticlesLinks;
            IacisArticle newArticle;

            if (link.StartsWith("http"))
            {
                doc.LoadHtml(Program.wClient.DownloadString(link));
                articleSource = link;
            }
            else
            {
                doc.Load(link, Program.encode);
                articleSource = ParserManager.GetFileSourceLink(link);
            }

            if (articleSource.Contains(_newsMainPage))
            {
	            if (articleSource.Split('/').Length > 6)
	            {
	                newArticle = (IacisArticle)ParseArticle(doc);
	                newArticle.Link = articleSource;
	                articleList.Add(newArticle);
	            }
	            else
	            {
	                newArticlesLinks = GetArticlesLinks(doc);
	                foreach(string newLink in newArticlesLinks)
	                {
	                    doc.LoadHtml(Program.wClient.DownloadString(newLink));
	                    newArticle = (IacisArticle)ParseArticle(doc);
	                    newArticle.Link = newLink;
	                    articleList.Add(newArticle);
	                }
	            }
            }


            return articleList;
        }
    }
}

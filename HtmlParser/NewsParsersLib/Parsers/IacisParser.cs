﻿using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using NewsParsersLib.Articles;

namespace NewsParsersLib.Parsers
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
                string imagePath;
                if (galleryHolder.Id != "slides")
	            {
	                imageCaption = ImageWithCaption.Last().Element("div").Element("em").InnerText;
                    string src = ImageWithCaption.First().Element("li").Element("img").GetAttributeValue("src", "notFound");
                    if (src.StartsWith("."))
                        imagePath = Path.GetFullPath(_currentArticleSource + src.Substring(1));
                    else
                        imagePath = "http://" + SiteDomen + src;
                    imagesList.Add(imagePath);
                }
	            else
	            {
	                imageCaption = ImageWithCaption.First().Element("li").Element("a").Element("img").Attributes[1].Value;
	                var images = ImageWithCaption.First().ChildNodes.Where(x => x.Name == "li");
	                foreach (HtmlNode image in images)
	                {
                        string src = image.Element("li").Element("img").GetAttributeValue("src", "notFound");
                        if (src.StartsWith("."))
                            imagePath = Path.GetFullPath(_currentArticleSource + src.Substring(1));
                        else
                            imagePath = "http://" + SiteDomen + src;
                        imagesList.Add(imagePath);
	                }
	            }
            }
            article = new IacisArticle(title, text, author, date, imageCaption, imagesList);
            return article;
        }
        public override List<ArticleBase> ParseLink(string source)
        {
            HtmlDocument doc = new HtmlDocument();
            List<ArticleBase> articleList = new List<ArticleBase>();
            string link;
            _currentArticleSource = source.Replace('\\', '/');

            List<string> newArticlesLinks;
            IacisArticle newArticle;

            if (source.StartsWith("http"))
            {
                doc.LoadHtml(ParserManager.WClient.DownloadString(source));
                link = source;
            }
            else
            {
                doc.Load(source, ParserManager.Encode);
                link = ParserManager.GetFileSourceLink(source);
            }

            if (link.Contains(_newsMainPage))
            {
	            if (link.Split('/').Length > 6)
	            {
	                newArticle = (IacisArticle)ParseArticle(doc);
	                newArticle.Link = link;
	                articleList.Add(newArticle);
	            }
	            else
	            {
	                newArticlesLinks = GetArticlesLinks(doc);
	                foreach(string newLink in newArticlesLinks)
	                {
	                    doc.LoadHtml(ParserManager.WClient.DownloadString(newLink));
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
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using System.Xml.Serialization;

namespace HtmlParser
{
    public static class IacisParser
    {
        private const string _siteDomen = "http://www.iacis.ru";
        private const string _newsMainPage = "/pressroom/news";

        public static List<string> GetArticlesLinks(HtmlDocument doc)
        {
            HtmlNode html            = doc.DocumentNode.Element("html");
            HtmlNode body            = html.Element("body");
            HtmlNode wrapper         = body.ChildNodes[3];
            HtmlNode main            = wrapper.ChildNodes[15];
            HtmlNode mainHolder      = main.ChildNodes[1];
            HtmlNode container       = mainHolder.ChildNodes[1];
            HtmlNode contentNewsPage = container.ChildNodes[3];

            var divNodes = contentNewsPage.ChildNodes.Where(
                x => (x.Name == "div" && (x.Attributes[0].Value) == "news-box"));

            // 3 = количество статей в box
            List<string> articleLinkList = new List<string>(3 * divNodes.Count());

            foreach (var box in divNodes)
            {
                HtmlNode ul = box.ChildNodes[1];
                var liNodes = ul.ChildNodes.Where(x => x.Name == "li");
                foreach (HtmlNode item in liNodes)
                {
                    HtmlNode a = item.ChildNodes[3];
                    articleLinkList.Add(a.Attributes[0].Value);
                }
            }
            return articleLinkList;
        }

        public static IacisArticle ParseHtml(HtmlDocument doc)
        {
            IacisArticle article;
            string title;
            string text;
            string author;
            string date;
            string imageCaption;
            List<string> imagesList = new List<string>();

            HtmlNode html            = doc.DocumentNode.Element("html");
            HtmlNode body            = html.Element("body");
            HtmlNode wrapper         = body.ChildNodes[3];
            HtmlNode main            = wrapper.ChildNodes[15];
            HtmlNode mainHolder      = main.ChildNodes[1];
            HtmlNode container       = mainHolder.ChildNodes[1];
            HtmlNode contentNewsPage = container.ChildNodes[3];
            author                   = contentNewsPage.ChildNodes[3].InnerText;
            HtmlNode activityInside  = contentNewsPage.ChildNodes[7];
            HtmlNode galleryHolder   = activityInside.Element("div");
            date                     = activityInside.ChildNodes[1].InnerText;
            title                    = activityInside.ChildNodes[3].InnerText;
            text                     = activityInside.ChildNodes[7].InnerText;

            var ImageWithCaption = galleryHolder.ChildNodes.Where(x => x.Name != "#text");
            if(galleryHolder.Id != "slides")
            {
                imageCaption = ImageWithCaption.Last().Element("div").Element("em").InnerText;
                imagesList.Add(_siteDomen + ImageWithCaption.First().Element("li").Element("img").Attributes[0].Value);
            }
            else
            {
                imageCaption = ImageWithCaption.First().Element("li").Element("a").Element("img").Attributes[1].Value;
                var images = ImageWithCaption.First().ChildNodes.Where(x => x.Name != "li");
                foreach(HtmlNode image in images)
                {
                    imagesList.Add(_siteDomen + image.Element("a").Element("img").Attributes[0].ToString());
                }
            }
            article = new IacisArticle(title, text, author, date, imageCaption, imagesList);
            return article;
        }

        public static void SerializeToXml(List<ArticleBase> jobList)
        {
            using (TextWriter output = new StreamWriter("report.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<IacisArticle>));
                serializer.Serialize(output, jobList);
            }
        }

        public static string SiteDomen
        {
            get { return _siteDomen; }
        }

    }
}

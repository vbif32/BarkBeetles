using BaseLib;
using System;
using System.Collections.Generic;

namespace IacisLib
{
    /// <summary>
    /// Класс описывающий статью на новостном сайте iacis.ru
    /// </summary>
    [Serializable]
    public class IacisArticle : ArticleBase
    {
        public IacisArticle() : base() { }
        public IacisArticle(string title, string text, string author, string date, string imageCaption, List<string> images) : base()
        {
            Link = "unknown";
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = DateTime.Parse(date);
            ImageCaption = imageCaption;
            Images = images;
        }
        public IacisArticle(string link, string title, string text, string author, string date, string imageCaption, List<string> images) : base()
        {
            Link = link;
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = DateTime.Parse(date);
            ImageCaption = imageCaption;
            Images = images;
        }

        public string Author { get; set; }
        public DateTime DateOfPublication { get; set; }
        /// <summary>
        /// Подпись под картинкой статьи, всегда одна
        /// </summary>
        public string ImageCaption { get; set; }
        /// <summary>
        /// Картинки в статье, может быть много, 
        /// хранятся в виде списка путей к картинкам
        /// в случае парса сайта - пути к картинкам в интернете
        /// в случае парса файла - пути к картинкам на диске
        /// </summary>
        public List<string> Images { get; set; }
        /// <summary>
        /// Метод для создания записи в базе данных.
        /// </summary>
        /// <returns> 
        /// Название поля с маленькой буквы - значение поля
        /// </returns>
        public override IDictionary<string, object> getFields()
        {
            var newDoc = new Dictionary<string, object>() {
                //{ "_id", _mongoId },
                { "title", Title },
                { "text", Text },
                { "link", Link },
                { "author", Author },
                { "dateOfPublication", DateOfPublication },
                { "imageCaption", ImageCaption },
                { "images", Images},
            };
            return newDoc;
        }
    }
}
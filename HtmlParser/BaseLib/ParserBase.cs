using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BaseLib
{
    /// <summary>
    /// Базовый класс для парсера, требует расширение под конкретный сайт
    /// Возможно динамическое подключение как плагина
    /// </summary>
    public abstract class ParserBase
    {
        /// <summary>
        /// Служит для хранения домена сайта, необходимо перекрывать в каждом наследовании
        /// </summary>
        public string SiteDomen;

        /// <summary>
        /// Служит для хранения пути к странице сайта на которой хранятся новости,
        /// используется для отсечения неподходящих страниц
        /// </summary>
        protected string _newsMainPage;
        
        /// <summary>
        /// Хранит источник текущей статьи
        /// </summary>
        protected string _currentArticleSource { get; set; }

        /// <summary>
        /// Преобразует статью по ссылке в список объектов
        /// </summary>
        /// <returns> список объектов статьи</returns>
        public abstract List<ArticleBase> ParseLink(string link);

        /// <summary>
        /// Метод извлекающий ссылки и страницы, вызывается если
        /// страница не содержит статью, а содержит перечисление статей 
        /// </summary>
        /// <param name="doc"> Документ из которого исвлекаются ссылки </param>
        /// <returns>список ссылок на статьи</returns>
        protected abstract List<string> GetArticlesLinks(HtmlDocument doc);

        /// <summary>
        /// Преобразует статью по ссылке в список объектов
        /// </summary>
        /// <returns> список объектов статьи</returns>
        protected abstract ArticleBase ParseArticle(HtmlDocument doc);

        /// <summary>
        /// Извлекает адрес в интернете, по которому лежала статья до сохранения на локальный диск
        /// </summary>
        /// <param name="doc"> html-документ, сохраненный из интернета на локальный диск</param>
        /// <returns> ссылку</returns>
        protected static string GetFileSourceLink(HtmlDocument doc)
        {
            string link;
            if (Regex.IsMatch(doc.DocumentNode.ChildNodes[2].InnerText, "<!-- saved from url=.*-->$"))
            {
                link = doc.DocumentNode.ChildNodes[2].InnerText;
                link = link.Remove(0, link.IndexOf('/') - 5);
                link = link.Remove(link.LastIndexOf('/') + 1);
                return link;
            }
            return null;
        }
    }
}

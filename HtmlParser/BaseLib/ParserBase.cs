using HtmlAgilityPack;
using System.Collections.Generic;

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
        /// Хранит источник текущей 
        /// </summary>
        protected string _currentArticleSource { get; set; }

        protected abstract List<string> GetArticlesLinks(HtmlDocument doc);
        protected abstract ArticleBase ParseArticle(HtmlDocument doc);
        public abstract List<ArticleBase> ParseLink(string link);

    }
}

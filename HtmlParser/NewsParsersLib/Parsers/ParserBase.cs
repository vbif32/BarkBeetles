﻿using HtmlAgilityPack;
using NewsParsersLib.Articles;
using System.Collections.Generic;

namespace NewsParsersLib.Parsers
{
    public abstract class ParserBase
    {
        public string SiteDomen;
        protected string _newsMainPage;
        protected string _currentArticleSource { get; set; }

        protected abstract List<string> GetArticlesLinks(HtmlDocument doc);
        protected abstract ArticleBase ParseArticle(HtmlDocument doc);
        public abstract List<ArticleBase> ParseLink(string link);

    }
}
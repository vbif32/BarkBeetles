using System;

namespace HtmlParser
{
    [Serializable]
    public abstract class ArticleBase
    {
        protected string _title;
        protected string _text;
        protected string _link;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }
        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
            }
        }
    }
}

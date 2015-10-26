namespace HtmlParser
{
    public abstract class ArticleBase
    {
        private string _title;
        private string _text;
        private string _link;
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

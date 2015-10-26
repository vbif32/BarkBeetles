using System;
using System.Collections.Generic;

namespace HtmlParser
{
    public class IacisArticle : ArticleBase
    {
        private string _author;
        private string _dateOfPublication;
        private string _imageCaption;
        private List<string> _images;

        public IacisArticle()
        {

        }
        public IacisArticle(string title, string text, string author, string date, string imageCaption, List<string> images)
        {
            Link = "unknown";
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = date;
            ImageCaption = imageCaption;
            Images = images;
        }
        public IacisArticle(string link, string title, string text, string author, string date, string imageCaption, List<string> images)
        {
            Link = link;
            Title = title;
            Text = text;
            Author = author;
            DateOfPublication = date;
            ImageCaption = imageCaption;
            Images = images;
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        public string DateOfPublication
        {
            get
            {
                return _dateOfPublication;
            }
            set
            {
                _dateOfPublication = value;
            }
        }
        public string ImageCaption
        {
            get
            {
                return _imageCaption;
            }
            set
            {
                _imageCaption = value;
            }
        }
        public List<string> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
            }
        }
        
        
    }
}

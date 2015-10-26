using HtmlParser.Parsers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HtmlParser
{
    static class Program
    {
        public static List<ArticleBase> articleList;
        public static WebClient wClient;


        public static Encoding encode = Encoding.GetEncoding("utf-8");

        [STAThread]
        static void Main(string[] args)
        {
            wClient = new WebClient();
            wClient.Proxy = null;
            wClient.Encoding = encode;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new NewsParserForm());
        }
    }

}

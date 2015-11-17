using NewsParsersLib.Parsers;
using System;
using System.Collections.Generic;

namespace NewsParsersLib
{
    internal static class SitesInformation
    {
        private static string _iacisDomen = "iacis.ru";
        private static string _iacisnewsMainPage = "iacis.ru";



        internal static Dictionary<string, ParserBase> _knownSites = new Dictionary<string, ParserBase>
        {
            { _iacisDomen, new IacisParser() }
        };
        internal static Dictionary<Type, string> domens = new Dictionary<Type, string>
        {
            { Type.GetType("IacisParser"), _iacisDomen },
        };
    }
}

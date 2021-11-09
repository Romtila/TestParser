using System.Collections.Generic;
using AngleSharp.Html.Dom;
using ParserDb.Models;

namespace TestParser.Core
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);

        public List<Item> ListParse(IHtmlDocument document);
    }
}
using System.Collections.Generic;
using AngleSharp.Html.Dom;

namespace TestParser.Core
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);

        public List<string> ListParse(IHtmlDocument document);
    }
}
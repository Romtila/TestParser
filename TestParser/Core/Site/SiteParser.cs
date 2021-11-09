using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace TestParser.Core.Site
{
    public class SiteParser : IParser<string[]>
    {
        //Должны получать названия объявлений
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a")
                .Where(item => item.ClassName != null && item.ClassName.Contains(Constants.Constants.Item));

            foreach (var item in items)
            {
                list.Add(item.QuerySelector(Constants.Constants.ItemTitle)?.Text());
            }

            return list.ToArray();
        }

        //Должны получать список названий объявлений
        public List<string> ListParse(IHtmlDocument document)
        {
            var list = new List<string>();

            var items = document.GetElementsByClassName(Constants.Constants.ItemTitle);

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list;
        }
    }
}

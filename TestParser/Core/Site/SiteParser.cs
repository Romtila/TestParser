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

            var items = document.GetElementsByClassName(Constants.Constants.Item);

            foreach (var item in items)
            {
                //list.Add(item.GetElementsByClassName(Constants.Constants.ItemTitle).FirstOrDefault()?.TextContent);//Название объявления
                //list.Add(item.GetElementsByClassName(Constants.Constants.ItemPrice).FirstOrDefault()?.TextContent);//Цена
                //list.Add(item.GetElementsByClassName(Constants.Constants.ItemCity).FirstOrDefault()?.TextContent);//Город
                list.Add("https://www.avito.ru" + item.QuerySelectorAll("a").OfType<IHtmlAnchorElement>().FirstOrDefault()?.GetAttribute(Constants.Constants.ItemRef));//item.GetElementsByClassName(Constants.Constants.ItemRef).FirstOrDefault()?.TextContent);//Ссылка на объяву
                list.Add(item.GetElementsByClassName(Constants.Constants.ItemPhotoRef).FirstOrDefault()?.TextContent);//Ссылка на фото
            }

            return list;
        }
    }
}

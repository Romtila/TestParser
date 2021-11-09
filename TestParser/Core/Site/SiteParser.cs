using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ParserDb.Models;

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
        public List<Item> ListParse(IHtmlDocument document)
        {
            var list = new List<Item>();

            var items = document.GetElementsByClassName(Constants.Constants.Item);

            foreach (var item in items)
            {
                list.Add(new Item()
                {
                    Title = item.GetElementsByClassName(Constants.Constants.ItemTitle).FirstOrDefault()?.TextContent,//Название объявления
                    Price = item.GetElementsByClassName(Constants.Constants.ItemPrice).FirstOrDefault()?.TextContent,//Цена
                    City = item.GetElementsByClassName(Constants.Constants.ItemCity).FirstOrDefault()?.TextContent,//Город
                    ItemRef = "https://www.avito.ru" + item.QuerySelectorAll("a").OfType<IHtmlAnchorElement>().FirstOrDefault()?.GetAttribute(Constants.Constants.ItemRef),//Ссылка на объяву
                    PhotoRef = item.GetElementsByClassName(Constants.Constants.ItemPhotoRef).FirstOrDefault()?.GetAttribute("src")//Ссылка на фото
                });
            }

            return list;
        }
    }
}

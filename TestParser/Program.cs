using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParserDb.Context;
using ParserDb.Models;
using TestParser.Core;
using TestParser.Core.Site;
using System.Diagnostics;
using System.IO;
using System.Text;
using TestParser.Constants;

namespace TestParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var parser = new ParserWorker<string[]>(new SiteParser(), new SiteSettings(1, 1));

            var itemList = await parser.GetListStart();

            using (var db = new UserContext())
            {
                var testObject = new TestObject() { Name = "test" };

                foreach (var item in itemList)
                {
                    ItemModel itemModel = new ItemModel(item);
                    db.Items.Add(itemModel);
                }

                await db.SaveChangesAsync();
            }

            itemList.Clear();

            using (var db = new UserContext())
            {
                foreach (var item in db.Items)
                {
                    itemList.Add(item);
                }
            }

            await File.WriteAllTextAsync("itemList.html", GetDataHtmlTable(itemList));

            Process.Start(new ProcessStartInfo("itemList.html") { UseShellExecute = true });

            Console.ReadKey();
        }

        private static string GetDataHtmlTable(List<Item> itemList)
        {
            var htmlHeader = "<table style=\"font-family: \"Lucida Sans Unicode\", \"Lucida Grande\", Sans-Serif;" +
                             "text - align: left;" +
                             "border - collapse: separate;" + 
                             "border - spacing: 5px;" +
                             "background: #ECE9E0;" +
                             "color: #656665;" +
                             "border: 16px solid #ECE9E0;" +
                             "border - radius: 20px;\">" +
                             
                             $"{MyCSSStyle.tr}" +
                             $"{MyCSSStyle.th}Название</th>" +
                             $"{MyCSSStyle.th}Цена</th>" +
                             $"{MyCSSStyle.th}Город</th>" +
                             $"{MyCSSStyle.th}Ссылка на объявление</th>" +
                             $"{MyCSSStyle.th}Ссылка на фото</th>" +
                             "</tr>";
            var msgBody = htmlHeader;

            for (var i = itemList.Count - 1; i > itemList.Count - 51; i--)
            {
                msgBody = HtmlTableWithData(itemList[i], msgBody);
            }

            var sbFinish = new StringBuilder();
            sbFinish.AppendLine("<html>");
            sbFinish.AppendLine("<head>");
            sbFinish.AppendLine("<meta http-equiv=\"Content-Type\" content =\"text/html; charset=utf-8\">");
            sbFinish.AppendLine("</head>");
            sbFinish.AppendLine("<body>");
            sbFinish.Append(msgBody).Append("</table>");
            sbFinish.AppendLine("</body>");
            sbFinish.AppendLine("</html>");

            msgBody = sbFinish.ToString();

            return msgBody;
        }

        private static string HtmlTableWithData(Item item, string str)
        {
            str += $"{MyCSSStyle.tr}" +
                       $"{MyCSSStyle.td}<a href=\"{item.ItemRef}\">{item.Title}</a></td>" +
                       $"{MyCSSStyle.td}{item.Price}</td>" +
                       $"{MyCSSStyle.td}{item.City}</td>" +
                       $"{MyCSSStyle.td}{item.ItemRef}</td>" +
                       $"{MyCSSStyle.td}{item.PhotoRef}</td></tr>";

            return str;
        }
    }
}

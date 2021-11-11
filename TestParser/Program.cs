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
                 /*   Console.WriteLine(item.Title);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.City);
                    Console.WriteLine(item.ItemRef);
                    Console.WriteLine(item.PhotoRef);

                    Console.WriteLine();
                    Console.WriteLine();*/
                }
            }

            await File.WriteAllTextAsync("itemList.html", GetDataHtmlTable(itemList));

            //var prs = new ProcessStartInfo(@"C:\Users\romti\AppData\Local\Yandex\YandexBrowser\Application\browser.exe");
            //prs.Arguments
            Process.Start(new ProcessStartInfo("itemList.html") {UseShellExecute = true});
            
            /*
            foreach (var item in itemList)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.City);
                Console.WriteLine(item.ItemRef);
                Console.WriteLine(item.PhotoRef);

                Console.WriteLine();
                Console.WriteLine();
            }*/

            Console.ReadKey();
        }

        private static string GetDataHtmlTable(List<Item> itemList)
        {
            var htmlHeader = "<table style=\"font - size:14px\">" +
                             "<tr style=\"font - size:14px\">" +
                             "<th align='left'>Mac</th><th>&nbsp;</th>" +
                             "<th align='left'>Name</th><th>&nbsp;</th>" +
                             "<th align='left'>Dividend Value</th><th>&nbsp;</th>" +
                             "<th align='left'>Currency</th><th>&nbsp;</th>" +
                             "<th align='left'>Country of Incorp</th><th>&nbsp;</th>" +
                             "</tr>";
            var msgBody = htmlHeader;

            foreach (var t in itemList)
            {
                msgBody += "<tr><td style=\"font - size:14px\">"
                                  + t.Title + "</td><td style=\"font - size:14px\">&nbsp;</td><td>"
                                  + t.Price + "</td><td style=\"font - size:14px\">&nbsp;</td><td>"
                                  + t.City + "</td><td style=\"font - size:14px\">&nbsp;</td><td>"
                                  + t.ItemRef + "</td><td style=\"font - size:14px\">&nbsp;</td><td>"
                                  + t.PhotoRef + "</td><td style=\"font - size:14px\">&nbsp;</td>";
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
    }
}

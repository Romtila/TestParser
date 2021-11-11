using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParserDb.Context;
using ParserDb.Models;
using TestParser.Core;
using TestParser.Core.Site;

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


            using (var db = new UserContext())
            {
                foreach (var item in db.Items)
                {
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.City);
                    Console.WriteLine(item.ItemRef);
                    Console.WriteLine(item.PhotoRef);

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            await File.WriteAllTextAsync("itemList.html", GetDataHtmlTable(itemList));
            
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
    }
}

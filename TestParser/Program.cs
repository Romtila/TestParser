using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            foreach (var item in itemList)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.City);
                Console.WriteLine(item.ItemRef);
                Console.WriteLine(item.PhotoRef);

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

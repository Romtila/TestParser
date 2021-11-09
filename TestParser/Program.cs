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
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}

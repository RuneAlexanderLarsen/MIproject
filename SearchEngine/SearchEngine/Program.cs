using SearchEngine;
using stopword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        private static int MAX_PAGES = 1000;

        static void Main(string[] args)
        {
            /*String result = "";

            //Crawler
            Spider spider = new Spider();
            spider.initialize();

            int i;
            for(i = 0; i < MAX_PAGES; i++) {
                result = spider.crawl();

                //Removal of stopwords and Tokenise
                Stop stop = new Stop();
                result = stop.initialize(result);*/

            int i = PageRanker.GetPageRank("https://www.microsoft.com");
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}

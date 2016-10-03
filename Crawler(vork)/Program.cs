using stopword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Program {
        static void Main(string[] args) {
            String result = "";

            //Crawler
            Spider spider = new Spider();
            result = spider.initialize();

            //Removal of stopwords and Tekenise
            Stop stop = new Stop();
            result = stop.initialize(result);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

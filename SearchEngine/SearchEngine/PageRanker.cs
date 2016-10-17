using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;
using System.Net;
using System.IO;

namespace SearchEngine
{
    public class PageRanker
    {

        public static void PageRankMain(string[] urls)
        {
            int[] idURL = new int[1000];
            idURL = ConvertUrlsToInt(urls);

            for (int i = 0; i >= 1000; i++)
            {
                LinksInURL(idURL[i]);
            }
                
            place the NotFiniteNumberException in pagearray
            
            int[,] PageArray = new int[1000,1000];
            
        }

        public static int GetPageRank(string url)
        {
            int rankPart = 0;

            int[,] PageArray = new int[1000,2];

            rankPart = numberOfLinks / totalCites;



            return rank;
        }

    }

}

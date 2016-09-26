using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopword
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "this game is fantastic. So, I watched and played a lot.";
            string[] tokens = stopword.Tokenise.separate(text);
            string[] tokensLowerCase = stopword.Tokenise.caseFolding(tokens);
            //normilice!!
            string textNoStopWords = stopword.Stop.stopfunction(tokensLowerCase);
            PorterStemmer hej;
            hej.
            Console.WriteLine(textNoStopWords);
            Console.ReadLine();
        }
    }
}

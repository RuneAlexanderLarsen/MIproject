using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopword
{
    class Stop
    {

        public string initialize(string result) {
            string[] tokens = stopword.Tokenise.separate(result);
            string[] tokensLowerCase = stopword.Tokenise.caseFolding(tokens);
            //normilice!!
            string textNoStopWords = stopword.Stop.stopfunction(tokensLowerCase);

            return textNoStopWords;
        }

        static public string stopfunction(string[] text) {
            string[] stopWords = readStopWordsFromFile();
            //string[] words = text.Split();
            var newWords = text.Except(stopWords);
            string textNoStopWords = string.Join(" ", newWords);
            return textNoStopWords;
        }

        static public string[] readStopWordsFromFile() {
            string[] stopWords = new string[] {"a", "about", "above", "after", "again", "against", "all", "am", "an", "and", "any", "are", "aren't", "as", "at", "be", "because",  "been", "before", "being", "below", "between", "both", "but", "by", "can't", "cannot", "could", "couldn't", "did", "didn't", "do", "does", "doesn't", "doing", "don't", "down", "during", "each", "few", "for", "from", "further", "had", "hadn't", "has", "hasn't", "have", "haven't", "having", "he", "he'd", "he'll", "he's", "her", "here", "here's", "hers", "herself", "him", "himself", "his", "how", "how's", "i", "i'd", "i'll", "i'm", "i've", "if", "in", "into", "is", "isn't", "it", "it's", "its", "itself", "let's", "me", "more", "most", "mustn't", "my", "myself", "no", "nor", "not", "of", "off", "on", "once", "only", "or", "other", "ought", "our", "ours" };
            return stopWords;
        }

   }
}

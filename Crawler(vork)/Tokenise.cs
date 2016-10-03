using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stopword
{
    class Tokenise
    {
        public static string[] separate(string text) {
            string[] tokens = text.Split(' ', '\n', '\t');
            return tokens;
        }

        public static string[] caseFolding(string[] tokens) {
            var tokensLower = tokens.Select(s => s.ToLowerInvariant()).ToArray();
            return tokensLower;
        }

        public static void normalice() {

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Crawler {
    class Spider {
        private int MAX_PAGES = 1000;
        private Queue<String> queue1 = new Queue<String>();
        private Queue<String> queue2 = new Queue<String>();
        private Queue<String> queue3 = new Queue<String>();

        public string initialize() {
            String seed = "https://da.wikipedia.org/wiki/Forside";
            queue1.Enqueue(seed);
            String text = getText(queue1.Dequeue());
            String parsedText = "";

            var textParser = new Regex(@"(?<=\<p\>)(\s*.*\s*)(?=\<\/p\>)");
            foreach (Match m in textParser.Matches(text)) {
                parsedText += m.Value + "\n\n";
            }

            parsedText = Regex.Replace(parsedText, @"<.*?>", "");
            

            List<String> urls = new List<String>();

            var linkParser = new Regex(@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(text)) {
                urls.Add(m.Value);
            }

            //urls = normalizeUrls(urls);

            /*foreach (String str in urls) {
                Console.WriteLine(str);
            }*/

            foreach (String str in urls) {
                if (!queue1.Contains(str) || !queue2.Contains(str) || !queue3.Contains(str)) {
                    //prioritizeUrl(str);
                }
            }

            return parsedText;
        }

        public String getText(String url) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "A .NET Web Crawler";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string htmlText = reader.ReadToEnd();
            return htmlText;
        }

        public List<String> normalizeUrls(List<String> urls) {
            List<String> normalizedUrls = new List<String>();
            int i = 0;

            foreach (String str in urls) {
                //Remove href=" and "
                //normalizedUrls.Add(str.Remove(0, 6));
                //normalizedUrls[i] = str.Remove(str.Length - 1, 1);

                //Convert to lower case
                normalizedUrls[i] = (str.Replace(str, str.ToLower()));

                //Capitalize the two characters after %
                int j = 0;
                foreach (Char c in str) {
                    if (c.Equals('%')) {
                        normalizedUrls[i] = normalizedUrls[i].Replace(str.Substring(j + 1, 2), normalizedUrls[i].Substring(j + 1, 2).ToUpper());
                    }
                    j++;
                }
                i++;
            }
            return urls;
        }

        public void prioritizeUrl(String url) {
            Uri uri = new Uri(url);
            String host = uri.Host;

            Console.WriteLine(host);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Parser {

        public string restrictions;

        public Parser(string url)
        {   

            restrictions = Parse("Neo", url);          
        }

        private string Parse(string robotName, string url)
        {
            string line;
            bool dontIgnore = false;
            Uri uri = new Uri(url);
            bool doesExist;
            CheckRobot checkRobot = new CheckRobot(url);

            if (doesExist = checkRobot.getResult()) {
                return @"C:\Users\Chres\Desktop\Robots\" + uri.Host + ".txt";
            }

            var webRequest = WebRequest.Create(@"http://" + uri.Host+"/robots.txt");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new System.IO.StreamReader(content))
            {

                System.IO.FileStream fsOverwrite = new System.IO.FileStream(@"C:\Users\Chres\Desktop\Robots\" + uri.Host + ".txt", System.IO.FileMode.Create);
                System.IO.StreamWriter restrictionsWriter = new System.IO.StreamWriter(fsOverwrite);

                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    if (string.IsNullOrEmpty(line))
                    {

                    }
                    else if (words[0][0].Equals('#'))
                    {

                    }
                    else if (dontIgnore & words[0].Equals("Disallow:"))
                    {
                        restrictionsWriter.WriteLine(words[1]);
                    }
                    else if (words[0].Equals("Crawl-delay:"))
                    {
                        restrictionsWriter.WriteLine("Crawl" + words[1]);
                    }
                    else
                    {
                        if (words[0].Equals("User-agent:"))
                        {
                            if (words[1].Equals("*"))
                            {
                                dontIgnore = true;
                            }
                            else if (words[1].Equals(robotName))
                            {
                                dontIgnore = true;
                            }
                            else
                            {
                                dontIgnore = false;
                            }
                        }
                    }
                }

                restrictionsWriter.Close();
                fsOverwrite.Close();
                reader.Close();

                return @"C:\Users\Chres\Desktop\Robots\" + uri.Host + ".txt";
            }
        }
    }
}

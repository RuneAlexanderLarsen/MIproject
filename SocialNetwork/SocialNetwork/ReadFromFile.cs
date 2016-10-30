using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocialNetwork {
    class ReadFromFile {

        Dictionary<string, Vertex> dictionary = new Dictionary<string, Vertex>();

        public void readFile() {
            StreamReader reader = File.OpenText(@"C:\Users\Nicolai Vork\Desktop\Web Intelligence\SocialNetwork\SocialNetwork\friendships.txt");
            string line;
            int i;
            List<string> userNames = new List<string>();

            //Go through the file and find all usernames. For each of these, add it to the dictionary and make a vertex
            while ((line = reader.ReadLine()) != null) {
                for (i = 0; i < 4; i++) {
                    if (i == 0) {
                        dictionary.Add(line.Substring(6), new Vertex(line.Substring(6)));
                    }
                    line = reader.ReadLine();
                }
            }

            //Go through the file a second time and add edges between vertices
            while ((line = reader.ReadLine()) != null) {
                for (i = 0; i < 4; i++) {
                    if (i == 1) {
                        
                    }
                    line = reader.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}

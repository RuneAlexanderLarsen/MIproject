using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork {
    class Program {
        static void Main(string[] args) {
            ReadFromFile read = new ReadFromFile();
            read.readFile();
        }
    }
}

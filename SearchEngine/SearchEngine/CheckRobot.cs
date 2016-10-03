using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politeness
{
    class CheckRobot
    {
        bool result;
        public CheckRobot(string url)
        {
            Uri uri = new Uri(url);

            result = File.Exists(@Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Desktop/Robots/" + uri.Host + ".txt");
        }

        public bool getResult()
        {
            return result;
        }
    }
}

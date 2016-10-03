using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class QueryProcessor {

        public void processQuery(String query) {
            
        }

        public List<int> intersect(Posting post1, Posting post2) {
            List<int> matchingDocIds = new List<int>();

            post1.getList.Sort();
            post2.getList.Sort();

            int i = 0, j = 0;
            while (i < post1.getList.Count && post2.getList.Count < j) {
                if (post1.getList.ElementAt(i).Item1.Equals(post2.getList.ElementAt(j).Item1)) {
                    matchingDocIds.Add(post1.getList.ElementAt(i).Item1);
                    i++;
                    j++;
                } else if (post1.getList.ElementAt(i).Item1 < post2.getList.ElementAt(j).Item1) {
                    i++;
                } else if (post1.getList.ElementAt(i).Item1 > post2.getList.ElementAt(j).Item1) {
                    j++;
                }
            }
            return matchingDocIds;
        }

        public List<int> union(Posting post1, Posting post2) {
            List<int> matchingDocIds = new List<int>();


            foreach (Tuple<int, int> pair in post1.getList) {
                if (!matchingDocIds.Contains(pair.Item1)) {
                    matchingDocIds.Add(pair.Item1);
                }
            }

            foreach (Tuple<int, int> pair in post2.getList) {
                if (!matchingDocIds.Contains(pair.Item1)) {
                    matchingDocIds.Add(pair.Item1);
                }
            }

            return matchingDocIds;
        }

        /*public List<int> complement(Posting post) {

        }*/

    }
}

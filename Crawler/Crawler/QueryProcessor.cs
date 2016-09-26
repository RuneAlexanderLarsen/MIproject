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
                if (post1.getList[i].Equals(post2.getList[j])) {
                    matchingDocIds.Add(post1.getList[i]);
                    i++;
                    j++;
                } else if (post1.getList[i] < post2.getList[j]) {
                    i++;
                } else if (post1.getList[i] > post2.getList[j]) {
                    j++;
                }
            }
            return matchingDocIds;
        }

        public List<int> union(Posting post1, Posting post2) {
            List<int> matchingDocIds = new List<int>();

            foreach (int docId in post1.getList) {
                if (!matchingDocIds.Contains(docId)) {
                    matchingDocIds.Add(docId);
                }
            }

            foreach (int docId in post2.getList) {
                if (!matchingDocIds.Contains(docId)) {
                    matchingDocIds.Add(docId);
                }
            }

            return matchingDocIds;
        }

        /*public List<int> complement(Posting post) {

        }*/

    }
}

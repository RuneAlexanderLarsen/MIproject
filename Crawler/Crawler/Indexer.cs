using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Indexer {
        Dictionary<String, int> termSequence = new Dictionary<string, int>();

        public void index(String[] terms, int docId) {
            //Eliminates duplicates, i.e. same terms with same docIds
            foreach (String term in terms) {
                if (!termSequence.ContainsKey(term) || !termSequence[term].Equals(docId)) {
                    termSequence.Add(term, docId);
                }
            }
        }

        //Sort the index first by key, and then by value
        public void sortIndex() {
            var sortedDictionary = from pair in termSequence
                                   orderby pair.Key ascending,
                                   pair.Value ascending
                                   select pair;
            termSequence = (Dictionary<String, int>) sortedDictionary;
        }

        public void indexConstruction() {
            Dictionary<String, Tuple<int, Posting>> index = new Dictionary<String, Tuple<int, Posting>>();

            foreach (KeyValuePair<String, int> kvp in termSequence) {
                //If the term is not in the index, add it to the index along with the docId
                //If the term is in the index, get the old posting list, add the docId to that list and make the new values for the term (key)
                if (!index.ContainsKey(kvp.Key)) {
                    index.Add(kvp.Key, new Tuple<int, Posting>(1, new Posting(kvp.Value)));
                } else {
                    List<int> posting = index[kvp.Key].Item2.getList;
                    posting.Add(kvp.Value);
                    index[kvp.Key] = new Tuple<int, Posting>(index[kvp.Key].Item1 + 1, new Posting(posting));
                }
            }
        }
    }
}

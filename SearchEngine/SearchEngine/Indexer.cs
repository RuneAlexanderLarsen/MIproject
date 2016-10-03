using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Indexer {
        List<Tuple<String, int>> termSequence = new List<Tuple<String, int>>();
        Dictionary<String, Tuple<int, Posting>> index = new Dictionary<String, Tuple<int, Posting>>();

        public Dictionary<String, Tuple<int, Posting>> getIndex {
            get { return index; }
        }

        public void doIndex(String[] terms, int docId) {
            //Eliminates duplicates, i.e. same terms with same docIds
            foreach (String term in terms) {
                termSequence.Add(new Tuple<String, int>(term, docId));
            }

            //Sort termSequence
            sortTermSequence();

            //Construct index
            indexConstruction();
        }

        //Sort the index first by key, and then by value
        public void sortTermSequence() {
            var sortedTermSequence = from pair in termSequence
                                   orderby pair.Item1 ascending,
                                   pair.Item2 ascending
                                   select pair;
            termSequence = (List<Tuple<String, int>>) sortedTermSequence;
        }

        public void indexConstruction() {
            //Remove duplicates from term sequence
            termSequence = termSequence.Distinct().ToList();

            foreach (Tuple<String, int> pair in termSequence) {
                //If the term is not in the index, add it to the index along with the docId
                //If the term is in the index, get the old posting list, add the docId to that list and make the new values for the term (key)
                if (!index.ContainsKey(pair.Item1)) {
                    index.Add(pair.Item1, new Tuple<int, Posting>(1, new Posting(pair.Item2, 1)));
                } else {
                    List<Tuple<int, int>> posting = index[pair.Item1].Item2.getList;
                    if (posting.Any(x => x.Item1.Equals(pair.Item2))) {
                        //Get the index, get the term frequency for that index and add new tupple at specified index with incremented term frequency
                        int i = posting.FindIndex(x => x.Item1.Equals(pair.Item2));
                        int termFrequency = posting.ElementAt(i).Item2;
                        posting.Insert(i, new Tuple<int, int>(posting.ElementAt(i).Item1, termFrequency++));
                    } else {
                        posting.Add(new Tuple<int, int>(pair.Item2, 1));
                    }
                    index[pair.Item1] = new Tuple<int, Posting>(index[pair.Item1].Item1, new Posting(posting));
                }
            }
        }
    }
}

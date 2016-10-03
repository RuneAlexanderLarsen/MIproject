using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Ranker {
        public void rank() {

        }

        public double termFrequency(String term, int docId) {
            Indexer index = new Indexer();
            double termFrequency;
            if (index.getIndex[term].Item2.getList.Any(x => x.Item1.Equals(docId))) {
                int i = index.getIndex[term].Item2.getList.FindIndex(x => x.Item1.Equals(term));
                termFrequency = index.getIndex[term].Item2.getList.ElementAt(i).Item2;
            } else {
                return termFrequency = 0;
            }
            termFrequency = 1.0 + Math.Log10(termFrequency);

            return termFrequency;
        }

        public double inverseDocumentFrequency (String term) {
            Indexer index = new Indexer();
            double documentFrequency = index.getIndex[term].Item1;
            double inverseDocumentFrequency = Math.Log10(1000.0 / documentFrequency);
            return inverseDocumentFrequency;
        }

        public double TF_IDF(double termFrequency, double inverseDocumentFrequency) {
            return termFrequency * inverseDocumentFrequency;
        }

        public double cosineScore(String query) {

        }
    }
}

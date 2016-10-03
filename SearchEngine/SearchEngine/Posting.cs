using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Posting {

        List<Tuple<int, int>> posting = new List<Tuple<int, int>>();

        public Posting (int docId, int termFrequency) {
            posting.Add(new Tuple<int, int>(docId, termFrequency));
        }

        public Posting (List<Tuple<int, int>> posting) {
            this.posting = posting;
        }

        public List<Tuple<int, int>> getList {
            get { return posting; }
        }
        
    }
}

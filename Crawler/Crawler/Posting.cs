using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler {
    class Posting {

        List<int> posting = new List<int>();

        public Posting (int docId) {
            posting.Add(docId);
        }

        public Posting (List<int> posting) {
            this.posting = posting;
        }

        public List<int> getList {
            get { return posting; }
        }
        
    }
}

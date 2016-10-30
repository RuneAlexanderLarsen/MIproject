using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork {
    class Edge {
        private Vertex node1;
        private Vertex node2;
        private int score;

        public Edge(Vertex node1, Vertex node2) {
            this.node1 = node1;
            this.node2 = node2;
        }

        public int getScore { get { return score; } }
    }
}

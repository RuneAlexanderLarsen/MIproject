using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork {
    class Vertex {
        private string name;
        private int weight;
        private int distance;
        private List<Edge> neighbors;

        public Vertex(string name) {
            this.name = name;
        }

        //TODO: Maybe delete
        public Vertex(string name, Edge neighbor) {
            this.name = name;
            neighbors.Add(neighbor);
        }

        public int getWeight { get { return weight; } }
        public int getDistance { get { return distance; } }
        public List<Edge> getNeighbors { get { return neighbors; } }
    }
}

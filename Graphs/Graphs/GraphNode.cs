using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphNode<T,W>
    {
        public GraphNode()
        {
            this.Neighbours = new Dictionary<GraphNode<T, W>, W>();
        }

        public T Value { get; set; }

        public Dictionary<GraphNode<T,W>,W> Neighbours { get; set; }

        public virtual bool AddNeightbour(GraphNode<T, W> neighbour, W link)
        {
            if (!this.Neighbours.ContainsKey(neighbour))
            {
                this.Neighbours.Add(neighbour, link);
                return true;
            }
            return false;
        }

        public virtual bool RemoveNeightbour(GraphNode<T, W> graphNode)
        {
            if (this.Neighbours.ContainsKey(graphNode))
            {
                this.Neighbours.Remove(graphNode);
                return true;
            }
            return false;
        }
    }
}

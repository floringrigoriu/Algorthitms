using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class NonDirectedGraph<T,W>:GraphNode<T,W>
    {
        public override bool AddNeightbour(GraphNode<T,W> neighbour, W link)
        {
            if (base.AddNeightbour(neighbour, link))
            {
                neighbour.AddNeightbour(this, link);
                return true;
            }
            return false;
        }

        public override bool RemoveNeightbour(GraphNode<T, W> graphNode)
        {
            if (base.RemoveNeightbour(graphNode))
            {
                graphNode.RemoveNeightbour(this);
                return true;
            }
            return false;
        }
    }
}

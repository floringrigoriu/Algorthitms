using System;
using System.Collections.Generic;

namespace Trees.NthElement
{
    public class NthNodeFromEndVisitor<T>:IVisitor<T>
    {
        private int nth;
        private Queue<T> visited;

        public NthNodeFromEndVisitor(int n)
        {
            this.nth = n;
            this.visited = new Queue<T>();
        }

        public void Visit(TreeNode<T> node)
        {
            this.visited.Enqueue(node.Value);
            if (this.visited.Count > this.nth)
            {
                // remove old, unnecessary element
                this.visited.Dequeue(); 
            }
        }

        public bool IsVisitDone
        {
            get 
            { 
                return false; // until we reach the last node we don't know what is tha nth item
            }
        }

        public T GetNth()
        {
            if (this.visited.Count == nth)
            {
                return this.visited.Peek();
            }
            else
            {
                throw new Exception("Not enought nodes visited");
            }
        }

        public static T GetNth(TreeNode<T> root, int n, ITraversal<T> traversal)
        {
            var visitor = new NthNodeFromEndVisitor<T>(n);
            traversal.Traverse(root, visitor);

            return visitor.GetNth();
        }
    }
}

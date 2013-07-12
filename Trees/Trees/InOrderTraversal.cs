using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// Class Implementing in order traversal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InOrderTraversal<T> : ITraversal<T>
    {
        public void Traverse(TreeNode<T> element, IVisitor<T> visitor)
        {
            if (element != null)
            {
                this.Traverse(element.Left,visitor);
                if (!visitor.IsVisitDone)
                {
                    visitor.Visit(element);
                }
                if (!visitor.IsVisitDone)
                {
                    this.Traverse(element.Right, visitor);
                }
            }
        }
    }
}

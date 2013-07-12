using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public interface IVisitor<T>
    {
        /// <summary>
        /// Visit a node in a tree
        /// </summary>
        /// <param name="node">node to be visit</param>
        void Visit(TreeNode<T> node);

        /// <summary>
        /// Is further visiting necessary
        /// </summary>
        bool IsVisitDone { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P100_SameTree
{
    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == q) {
                return true; // same reference
            }

            if (p == null ^ q == null) {
                return false; // only one null
            }

            if (q.val != p.val) {
                return false;
            }

            if (!this.IsSameTree(p.left, q.left)) { return false; }

            if (!this.IsSameTree(p.right, q.right)) { return false; }

            return true;
        }
    }

     public class TreeNode {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
   }
}

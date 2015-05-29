using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P104_MaximumDepthBST
{
   /**
 * Definition for a binary tree node.*/
 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
     public TreeNode(int x) { val = x; }
  };
 
public class Solution {

    public int maxDepth(TreeNode root) {
        if (root == null) { return 0; }
        int result = this.maxDepth(root.left);
        result = Math.Max(result, 
            this.maxDepth(root.right)
        );
        result++; // add current level
        return result;
    }
};
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P104_MaximumDepthBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode test = new TreeNode(1);
            test.right = new TreeNode(2);
            TreeNode current = test.right;
            current.left = new TreeNode(3);
            current = current.left;
            current.right = new TreeNode(4);
            Solution s = new Solution();
            Console.Out.WriteLine("Solution:{0}", s.maxDepth(test));
        }
    }
}

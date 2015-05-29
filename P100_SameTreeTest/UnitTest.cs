using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P100_SameTree;

namespace P100_SameTreeTest
{
    [TestClass]
    public class UnitTest
    {
        Solution s = new Solution();

        [TestMethod]
        public void NullTest()
        {
            Assert.IsTrue(s.IsSameTree(null, null));
        }

        [TestMethod]
        public void nonEqual() { 
            // arrange
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n11 = new TreeNode(1);
            n11.right = new TreeNode(1);

            // assert
            Assert.IsFalse(s.IsSameTree(null, n1));

            Assert.IsFalse(s.IsSameTree(n2, n1));
            
            Assert.IsFalse(s.IsSameTree(n11, n1));
        }

        [TestMethod]
        public void Equal()
        {
            // arrange
            TreeNode n1 = new TreeNode(1);
            n1.left = new TreeNode(2);
            n1.right = new TreeNode(3);
            n1.right.left = new TreeNode(4);
            TreeNode n2 = new TreeNode(1);
            n2.left = new TreeNode(2);
            n2.right = new TreeNode(3);
            n2.right.left = new TreeNode(4);
            
            
            // assert
            Assert.IsTrue(s.IsSameTree(n1, n2));
         }
    }
}

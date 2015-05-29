using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;
using Trees.NthElement;

namespace UnitTest
{
    [TestClass]
    public class NthNodeTests
    {
        [TestMethod]
        public void GetNethNodeTest()
        {
            // setup : tree
            TreeNode<int> root = new TreeNode<int>(3,
                new TreeNode<int>(2,null,null),
                new TreeNode<int>(5,
                    new TreeNode<int>(4,null,null),
                    new TreeNode<int>(6,null,null)));

            // trigger : get nth
            int result = NthNodeFromEndVisitor<int>.GetNth(root, 4, new InOrderTraversal<int>());

            // validate value
            Assert.AreEqual(3, result);
        }
    }
}

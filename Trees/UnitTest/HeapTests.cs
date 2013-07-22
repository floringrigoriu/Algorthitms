using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace UnitTest
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void BuildTest()
        {
            // Build a heap
            Heap<int, int> heap = new Heap<int, int>((i) => i);
            int size = 255;
            Random rnd = new Random();
            for (int index = 0; index < size; index++) 
            {
                heap.Add(rnd.Next(0,255));
            }
            
            // validate
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual<int>(8, GetMaxDepth(heap.root));
            Assert.AreEqual<int>(8, GetMinDepth(heap.root));
            Assert.IsTrue(IsHeap(heap.root));
        }

        private bool IsHeap(TreeNode<int> treeNode)
        {
            if (treeNode == null)
            {
                return true;
            }
            else 
            {
                return (treeNode.Left == null || treeNode.Value >= treeNode.Left.Value)
                    && (treeNode.Right == null || treeNode.Value >= treeNode.Right.Value)
                    && IsHeap(treeNode.Left)
                    && IsHeap(treeNode.Right);
            }
        }

        private int GetMinDepth(TreeNode<int> treeNode)
        {
            if (treeNode == null)
            {
                return 0;
            }
            else 
            {
                return 1 + Math.Min(GetMinDepth(treeNode.Left), GetMinDepth(treeNode.Right));
            }
        }

        private int GetMaxDepth(TreeNode<int> treeNode)
        {
            if (treeNode == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(GetMaxDepth(treeNode.Left), GetMaxDepth(treeNode.Right));
            }
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PregatireInterviewuri2013;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for TreeTests
    /// </summary>
    [TestClass]
    public class TreeTests
    {
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get;
            set;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestBSTREmoval()
        {
            // setup
            var input = getDataSet();

            // action
            var result = Trees.BSTNodeReplace(input, 4);

            // assert
            Assert.AreEqual(result, input);
            Assert.AreEqual(result.Value, 3);
            Assert.AreEqual(result.Left.Right.Value, 1);
        }

        [TestMethod]
        public void TestNextTreeNode()
        {
            var input = getDataSet();

            var testNode1 = input.Left.Right;
            Assert.AreEqual(testNode1.Value, 3);
            Assert.AreEqual(testNode1.Value + 1, Trees.NextNodeInorder(testNode1).Value);

            var testNode2 = input.Left.Right.Left;
            Assert.AreEqual(testNode2.Value, 1);
            Assert.AreEqual(testNode2.Value + 1, Trees.NextNodeInorder(testNode2).Value);
            
            var testNode3 = input.Left.Right.Left.Right;
            Assert.AreEqual(testNode3.Value, 2);
            Assert.AreEqual(testNode3.Value + 1, Trees.NextNodeInorder(testNode3).Value);

            var testNode4 = input.Right.Right;
            Assert.AreEqual(testNode4.Value, 6);
            Assert.AreEqual(null, Trees.NextNodeInorder(testNode4));
        }

        private static Trees.TreeNode<int> getDataSet()
        {
            return new Trees.TreeNode<int>(4,
                new Trees.TreeNode<int>(0,
                    null,
                    new Trees.TreeNode<int>(3,
                        new Trees.TreeNode<int>(1,
                            null,
                            new Trees.TreeNode<int>(2)))),
               new Trees.TreeNode<int>(5,
                    null,
                    new Trees.TreeNode<int>(6))); 
        }
    }
}

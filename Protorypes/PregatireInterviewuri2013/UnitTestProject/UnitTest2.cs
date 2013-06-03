using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PregatireInterviewuri2013;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class BacktrackingTests
    {
        [TestMethod]
        public void TestPerm()
        {
            var input = "abc";

            var permutations = backtracking.GetPermutations(input).ToArray();

            ////Assert.AreEqual(6, permutations.Count());
        }
    }
}

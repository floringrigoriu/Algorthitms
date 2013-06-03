using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PregatireInterviewuri2013;

namespace UnitTestProject
{
    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void GetDuplicate()
        {
            // input 
            var input = new[] { 5, 1, 2, 3, 10, 7, 8, 1 };

            // test
            var result = General.RemoveDuplicates(input);

            // verify
            Assert.AreEqual(1, result);
        }
    }
}

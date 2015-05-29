using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PregatireInterviewuri2013;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for StringsTests
    /// </summary>
    [TestClass]
    public class StringsTests
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

        [TestMethod]
        public void TestRevers()
        {
            var input = "a brown quick fox";

            var result1 = Strings.Reverse1(input);
            var result2 = Strings.Reverse2(input);

            Assert.AreEqual(result1, result2);
            Assert.AreEqual(result1, "a nworb kciuq xof");

        }
    }
}

using Combinations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CombinationTest
{
    [TestClass]
    public class PowerSetTest
    {
        [TestMethod]
        public void TestPowerset()
        {
            // setup
            var input = new char[] { 'c', 'b', 'a' };
            var expectedOutput = new String[] { "", "c", "b", "cb", "a", "ca", "ba", "cba" };

            // trigger
            var result = PowerSet.GetPowerSet(input).Select(i=> new String(i.ToArray())).ToArray();

            // validate
            Assert.IsTrue(expectedOutput.SequenceEqual(result));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace ProblemsTest
{
    [TestClass]
    public class MaxProfitTest
    {
        Solution_P122_MaxProfit solution = new Solution_P122_MaxProfit(); 

        [TestMethod]
        public void TestFallingMarket()
        {
            int[] input = { 10, 9, 8, 7, 6, 4 };

            Assert.AreEqual(0, this.solution.MaxProfit(input));
        }

        [TestMethod]
        public void TestRaisingMarket()
        {
            int[] input = { 3, 5, 6, 5, 7, 4,3,5,6 };

            Assert.AreEqual(8, this.solution.MaxProfit(input));
        }

    }
}

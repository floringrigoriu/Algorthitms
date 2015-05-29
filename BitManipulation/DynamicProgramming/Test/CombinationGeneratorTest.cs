using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Combinations;

namespace Test
{
    [TestClass]
    public class CombinationGeneratorTest
    {
        private CombinationGenerator generator = new CombinationGenerator();

        [TestMethod]
        public void GetCombinations()
        {
            //given a input
            //
            Random rnd = new Random();
            int n = rnd.Next(2, 10);
            int k = rnd.Next(n + 1); // RND boundaries are exclusive so n+1 will allow inclusive boundaries

            // Get combinations
            //
            var combination = generator.GetCombinations((uint)n, (uint)k);

            // Get Control value
            //
            var controlValue = GetControlCombinations(n, k);

            //do validate if output matches expected value
            //
            Assert.AreEqual<uint>(
                (uint)(controlValue),
                combination,
                "C({0},{1}) was computed as {2} instead of expected value of {3}",
                n,
                k,
                combination,
                controlValue);
        }

        [TestMethod]
        public void MaximumCombinations()
        {
            //iterate to get maximum

            uint last = 1;
            for (uint n = 2; n < 35; n++)
            {
                uint current = this.generator.GetCombinations(n, n / 2);
                Assert.IsTrue(current >= last, "For n= {0} current max combination < last r0und due to overflow", n);
                last = current;
            }

            // validate 35 and byond is not supported
            bool exceptionEncountered = false;
            try
            {
                this.generator.GetCombinations(35, 35 / 2);
            }
            catch(Exception ex) 
            {
                exceptionEncountered = true;
            }
            Assert.IsTrue(exceptionEncountered);
        }

        private static int GetControlCombinations(int n, int k)
        {
            int divisor = 1;
            for (int index = 1; index <= n - k; index++)
            {
                divisor *= index;
            }
            int dividend = 1;
            for (int index = k + 1; index <= n; index++)
            {
                dividend *= index;
            }
            return dividend / divisor;
        }

    }
}

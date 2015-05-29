using BitCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace BitCountTest
{
    [TestClass]
    public class ParityCounterTest
    {
        /// <summary>
        /// parity counter 
        /// </summary>
        private IBitCounter counter = new ParityCounter();

        /// <summary>
        /// number of items in test bench
        /// </summary>
        private const int testSize = 10;

        [TestMethod]
        public void TestFixedValueParity()
        {
            Console.WriteLine("testing {0}", this.counter.GetType().ToString());
            Assert.AreEqual<uint>((uint)1, counter.Count(0xE));

            Console.WriteLine("testing {0}", this.counter.GetType().ToString());
            Assert.AreEqual<uint>((uint)0, counter.Count(0xF));
        }

        [TestMethod]
        public void TestRandomValuesParity()
        {
            BitXorCounter wellKnownCounter = new BitXorCounter();
            Console.WriteLine("testing {0}", this.counter.GetType().ToString());
            var input = new byte[testSize];
            Random generator = new Random();
            
            //validate result against result from a well known algorithm
            Assert.AreEqual(wellKnownCounter.Count(input)%2, this.counter.Count(input));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;
using System.Numerics;

namespace BitCountTest
{
    [TestClass]
    public class BitShifterTest
    {
        /// <summary>
        /// Bit counter 
        /// </summary>
        IBitCounter counter;

        /// <summary>
        /// number of items in test bench
        /// </summary>
        private const int testSize = 10;

        public BitShifterTest()
        {
            counter = new BitShiftCounter();
        }

        public TestContext TestContext
        {
            get;
            set;
        }

        [TestMethod]
        public void TestFixedValue()
        {
            Assert.AreEqual<uint>((uint)3, counter.Count(0xE));
        }

        [TestMethod]
        public void TestRandomValues()
        {
            Random generator = new Random();
            for (int index = 0; index < testSize; index++)
            {
                var value = generator.Next();
                this.TestContext.WriteLine("Testing value {0}", value);
                var count = counter.Count((uint)value);
                Assert.AreEqual<uint>(count, counter.Count((UInt64)value));
                Assert.AreEqual<uint>(count, counter.Count(BigInteger.Parse(value.ToString())));
                Assert.AreEqual<uint>(count, counter.Count(BitConverter.GetBytes(value)));
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;
using System.Numerics;

namespace BitCountTest
{
    [TestClass]
    public abstract class BitCounterBaseTest
    {
        /// <summary>
        /// Bit counter 
        /// </summary>
        protected IBitCounter counter;

        /// <summary>
        /// number of items in test bench
        /// </summary>
        private const int testSize = 10;

        protected BitCounterBaseTest()
        {
            this.counter = GetCounter();
        }

        public TestContext TestContext
        {
            get;
            set;
        }

        abstract protected IBitCounter GetCounter();

        [TestMethod]
        public void TestFixedValue()
        {
            Console.WriteLine("testing {0}", this.counter.GetType().ToString());
            Assert.AreEqual<uint>((uint)3, counter.Count(0xE));
        }

        [TestMethod]
        public void TestRandomValues()
        {
            Console.WriteLine("testing {0}", this.counter.GetType().ToString());
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

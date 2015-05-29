using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;

namespace BitCountTest
{
    [TestClass]
    public class BitSwapTest
    {
        [TestMethod]
        public void SwapTest()
        {
            // setup
            ulong input = 0x01000200ffffffff;

            // trigger
            var result = BitSwap.SwapBits(input, 56, 63);

            // validate
            Assert.AreEqual<UInt64>(0x80000200ffffffff, result);
        }
    }
}

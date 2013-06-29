using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;
using System.Numerics;
using System.Linq;

namespace BitCountTest
{
    [TestClass]
    public class ModuloBitCounterTest : BitCounterBaseTest
    {
        protected override IBitCounter GetCounter()
        {
            return new ModuloBitCounter();
        }

        [TestMethod]
        public void TestMaskGenerations()
        {
            // get masks
            var masks = new ModuloBitCounter().ComputeMasks(31);

            // verify them
            Assert.AreEqual(3, masks.Length);
            Assert.IsTrue(masks.SequenceEqual(new BigInteger[]{0x55555555,0x33333333,0x0f0f0f0f}));
        }
     }
}

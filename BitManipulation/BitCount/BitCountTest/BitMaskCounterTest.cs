using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;
using System.Numerics;

namespace BitCountTest
{
    [TestClass]
    public class BitMaskCounterTest: BitCounterBaseTest
    {
        protected override IBitCounter GetCounter()
        {
            return new BitMaskCounter();
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCount;
using System.Numerics;

namespace BitCountTest
{
    [TestClass]
    public class BitShifterTest:BitCounterBaseTest
    {
        protected override IBitCounter GetCounter()
        {
            return new BitShiftCounter();
        }
     }
}

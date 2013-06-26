using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitCount
{
    /// <summary>
    /// count bits by comparing the last bit with 1, and shifting left bits in the number while number > 0
    /// </summary>
    public class BitShiftCounter: IBitCounter
    {
        public uint Count(uint value)
        {
            uint result = 0;
            while (value > 0)
            {
                result += value & 0x1;
                value >>= 1;
            }
            return result;
        }

        public uint Count(UInt64 value)
        {
            uint result = 0;
            while (value > 0)
            {
                result +=(uint)(value & ((UInt64)0x1));
                value >>= 1;
            }
            return result;
        }

        public uint Count(BigInteger value)
        {
            if (value.Sign == -1)
            {
                throw new NotSupportedException();
            }
            uint result = 0;
            while (value > 0)
            {
                result += (uint)((value & BigInteger.One).Sign);
                value >>= 1;
            }
            return result;
        }


        public uint Count(byte[] value)
        {
            uint result = 0;
            for (int index =0; index < value.Length; index ++)
            {
                byte b = value[index];
                while (b > 0)
                {
                    result += (uint)( b & 0x1);
                    b = (byte)(b >> 1);
                }
            }
            return result;
        }
    }
}

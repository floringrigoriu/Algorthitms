using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitCount
{
    /// <summary>
    /// count bits by  zero-ing the last bit.
    /// For example n & (n-1) for uint number will changing from 1 to 0 last 1 of bit represenation 
    /// 
    /// 10 &      (1010)(2) &
    /// 9         (1001)(2)
    /// =====================
    /// 8          (1000)(2)
    /// </summary>
    public class BitXorCounter : IBitCounter
    {
        public uint Count(uint value)
        {
            uint result = 0;
            while (value > 0)
            {
                value = value & (value - 1);
                result++;
            }
            return result;
        }

        public uint Count(UInt64 value)
        {
            uint result = 0;
            while (value > 0)
            {
                value = value & (value - 1);
                result++;
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
            while (value > BigInteger.Zero)
            {
                value &= value - BigInteger.One;
                result++;
            }
            return result;
        }


        public uint Count(byte[] value)
        {
            uint result = 0;
            for (int index = 0; index < value.Length; index++)
            {
                byte b = value[index];
                while (b > 0)
                {
                    b = (byte)( b & (b - 1));
                    result++;

                }
            }
            return result;
        }
    }
}

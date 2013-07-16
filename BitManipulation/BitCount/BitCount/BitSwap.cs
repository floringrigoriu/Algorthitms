using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCount
{
    /// <summary>
    /// support bit swap utilities
    /// </summary>
    public static class BitSwap
    {
        /// <summary>
        /// swap bits I and J in the input value and return it
        /// </summary>
        public static UInt64 SwapBits(UInt64 value, byte i, byte j)
        { 
            // validate i,j valid bit indexes 
            if (i > 63)
            {
                throw new ArgumentException("bit index expected < 64", "i");
            }

            if (j > 63)
            {
                throw new ArgumentException("bit index expected < 64", "j");
            }

            // bit swap based on general observation that
            // a<->b can be done with a^=b ; b^=a ; a^=b;
            if(i<j)
            {
                i ^= j;
                j ^= i;
                i ^= j;
            }
            int delta = i-j;
            value ^= ((value & ((ulong)(0x1L << i)))>> delta);
            value ^= ((value & ((ulong)(0x1L << j))) << delta);
            value ^= ((value & ((ulong)(0x1L << i))) >> delta);
            return value;
        }
    }
}

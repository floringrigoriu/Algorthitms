using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitCount
{
    /// <summary>
    /// count bits by using a property if %:
    /// 
    /// (x * 256 + y ) 255 =  x+ y
    /// </summary>
    public class ModuloBitCounter : IBitCounter
    {
        private Dictionary<int, BigInteger[]> masks = new Dictionary<int, BigInteger[]>();

        public uint Count(uint value)
        {
            var result = (value & 0x55555555) + ((value>>1) & 0x55555555)  ;// sum adjacent bits
                result = (result & 0x33333333) + ((result >> 2) & 0x33333333); // sum adjacent 4 bits 
                result = (result & 0x0f0f0f0f) + ((result >> 4) & 0x0f0f0f0f); // sum ajacent 8 bits
                return result % 255;
        }

        public uint Count(ulong value)
        {
            var result = (value & 0x5555555555555555) + ((value >> 1) & 0x5555555555555555);// sum adjacent bits
            result = (result & 0x3333333333333333) + ((result >> 2) & 0x3333333333333333); // sum adjacent 4 bits 
            result = (result & 0x0f0f0f0f0f0f0f0f) + ((result >> 4) & 0x0f0f0f0f0f0f0f0f); // sum ajacent 8 bits
            return (uint)(result % 255L);
        }

        public uint Count(BigInteger value)
        {
            BigInteger[] masks = this.GetMasks(value);
            int maskId = 0;
            for (; maskId < masks.Length; maskId++)
            {
                value = (value & masks[maskId]) + ((value >> (1 << maskId)) & masks[maskId]);
            }
            return (uint) (value % 
                (BigInteger)((1<<
                    (1 << maskId))
                -1)); // simply magic :-)
        }

        /// <summary>
        /// Gets masks for algorithm
        /// the masks are different depending of the size of the input
        /// cache masks for future operations
        /// </summary>
        /// <remarks>not thread safe</remarks>
        private BigInteger[] GetMasks(BigInteger value)
        {
            // get magnitude
            int magnitude = GetMagnitude(value);

            // get masks
            BigInteger[] result = null;
            if (!this.masks.TryGetValue(magnitude, out result))
            {
                result = ComputeMasks(magnitude);
                this.masks[magnitude] = result;
            }
            return result;
        }

        public BigInteger[] ComputeMasks(int magnitude)
        {
            List<BigInteger> result = new List<BigInteger>();
            int index = 0;
            do
            {
                BigInteger currentMask = BigInteger.One;
                // do create a mask with holes
                var holeMask = (1 << (1 << index)) - 1;
                for (int subMask = 0; subMask < magnitude; subMask += 2 * (1 << index))
                {
                    currentMask |= holeMask << subMask;
                }
                result.Add(currentMask);
                index++;
            } while ((1<<(1 << index)) < magnitude);
            return result.ToArray();
        }

        private int GetMagnitude(BigInteger value)
        {
            int magnitude = 1;
            while(value > (BigInteger.One << magnitude) -1)
            {
                magnitude++;
            }
            return magnitude;
        }

        public uint Count(byte[] value)
        {
            return Count(new BigInteger(value));
        }
    }
}

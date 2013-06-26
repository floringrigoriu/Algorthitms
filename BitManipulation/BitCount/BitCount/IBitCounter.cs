
using System;
using System.Numerics;
namespace BitCount
{
    /// <summary>
    /// processor for counting number of bits in a number
    /// </summary>
    public interface IBitCounter
    {
        /// <summary>
        /// Count bits in int 32
        /// </summary>
        uint Count(uint value);

        /// <summary>
        /// Count bits in int 64
        /// </summary>
        uint Count(UInt64 value);

        /// <summary>
        /// Count bits in a big Number - 128 bits
        /// </summary>
        uint Count(BigInteger value);

        /// <summary>
        /// Count bits in a byte array
        /// </summary>
        uint Count(byte[] value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitCount
{
    /// <summary>
    /// count bits by doing mask manipulation
    /// </summary>
    public class BitMaskCounter : IBitCounter
    {
        /// <summary>
        /// specialization of counters for different types
        /// </summary>
        private Int32MaskCounter counter32 = new Int32MaskCounter();
        private Int64MaskCounter counter64 =  new Int64MaskCounter();
        private BigIntegerCounter counterBig = new BigIntegerCounter();
        private ByteMaskCounter counterByte = new ByteMaskCounter();

        public uint Count(uint value)
        {
            return this.counter32.CountBits(value);
        }

        public uint Count(UInt64 value)
        {
            return this.counter64.CountBits(value);
        }

        public uint Count(BigInteger value)
        {
            return this.counterBig.CountBits(value);
        }


        public uint Count(byte[] value)
        {
            return this.counterByte.CountBits(value);
        }
    }

    /// <summary>
    /// Encapsulate masks and their usage
    /// </summary>
    /// <typeparam name="Mask">type of mask</typeparam>
    /// <typeparam name="Value">type of value</typeparam>
    /// <remarks>
    /// Mask and Value can be of different types - for example in case of Byte[] 
    /// where Mask is of type of byte, while value is of Byte[]
    /// </remarks>
    public abstract class BaseMaskCounter<Mask,Value>
    {
        protected Mask[] masks { get; private set; }

        /// <summary>
        /// Generate masks if they are not generated
        /// </summary>
        protected Mask[] GetMasks(Value value)
        {
            if (!AreMaskPresent(value))
            {
                this.masks = GetKnownMasks(value).ToArray();
            }
            return this.masks;
        }

        /// <summary>
        /// Do compute the bit number
        /// </summary>
        public uint CountBits(Value value)
        {
            uint result = 0;
            var masks = GetMasks(value);
            foreach (var maskable in GetMaskableValueElements(value))
            {
                foreach (var mask in masks)
                {
                    if (isMaskAHit(mask,maskable))
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        protected abstract bool isMaskAHit(Mask mask, Mask maskable);

        protected abstract IEnumerable<Mask> GetMaskableValueElements(Value value);

        /// <summary>
        /// determine if generation of masks is required.
        ///  by default if masks != null then masks are present.
        ///  In case of BigInt number of is not know upfront
        /// </summary>
        /// <param name="value">value to be covered by mask</param>
        protected virtual bool AreMaskPresent(Value value)
        {
            return  masks !=null; 
        }

        /// <summary>
        /// Get Defined Masks for current type
        /// </summary>
        abstract protected IEnumerable<Mask> GetKnownMasks(Value value);
    }

    public class Int32MaskCounter : BaseMaskCounter<UInt32, UInt32>
    {
        protected override IEnumerable<UInt32> GetKnownMasks(UInt32 value)
        {
            for (uint mask =(((uint)0x1) << 31); mask > 0; mask >>= 1)
            {
                yield return mask;
            }
        }
        protected override bool isMaskAHit(UInt32 mask, UInt32 maskable)
        {
            return (mask & maskable) != 0;
        }

        protected override IEnumerable<UInt32> GetMaskableValueElements(UInt32 value) 
        {
            yield return value;
        }
    }

    public class Int64MaskCounter : BaseMaskCounter<UInt64, UInt64>
    {
        protected override IEnumerable<UInt64> GetKnownMasks(UInt64 value)
        {
            for (UInt64 mask = (((UInt64)0x1) << 63); mask > 0; mask >>= 1)
            {
                yield return mask;
            }
        }
        protected override bool isMaskAHit(UInt64 mask, UInt64 maskable)
        {
            return (mask & maskable) != 0;
        }

        protected override IEnumerable<UInt64> GetMaskableValueElements(UInt64 value)
        {
            yield return value;
        }
    }

    public class ByteMaskCounter : BaseMaskCounter<byte, byte[]>
    {
        protected override IEnumerable<byte> GetKnownMasks(byte[] value)
        {
            for (byte mask = (((byte)0x1) << 7); mask > 0; mask >>= 1)
            {
                yield return mask;
            }
        }
        protected override bool isMaskAHit(byte mask, byte maskable)
        {
            return (mask & maskable) != 0;
        }

        protected override IEnumerable<byte> GetMaskableValueElements(byte[] value)
        {
            return value;
        }
    }

    /// <summary>
    /// note : this is not thread safe
    /// </summary>
    public class BigIntegerCounter : BaseMaskCounter<BigInteger, BigInteger>
    {
        protected override IEnumerable<BigInteger> GetKnownMasks(BigInteger value)
        {
            for (BigInteger mask = ((BigInteger.One) << getMinimumCardinality(value,1)); mask > BigInteger.Zero; mask >>= 1)
            {
                yield return mask;
            }
        }
        protected override bool isMaskAHit(BigInteger mask, BigInteger maskable)
        {
            return (mask & maskable) != BigInteger.Zero;
        }
        protected override IEnumerable<BigInteger> GetMaskableValueElements(BigInteger value)
        {
            yield return value;
        }

        protected override bool AreMaskPresent(BigInteger value)
        {
            var masks =this.masks;
            return null!=masks && !(masks.Length > getMinimumCardinality(value, masks.Length));
        }

        /// <summary>
        /// Get minimum cardinality of the masks such to cover all elements of the element
        /// </summary>
        /// <param name="minimumCardinality">minimum known cardinality</param>
        /// <param name="value">value to cover by masks</param>
        private int getMinimumCardinality(BigInteger value, int minimumCardinality)
        {
            BigInteger mask = BigInteger.One << minimumCardinality;
             while(value > mask)
             {
                 mask<<=1;
                 minimumCardinality ++;
             }
             return minimumCardinality;
        }
    }
}


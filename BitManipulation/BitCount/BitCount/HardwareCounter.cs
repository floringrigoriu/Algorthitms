using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace BitCount
{
    /// <summary>
    /// count bits by doing mask manipulation
    /// </summary>
    public class HardwareCounter : IBitCounter
    {
        [DllImport("unmanaged.exe")]
        static extern int AsmPopulationCount(uint num);

        [DllImport("unmanaged.exe")]
        static extern int AsmPopulationCount64(UInt64 num);

        [DllImport("unmanaged.exe")]
        static extern int AsmPopulationCountArray(byte[] data, int size);


        
        public uint Count(uint value)
        {
            return (uint)AsmPopulationCount(value);
        }

        public uint Count(UInt64 value)
        {
            return (uint)AsmPopulationCount64(value);
        }

        public uint Count(BigInteger value)
        {
            var input = value.ToByteArray();
            return (uint)AsmPopulationCountArray(input, input.Length / 4);
        }


        public uint Count(byte[] value)
        {
            return (uint)AsmPopulationCountArray(value, value.Length);
        }
    }
}



namespace BitCount
{
    /// <summary>
    /// This class provide access to parity information instead of pupulation
    /// </summary>
    public class ParityCounter : IBitCounter
    {
        private IBitCounter pupulationCounter = new ModuloBitCounter();

        public uint Count(uint value)
        {
            return pupulationCounter.Count(value) % 2;
        }

        public uint Count(ulong value)
        {
            return pupulationCounter.Count(value) % 2;
        }

        public uint Count(System.Numerics.BigInteger value)
        {
            return pupulationCounter.Count(value) % 2;
        }

        public uint Count(byte[] value)
        {
            int result = 0;
            foreach (byte element in value)
            {
                result ^= element;
            }

            return this.pupulationCounter.Count(result) % 2;
        }
    }
}

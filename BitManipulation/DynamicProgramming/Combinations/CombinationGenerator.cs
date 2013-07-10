using System.Diagnostics.Contracts;

namespace Combinations
{
    /// <summary>
    /// Utility to generate Combinations
    /// </summary>
    public class CombinationGenerator
    {
        /// <summary>
        /// Maximum N supported to get combinations
        /// </summary>
        const int MaxN = 1000;

        public uint GetCombinations(uint n, uint k)
        {
            Contract.Assert(n > 0);
            Contract.Assert(n >= k);
            Contract.Assert(n < MaxN);

            // build last line (identified by variable level) 
            // of the Pascal Triange (https://en.wikipedia.org/wiki/Pascal's_triangle) (hexa):
            //
            //                   1
            //                  1 1
            //                 1 2 1
            //                1 3 3 1
            //               1 4 6 4 1
            //              1 5 A A 5 1
            //             1 6 F . F 6 1
            //            1 7 . . . . 7 1
            //
            uint[] resultSet = new uint[n + 1];
            resultSet[0] = 1;
            for (uint level = 1; level <= n; level++)
            {
                resultSet[level] = 1;
                for (uint index = level - 1; index > 0; index--)
                {
                    resultSet[index] += resultSet[index - 1];
                }
            }
            
            // return the combinations as corresponding column in 
            return resultSet[k];
        }
    }
}

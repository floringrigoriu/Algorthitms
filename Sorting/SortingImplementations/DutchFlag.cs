using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SortingImplementations
{
    /// <summary>
    /// support for Dutch flag organization
    /// an array will be split in 3 section 
    /// >> smaler than a target
    /// >> equal to a target
    /// >> bigger than the target
    /// </summary>
    /// <remarks>this organization improves performance of quick sort of arrays with many duplicates</remarks>
    public class DutchFlag
    {
        /// <summary>
        /// Dutch flag for the input with defaulting to 0 for start and full array as end
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="input">input array</param>
        /// <param name="target">middle of dutch flag</param>
        /// <param name="lower">lower boundary - defaulted to 0 [inclusive]</param>
        /// <returns>tupple with the boundaries between the 3 sections of the flag</returns>
        /// <remarks>inline for perfomance</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Tuple<int, int> DutchPartition<T>(T[] input, T target, IComparer<T> comparer, int lower = 0)
        {
            return DutchPartition<T>(input, target,comparer, lower, input.Length-1);
        }

        /// <summary>
        /// Dutch flag for the input
        /// </summary>
        /// <typeparam name="T">type of array elements</typeparam>
        /// <param name="input">input array</param>
        /// <param name="target">middle of dutch flag</param>
        /// <param name="lower">lower boundary - inlusive </param>
        /// <param name="upper">upper boundary - inclusive </param>
        /// <returns>tupple with the boundaries between the 3 sections of the flag</returns>
        public static Tuple<int, int> DutchPartition<T>(T[] input, T target, IComparer<T> comparer, int lower, int upper)
        {
            // implementation concat smaller elements to lower part, 
            // concat bigger elemments to upper part of the arry
            // override middle with target

            // where read/write low
            var writeLow = lower;
            var readLow = lower;

            // where read/write high
            var writeUpper = upper;
            var readUpper = upper;

            while (readLow < readUpper)
            {
                while (comparer.Compare(input[readLow],target) <=0 && readLow <= readUpper)
                {
                    if (comparer.Compare(input[readLow], target) != 0)
                    {
                        input[writeLow] = input[readLow];
                        writeLow++;
                    }
                    readLow++;
                }

                while (comparer.Compare(input[readUpper], target) >= 0 && readLow <= readUpper)
                {
                    if (comparer.Compare(input[readUpper], target) != 0)
                    {
                        input[writeUpper] = input[readUpper];
                        writeUpper--;
                    }
                    readUpper--;
                }

                if (readLow < readUpper) 
                {
                    var temp = input[readLow];
                    input[readLow] = input[readUpper]; ;
                    input[readUpper] = temp;
                }
            }


            for (int index = writeLow; index <=writeUpper; index++)
            {
                input[index] = target;
            }

            return new Tuple<int, int>(writeLow, writeUpper);
        }
        
    }
}

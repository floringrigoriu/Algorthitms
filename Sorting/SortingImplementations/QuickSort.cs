using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SortingImplementations
{
    public class QuickSort<T>
    {
        private static Random randomGenerator = new Random();

        private static int RandomSelect(int lower, int upper)
        {
            return randomGenerator.Next(lower, upper + 1); // inclusive boundaries
        }

        public QuickSort(Func<int, int, T[], T, Tuple<int, int>> partitioner, Func<int, int, int> selector = null)
        {
            this.TargetSelection = selector ?? RandomSelect;
            this.Partition = partitioner;
        }

        public QuickSort(IComparer<T> comparer)
        {
            this.TargetSelection = RandomSelect;
            this.Partition = (int lower, int upper, T[] input, T target)=>{
                while (lower < upper)
                {
                    while (lower < upper && comparer.Compare(input[lower], target) <0)
                    {
                        lower++;
                    }

                    while (lower < upper && comparer.Compare(input[upper], target) >= 0)
                    {
                        upper--;
                    }
                    if (lower < upper)
                    {
                        var aux = input[lower];
                        input[lower] = input[upper];
                        input[upper] = aux;
                    }
                }
                    
                return new Tuple<int, int>(lower, 
                    comparer.Compare(input[lower],target) == 0 ? lower: lower -1); // no middle if lower != target
                };
        }

        /// <summary>
        /// quick sort :
        /// </summary>
        /// <param name="input">array to sort</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Sort(T[] input)
        {
            Sort(input, 0, input.Length - 1);
        }


        /// <summary>
        /// quick sort :
        /// - pick target
        /// - do partition 
        /// - do recursion for smaller partition
        /// - do iteration for bigger partition
        /// </summary>
        /// <param name="input">array to sort</param>
        /// <param name="lower">upper boundary</param>
        /// <param name="upper">lower boundary</param>
        public void Sort(T[] input,int lower, int upper)
        {
            while (lower < upper) // input not already sorted
            {

                // pick target
                T target = input[this.TargetSelection(lower, upper)];

                // partition it
                var partition = this.Partition(lower, upper, input, target);

                // skip middle but do recursion on smaller sub array;
                if (partition.Item1 - lower > upper - partition.Item2)
                {
                    Sort(input, partition.Item2 + 1, upper);
                    upper = partition.Item1 - 1;
                }
                else
                {
                    Sort(input, lower, partition.Item1 - 1);
                    lower = partition.Item2 + 1;
                }
            }
        }

        /// <summary>
        /// selection - given a lower, upper bondary, do select partition element
        /// </summary>
        public Func<int, int, int> TargetSelection { get; private set; }

        /// <summary>
        /// for upper,lower, array
        /// </summary>
        public Func<int , int, T[], T , Tuple<int, int>> Partition { get; private set; }
    }
}

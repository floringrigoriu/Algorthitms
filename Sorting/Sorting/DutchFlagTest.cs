using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingImplementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    [TestClass]
    public class DutchFlagTest
    {
        [TestMethod]
        public void TestPartition()
        {
            //get input
            int testSize = 1000;
            int lowSize = 300;
            int uppSize = 400;
            int low = 2;
            int middle = 3;
            int upper = 4;
            int[] input = GetInput<int>(testSize, lowSize, uppSize, low, middle, upper);
            
            // apply dutch flag sorting
            var result = DutchFlag.DutchPartition<int>(input, middle, new IntComparer()); 

            // veryfi
            Assert.AreEqual<int>(lowSize ,result.Item1);
            Assert.AreEqual<int>(uppSize + result.Item2 + 1, input.Length);
            for (int index = 0; index < lowSize; index++)
            {
                Assert.AreEqual<int>(low, input[index], "invalid lower @ {0} : {1}", index , input[index]);
            }

            for (int index = result.Item1; index <= result.Item2; index++)
            {
                Assert.AreEqual<int>(middle, input[index], "invalid middle @ {0} : {1}", index, input[index]);
            }

            for (int index = result.Item2+1; index < input.Length; index++)
            {
                Assert.AreEqual<int>(upper, input[index], "invalid upper  @ {0} : {1}", index, input[index]);
            }
        }

        [TestMethod]
        public void TestSorting()
        {
            //get input
            int testSize = 1000;
            int batchSize = 100;
            int[] input = GetInput(testSize, batchSize);
            int[] quickSortInput = (int [])input.Clone();
            int[] duthcQuickSortInput = (int[])input.Clone();
            
            // do the sorting
            var sortedControlResult = input.OrderBy(v=>v);

            var qs = new QuickSort<int>(new IntComparer());
            qs.Sort(quickSortInput);


            var dflagSort = new QuickSort<int>((int low, int up, int[] i, int target) =>
                DutchFlag.DutchPartition<int>(i, target, new IntComparer(), low, up));
            dflagSort.Sort(duthcQuickSortInput);

            // validate
            Assert.IsTrue(sortedControlResult.SequenceEqual(quickSortInput));
            Assert.IsTrue(sortedControlResult.SequenceEqual(duthcQuickSortInput));
        }

        private int[] GetInput(int testSize, int batchSize)
        {
            // get a sorted array with many duplicates
            int[] result = new int[testSize];
            for (int i = 0; i <= testSize / batchSize; i++)
            {
                for (int j = 0; j < batchSize && i*batchSize + j < testSize; j++)
                {
                    result[i * batchSize + j] = i;
                }
            }

            Random rnd = new Random();
            // randomize it
            for (int i = 0; i < result.Length; i++)
            {
                int target = rnd.Next(0, result.Length);
                int aux = result[target];
                result[target] = result[i];
                result[i] = aux;
            }
            return result;
        }


        private T[] GetInput<T>(int testSize, int lowSize, int uppSize, T low, T middle, T upper)
        {
            // Create a duthc flag
            //
            T[] result = new T[testSize];
            for (int index = 0; index < lowSize; index++)
            {
                result[index] = low;
            }

            for (int index = lowSize; index < testSize - uppSize ; index++)
            {
                result[index] = middle;
            }

            for (int index = testSize - uppSize; index < testSize ; index++)
            {
                result[index] = upper;
            }

            // randomize it
            //
            Random randomizer = new Random();
            for (int index = 0; index < testSize; index++)
            {
                var randomTarget = randomizer.Next(0, testSize);
                T aux = result[randomTarget];
                result[randomTarget] = result[index];
                result[index] = aux;
            }
            return result;
        }

        /// <summary>
        /// implementation of comparer for .net is missing - so adding a custom implementation, using 
        /// the fact int.32 expands IComparable<int>
        /// </summary>
        private class IntComparer:IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }
    }
}

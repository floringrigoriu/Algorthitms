using System.Collections.Generic;

namespace Combinations
{
    public class PowerSet
    {
        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(IEnumerable<T> input)
        { 
            // to do : add validations
            Dictionary<int, T> set = new Dictionary<int, T>();
            int elementId = 0;
            foreach (var element in input)
            {
                set.Add(elementId, element);
                elementId++;
            }

            for (int index = 0; index < 0x1 << set.Count; index++)
            {
                yield return GetSubset(index, set);
            }
        }

        private static IEnumerable<T> GetSubset<T>(int index, Dictionary<int, T> set)
        {
            for (int elementID = 0; (index >> elementID) > 0; elementID++)
            {
                if ((index >> elementID) % 2 == 1)
                {
                    yield return set[elementID];
                }
            }
        }
    }
}

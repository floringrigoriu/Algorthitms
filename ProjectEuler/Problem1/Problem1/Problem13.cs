using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Problem13:IProblem<string>
    {
         const int firstK = 10;

        public string Description
        {
            get { return "Work out the first ten digits of the sum of the following one-hundred 50-digit numbers"; }
        }

        public long Solve(string limit)
        {
            IList<IList<byte>> vectors = ParsingUtils.ParseVector(limit);
            var reversed = vectors.Select(v => v.Reverse()).ToList(); // little endian
            IList<byte> result = new List<byte>();
            int carry = 0; int index = 0;
            do
            {
                var completedList = new List<IEnumerable<byte>>();
                foreach (var list in reversed)
                {
                    if (list.Count() > index)
                    {
                        carry += list.ElementAt(index);
                    } else {
                        completedList.Add(list);
                    }
                }
                foreach (var list in completedList) {
                    reversed.Remove(list);
                }

                result.Add((byte)(carry % 10));
                carry /= 10;
                index++;
            } while (carry != 0 || reversed.Count() != 0);

            return result.Reverse().Take(firstK).Aggregate(0L, (agg,current) =>  10L * agg + current);
        }
    }
}

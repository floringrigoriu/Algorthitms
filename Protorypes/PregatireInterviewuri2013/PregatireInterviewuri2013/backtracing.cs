using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatireInterviewuri2013
{
    /// <summary>
    /// Add comment for this thingie :-)
    /// </summary>
    public class backtracking
    {
        public static IEnumerable<string> GetPermutations(string input)
        {
            if (String.IsNullOrEmpty(input) || input.Length == 1)
            {
                yield return input;
            }
            else 
            {
                  foreach (var remaining in GetPermutations(input.Substring(1,input.Length - 1)))
                    {
                        for (int count = 0; count <= remaining.Length; count++)
                        {
                  
                            yield return remaining.Substring(0,count) + input[0] + (count < input.Length ?
                                remaining.Substring(count) :String.Empty);
                        }
                    }
            }
        }
    }
}

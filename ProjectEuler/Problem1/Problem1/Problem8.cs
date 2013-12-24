using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem_8:IProblem<string>
    {
        const int bufferSize = 5; 

        public string Description
        {
            get { return "Find the greatest product of five consecutive digits in the 1000-digit number"; }
        }

        public long Solve(string input)
        {
            
            var accumulator = new Queue<int>(input.Take(bufferSize).Select(c=>int.Parse(c.ToString())));
            long result  = accumulator.Aggregate(1, (acc, cur) => acc * cur);
            
            foreach (var c in input.Skip(bufferSize))
            {
                result = Math.Max(result, accumulator.Aggregate(1, (acc, cur) => acc * cur));
                accumulator.Dequeue();
                accumulator.Enqueue(int.Parse(c.ToString()));
            }
            
            return result;
        }
    }
}

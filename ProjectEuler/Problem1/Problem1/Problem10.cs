using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem10:IProblem<long>, IProgress
    {
        const long progressUpdateSteps = 100;
        Action<int> progressUpdater = null;
        Action progressCompleter = null;

        public string Description
        {
            get
            {
                return
                    @"The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
Find the sum of all the primes below two million";
            }
        }

        public long Solve(long limit)
        {
            long result = 0;
            long last = 0;
            long chunkSize = limit / progressUpdateSteps;
            
            foreach (var prime in Utils.PrimeUtils.GetPrimes())
            {
                if(prime > limit)
                {
                    break;
                }
                result += prime;
                if(prime / chunkSize != last / chunkSize)
                {
                    this.ProgressUpdated(this, (int)(prime / chunkSize));
                }
                last = prime;
            }

            this.ProgressCompleted(this, EventArgs.Empty);
            return result;
        }

        public int Max
        {
            get { return (int) progressUpdateSteps; }
        }

        public event EventHandler<int> ProgressUpdated;

        public event EventHandler ProgressCompleted;
    }
}

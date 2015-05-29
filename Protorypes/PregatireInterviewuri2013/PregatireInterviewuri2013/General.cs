using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatireInterviewuri2013
{
    public class General
    {
        public const int NotFound = -1;
        public const int InvalidInput = -2;
        public const int OutOfRangeValues = 3;

        /// <summary>
        /// Remove identify a from an array with values from 1..100
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int []input)
        { 
            if(input == null)
            {
                return InvalidInput;
            }
            var elements = new HashSet<int>();
            foreach (var number in input)
            {
                if (number > 100 || number < 1) 
                {
                    return OutOfRangeValues;
                }
                if (elements.Contains(number))
                {
                    return number;
                }
                elements.Add(number);
            }
            return NotFound;
        }
    }
}

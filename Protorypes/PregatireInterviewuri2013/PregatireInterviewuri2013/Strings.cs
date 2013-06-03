using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatireInterviewuri2013
{
    public class Strings
    {
        public static string Reverse1(string input)
        {
            if (input == null)
            {
                throw new Exception("invalid input");
            }
            var elements = input.Split(' ');
            return String.Join(" ",
                elements.Select(e=>new String(e.ToCharArray().Reverse().ToArray())));
        }

        public static string Reverse2(string input)
        {
            if (input == null)
            {
                throw new Exception(":-(");
            }
            StringBuilder result = new StringBuilder();
            var word = new Stack<char>();
            foreach (var ch in input)
            {
                if (ch == ' ')
                {
                    Flush(result, word);
                    result.Append(ch);
                }
                else 
                {
                    word.Push(ch);
                }
            }
            Flush(result, word);

            return result.ToString();
        }

        private static void Flush(StringBuilder result, Stack<char> word)
        {
            while (word.Count != 0)
            {
                result.Append(word.Pop());
            }
        }

    }
}

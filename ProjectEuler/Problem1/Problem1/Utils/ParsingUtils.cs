using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Utils
{
    public class ParsingUtils
    {
        private static char[] splitter = " \r\n".ToCharArray();

        public static int[,] ParseString(string input)
        {
            var segments = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            int lenght = (int)Math.Sqrt(segments.Length);
            if (lenght * lenght != segments.Length) { throw new Exception("not a square matrix inputted"); }
            int[,] result = new int [lenght,lenght];
            for (int i = 0; i < lenght; i++)
                for (int j = 0; j < lenght; j++) { result[i,j] = int.Parse(segments[i * lenght + j]);}
            return result;
        }

        public static IList<IList<byte>> ParseVector(string input)
        {
            var result = new List<IList<byte>>();
            IList<byte> currentList = new List<byte>();
            foreach (var ch in input)
            {
                if (char.IsDigit(ch))
                {
                    if (currentList.Count == 0)
                    {
                        result.Add(currentList);
                    }
                    currentList.Add((byte)(ch - '0'));
                }
                else if (ch == '\r' || ch == '\n')
                {
                    currentList = new List<byte>();
                }
                else 
                {
                    throw new ArgumentException("ch");
                }
            }
            return result;
        }
    }
}

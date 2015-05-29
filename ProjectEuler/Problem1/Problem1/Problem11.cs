using Problem1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Problem11:IProblem<string>
    {
        int streamLength = 4;

        public string Description
        {
            get { return "What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?"; }
        }

        public long Solve(string input)
        {
            var matrix = ParsingUtils.ParseString(input);
            var length = matrix.GetLength(0);
            long result = 0;
            foreach (IEnumerable<int> stream in GetStreams(matrix))
            {
                Queue<int> q = new Queue<int>(stream.Take(streamLength));
                
                if(q.Count == streamLength)
                {
                    result = Math.Max(result, q.Aggregate(1, (a, el) => a * el));
                    foreach (var element in stream)
                    {
                        q.Dequeue(); q.Enqueue(element);
                        result = Math.Max(result, q.Aggregate(1, (a, el) => a * el));
                    }
                }
            }
            return result;
        }

        private IEnumerable<IEnumerable<int>> GetStreams(int[,] matrix)
        {
            for (int c = 0; c < matrix.GetLength(0); c++)
            {
                yield return GetColumn(matrix, c);
            }

            for (int r = 0; r < matrix.GetLength(1); r++)
            {
                yield return GetRow(matrix, r);
            }

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                yield return GetDiagonal(matrix, c, 0, 1, 1);
                yield return GetDiagonal(matrix, c, 0, -1, 1);
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                yield return GetDiagonal(matrix, 0, r, 1, 1);
                yield return GetDiagonal(matrix, matrix.GetLength(1), r, -1, 1);
            }
        }

        private IEnumerable<int> GetRow(int[,] matrix, int r)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                yield return matrix[i , r];
            }
        }

        private IEnumerable<int> GetColumn(int[,] matrix, int column)
        { 
            for(int i=0; i<matrix.GetLength(1);i++)
            {
                yield return matrix[column, i];
            }
        }

        private IEnumerable<int> GetDiagonal(int[,] matrix, int startX, int startY, int deltaX, int deltaY)
        {
            while (startX >= 0 && startY >= 0 && startY < matrix.GetLength(0) && startX < matrix.GetLength(1))
            {
                yield return matrix[startY, startX];
                startX += deltaX;
                startY += deltaY;
            }
        }
    }
}

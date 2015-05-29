using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{

    /// <summary>
    /// go over the maze, get a path if exists
    /// </summary>
    public class MazeSolver
    {
        /// <summary>
        /// get path - using A*
        /// </summary>
        /// <typeparam name="N">Type of graph node</typeparam>
        /// <typeparam name="E">Type of edge node</typeparam>
        /// <param name="maze">maze as a matrix</param>
        /// <param name="startX">start x</param>
        /// <param name="startY">start y</param>
        /// <param name="endX">end x</param>
        /// <param name="endY">end y</param>
        public IEnumerable<GraphNode<N,E>> Solve<N,E>(GraphNode<N, E>[,] maze, int startX, int startY, int endX, int endY) 
        {
            if (startX < 0 || endX < 0 || startY < 0 || endY < 0
                || startX > maze.GetLength(0) || endX > maze.GetLength(0)
                || startY > maze.GetLength(1) || endY > maze.GetLength(1))
            {
                throw new ArgumentOutOfRangeException();
            }

            // TO Do : replace with priority queue
            var ancestor = new Dictionary<GraphNode<N, E>, GraphNode<N, E>>();
            var candidate = new Dictionary<GraphNode<N, E>,int>();
            var visited = new HashSet<GraphNode<N, E>>();
            candidate.Add(maze[startX, startY],0);
            while(candidate.Count!=0 && !visited.Contains(maze[endX,endY]))
            {
                var closestValue = candidate.Min(kvp => kvp.Value);
                var closestElement = candidate.First(kvp=>kvp.Value == closestValue);
                candidate.Remove(closestElement.Key);
                visited.Add(closestElement.Key);
                foreach (var links in closestElement.Key.Neighbours)
                {
                    if (visited.Contains(links.Key))
                    {
                        continue;
                    }
                    if (!candidate.ContainsKey(links.Key) || candidate[links.Key] > closestElement.Value + 1)
                    {
                        candidate[links.Key] = closestElement.Value + 1;
                        ancestor[links.Key] = closestElement.Key;
                    }
                }
            }
            // return result 
            if (!visited.Contains(maze[endX, endY]))
            {
                yield break;
            }
            else 
            {
                var current = maze[endX,endY];
                yield return current;
                while (current != maze[startX, startY])
                {
                    current = ancestor[current];
                    yield return current;
                }
            }
        }
    }
}

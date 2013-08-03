using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Generate a maze 
    /// </summary>
    public class MazeGenerator
    {
        /// <summary>
        /// Generate a maze
        /// </summary>
        /// <param name="lenght">lenght</param>
        /// <param name="heigh">heigh</param>
        /// <param name="loops">number of loops in the maze , by default == 0</param>
        /// <returns>a matrix representing the maze</returns>
        public GraphNode<MazeNode, int>[,] GetMaze(int lenght, int heigh, int loops = 0)
        { 
            // generate result matrix
            GraphNode<MazeNode, int>[,] result =  new GraphNode<MazeNode, int>[heigh,lenght];
            
            for(int i = 0;  i < lenght; i++)
            {
                for(int j=0;j<heigh;j++)
                {
                    result[j,i] = new NonDirectedGraph<MazeNode,int>()
                    { Value = new MazeNode()
                    { X =i, Y = j, Type = CellType.empty}};
                }
            }

            // randomly connect it
            Random rnd = new Random();
            // connect lines
            for(int i=0; i<lenght -1 ;i++)
            {
                for(int j=0; j<heigh;j++)
                {
                    result[j,i].AddNeightbour(result[j,i+1],rnd.Next());
                }
            }
            // connect columns
            for(int i=0; i<lenght;i++)
            {
                for(int j=0; j<heigh -1;j++)
                {
                    result[j,i].AddNeightbour(result[j+1,i],rnd.Next(1,Int16.MaxValue));
                }
            }

            // Generate maze by selecting minimum arches
            HashSet<GraphNode<MazeNode,int>> visited = new HashSet<GraphNode<MazeNode,int>>();

            var arches = result.
                Cast<GraphNode<MazeNode, int>>().
                SelectMany(n=>n.Neighbours.Select(l=> new {Start =n, End =l.Key, Lenght = l.Value})).
                OrderByDescending(a=>a.Lenght).
                ToList();

            var first = arches.First();
            visited.Add(first.Start);
            visited.Add(first.End);
            first.Start.Neighbours[first.End] = 0; // connection marked for keeping
            first.End.Neighbours[first.Start] = 0; // connection marked for keeping

            while(visited.Count < lenght * heigh  && arches.Any())
            {
                foreach (var arch in arches)
                {
                    if ((!visited.Contains(arch.Start)) ^ (!visited.Contains(arch.End)))
                    {
                        visited.Add(arch.Start);
                        visited.Add(arch.End);
                        arch.Start.Neighbours[arch.End] = 0; // connection marked for keeping
                        arch.End.Neighbours[arch.Start] = 0; // connection marked for keeping
                        arches.Remove(arch);
                        break;
                    }
                }
            }

            // add loops
            while (loops > 0 && arches.Any())
            {
                var arch = arches.ElementAt(0);
                arches.RemoveAt(0);
                if (arch.Start.Neighbours[arch.End] != 0)
                {
                    // connection marked for keeping
                    arch.Start.Neighbours[arch.End] = 0;
                    arch.End.Neighbours[arch.Start] = 0;
                    loops--;
                }
            }

            foreach (var cell in result)
            {
                foreach (var kvp in cell.Neighbours.ToList())
                { 
                    // removed neighbours with arches >0
                    if (kvp.Value > 0)
                    {
                        cell.RemoveNeightbour(kvp.Key);
                    }
                }
            }

            // add start,end

            var start = visited.ElementAt(rnd.Next(visited.Count));
            start.Value.Type = CellType.start;
            visited.Remove(start);

            var end = visited.ElementAt(rnd.Next(visited.Count));
            end.Value.Type = CellType.end;
            visited.Remove(end);

            return result;
        }
    }

    public class MazeNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellType Type { get; set; }
    }

    public enum CellType
    {
        empty,
        start,
        end
    }
}

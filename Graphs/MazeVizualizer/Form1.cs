using Graphs;
using Maze;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeVizualizer
{
    public partial class Form1 : Form
    {
        Maze.MazeGenerator generator;

        public Form1()
        {
            InitializeComponent();
            generator = new Maze.MazeGenerator();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var maze = this.generator.GetMaze(
                int.Parse(this.toolStripTextBox2.Text),
                int.Parse(this.toolStripTextBox1.Text),
                int.Parse(this.toolStripTextBox3.Text)
                );
            var mazeString = new String[maze.GetLength(1),maze.GetLength(0)];
            GraphNode<MazeNode,int> start = null;
            GraphNode<MazeNode,int> end = null;

            for(int i=0;i<maze.GetLength(1) ;i++)
            {
                for(int j=0;j<maze.GetLength(0);j++)
                {
                    var mazeCell = maze[j,i];
                    var strCell = String.Empty;
                    switch(mazeCell.Value.Type)
                    {
                        case Maze.CellType.start : strCell = "S"; start = mazeCell; break;
                        case Maze.CellType.end : strCell = "E";end = mazeCell ; break;
                        case Maze.CellType.empty : strCell = "";break;
                        default : throw new Exception("Unsuported cell type:" + mazeCell.Value.Type);
                    }
                    
                    foreach(var n in mazeCell.Neighbours)
                    {
                        if(mazeCell.Value.X ==n.Key.Value.X)
                        {
                            if(mazeCell.Value.Y == n.Key.Value.Y +1)
                            {
                                strCell+="↑";
                            }
                            else if(mazeCell.Value.Y == n.Key.Value.Y -1)
                            {
                                strCell +="↓" ;
                            }
                            else
                            {
                                strCell+="?";
                            }
                        }
                        else if(mazeCell.Value.Y ==n.Key.Value.Y)
                        {
                            if(mazeCell.Value.X == n.Key.Value.X +1)
                            {
                                strCell+="←";
                            }
                            else if(mazeCell.Value.X == n.Key.Value.X -1)
                            {
                                strCell +="→" ;
                            }
                            else
                            {
                                strCell+="?";
                            }
                        }
                        else
                        {
                            strCell+="?";
                        }
                    }

                    mazeString[i,j] = strCell;
                }
            }

            // solve it
            
            var mazeSolver = new MazeSolver();
            var path =  mazeSolver.Solve(maze,start.Value.X , start.Value.Y,end.Value.X,end.Value.Y).ToList();

            // do display it
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DefaultCellStyle.Font =
                new System.Drawing.Font("Lucida Sans Unicode", 10F,
                                     System.Drawing.FontStyle.Regular,
                                     System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
            for(int index=0;index<mazeString.GetLength(0);index++)
            {
                this.dataGridView1.Columns.Add(index.ToString(),index.ToString());
            }
            this.dataGridView1.SuspendLayout();
            for(int index=0;index<mazeString.GetLength(1);index++)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = index.ToString();
                for(int i=0;i<mazeString.GetLength(0);i++)
                {
                    var cell = new DataGridViewTextBoxCell() { Value = mazeString[i, index] };
                    row.Cells.Add(cell);
                    if(path.Any(p=>p.Value.X == index && p.Value.Y == i))
                    {
                        cell.Style.BackColor = Color.Green;
                    }
                }
                this.dataGridView1.Rows.Add(row);
                
            }
            this.dataGridView1.ResumeLayout(true);
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

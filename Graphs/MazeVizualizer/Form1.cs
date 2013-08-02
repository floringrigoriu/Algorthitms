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
            var maze = this.generator.GetMaze(int.Parse(this.toolStripTextBox2.Text),int.Parse(this.toolStripTextBox1.Text));
            var mazeString = new String[maze.GetLength(1),maze.GetLength(0)];
            for(int i=0;i<maze.GetLength(1) ;i++)
            {
                for(int j=0;j<maze.GetLength(0);j++)
                {
                    var mazeCell = maze[j,i];
                    var strCell = String.Empty;
                    switch(mazeCell.Value.Type)
                    {
                        case Maze.CellType.start : strCell = "S";break;
                        case Maze.CellType.end : strCell = "E";break;
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
            
            // do display it
            var dataSet = new string[mazeString.GetLength(1)][];
            for(int i=0;i<dataSet.Length;i++)
            {
                dataSet[i] = new String[mazeString.GetLength(0)];
                for (int j = 0; j < dataSet[i].Length; j++)
                {
                    dataSet[i][j] = mazeString[j, i];
                }
            }
            //this.dataGridView1.DataSource = dataSet;
        }
    }
}

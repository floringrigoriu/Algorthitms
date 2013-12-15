using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Problem1
{
    public partial class Form1 : Form
    {
        public delegate void UIUpdater(long r, Cursor c);
        IProblem problem = null;

        public Form1()
        {
            InitializeComponent();
            int index =0;
            foreach (var p in this.GetProblems())
            { 
                var problemToolStripMenuItem = new ToolStripMenuItem(p.GetType().Name);
                problemToolStripMenuItem.Tag = p;
                problemToolStripMenuItem.Click += new System.EventHandler(this.problemStripMenuItem_Click);
                this.operationsToolStripMenuItem.DropDownItems.Insert(index++, problemToolStripMenuItem);
            }
            this.DescriptionLabel.Text = "select a probem...";
        }

        IEnumerable<IProblem> GetProblems(){
            var parrentAssemblies = this.GetType().Assembly;
            var problemTypes = parrentAssemblies.
                GetTypes().
                Where(t => t.IsClass && !t.IsAbstract && typeof(IProblem).IsAssignableFrom(t));
            var problems = problemTypes.
                Select(t => t.GetConstructor(Type.EmptyTypes)).
                Where(c=> c!=null).
                Select(c=>(IProblem)c.Invoke(new Object[0]));
            return problems;
        }

        private void ComandbButton_Click(object sender, EventArgs e)
        {
            if (this.problem == null)
            {
                MessageBox.Show("do select a problem from the <<Operations>> menu");
                return;
            }
            long size = long.Parse(this.SizeTextBox.Text);
            var currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var task = new Task<long>(()=>size);
            var cont = task.ContinueWith<long>((r) => this.problem.Solve(r.Result))
               .ContinueWith(r =>
                {
                    this.Invoke(new UIUpdater(this.UpdateUI), r.Result,  currentCursor);
                },TaskScheduler.FromCurrentSynchronizationContext()
              );

            task.Start(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void UpdateUI(long r , Cursor c)
        {
            this.ResultLabel.Text = r.ToString();
            this.Cursor = c;
        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void problemStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = ((ToolStripMenuItem)sender);
            foreach (ToolStripItem i in this.operationsToolStripMenuItem.DropDownItems) {
                var m = i as ToolStripMenuItem;
                if (null != m)
                {
                    m.Checked = false;
                }
            }
            menu.Checked = true;
            this.problem = (IProblem)menu.Tag;
            this.DescriptionLabel.Text = this.problem.Description;
        }
    }
}

﻿using System;
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
        public static IList<Type> suportedTypes = new List<Type>(){
            typeof(IProblem<long>),
            typeof(IProblem<string>)
        };
        public delegate void UIUpdater(long r, Cursor c);
        
        Func<string, object> parser = null;
        Func<object, long> solver = null;
        
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

        IEnumerable<Object> GetProblems(){
            var parrentAssemblies = this.GetType().Assembly;
            var problemTypes = parrentAssemblies.
                GetTypes().
                Where(t => t.IsClass && 
                    !t.IsAbstract &&
                    suportedTypes.Any(s=>s.IsAssignableFrom(t)));
            var problems = problemTypes.
                Select(t => t.GetConstructor(Type.EmptyTypes)).
                Where(c=> c!=null).
                Select(c=>c.Invoke(new Object[0]));
            return problems;
        }

        private void ComandbButton_Click(object sender, EventArgs e)
        {
            if (this.parser == null)
            {
                MessageBox.Show("do select a problem from the <<Operations>> menu");
                return;
            }
            Compute(this.parser(this.SizeTextBox.Text));
        }

        private void Compute<T>(T input)
        {
            var currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var task = new Task<object>(() => input);
            var cont = task.ContinueWith<object>((r) => this.solver(r.Result))
               .ContinueWith(r =>
               {
                   this.Invoke(new UIUpdater(this.UpdateUI), r.Result, currentCursor);
               }, TaskScheduler.FromCurrentSynchronizationContext()
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
            var problemSolver = menu.Tag;
            if(problemSolver is IProblem<long>) {
                DoSetup<long>(problemSolver, long.Parse);
            }
            else if (problemSolver is IProblem<String>)
            {
                DoSetup<string>(problemSolver, (i) => i);//string parser :-)
            }
            else 
            {
                throw new Exception(String.Format("type {0}", problemSolver.GetType()));
            }
        }

        private void DoSetup<T>(object p, Func<String,T> parser)
        {
            var problem = (IProblem<T>)p;
            this.parser = (string i) => { return parser(i); };
            this.DescriptionLabel.Text = problem.Description;
            this.solver = (object i) => problem.Solve((T)i);
        }
    }
}

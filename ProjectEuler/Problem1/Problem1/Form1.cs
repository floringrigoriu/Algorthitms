using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem1
{
    public partial class Form1 : Form
    {
        public delegate void UIUpdater(int r, Cursor c);
        Problem1 problem = new Problem1();

        public Form1()
        {
            InitializeComponent();;
            this.DescriptionLabel.Text = problem.Description;
        }

        private void ComandbButton_Click(object sender, EventArgs e)
        {
            int size = int.Parse(this.SizeTextBox.Text);
            var currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var task = new Task<int>(()=>size);
            var cont = task.ContinueWith<int>((r) => this.problem.Solve(r.Result))
               .ContinueWith(r =>
                {
                    this.Invoke(new UIUpdater(this.UpdateUI), r.Result,  currentCursor);
                },TaskScheduler.FromCurrentSynchronizationContext()
              );

            task.Start(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void UpdateUI(int r , Cursor c)
        {
            this.ResultLabel.Text = r.ToString();
            this.Cursor = c;
        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

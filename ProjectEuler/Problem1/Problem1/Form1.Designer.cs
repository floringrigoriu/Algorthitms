namespace Problem1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComandbButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.TextBox();
            this.ResultLabel = new System.Windows.Forms.TextBox();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computationProgress = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComandbButton
            // 
            this.ComandbButton.Location = new System.Drawing.Point(35, 157);
            this.ComandbButton.Name = "ComandbButton";
            this.ComandbButton.Size = new System.Drawing.Size(75, 23);
            this.ComandbButton.TabIndex = 0;
            this.ComandbButton.Text = "&Compute";
            this.ComandbButton.UseVisualStyleBackColor = true;
            this.ComandbButton.Click += new System.EventHandler(this.ComandbButton_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.Location = new System.Drawing.Point(32, 32);
            this.DescriptionLabel.Multiline = true;
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.ReadOnly = true;
            this.DescriptionLabel.Size = new System.Drawing.Size(221, 99);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description ";
            this.DescriptionLabel.Click += new System.EventHandler(this.DescriptionLabel_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.Location = new System.Drawing.Point(32, 207);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.ReadOnly = true;
            this.ResultLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResultLabel.Size = new System.Drawing.Size(221, 20);
            this.ResultLabel.TabIndex = 2;
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(133, 157);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SizeTextBox.TabIndex = 3;
            this.SizeTextBox.Text = "1000";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "&Operations";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // computationProgress
            // 
            this.computationProgress.Location = new System.Drawing.Point(32, 227);
            this.computationProgress.Name = "computationProgress";
            this.computationProgress.Size = new System.Drawing.Size(221, 23);
            this.computationProgress.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.computationProgress);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.ComandbButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Euler - Problem #1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ComandbButton;
        private System.Windows.Forms.TextBox DescriptionLabel;
        private System.Windows.Forms.TextBox ResultLabel;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ProgressBar computationProgress;
    }
}


namespace ZCP_3
{
    partial class LogSett
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
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnbrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(11, 29);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(133, 23);
            this.path.TabIndex = 1;
            // 
            // btnbrowse
            // 
            this.btnbrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbrowse.Image = global::ZCP_3._1.Properties.Resources.folder_search;
            this.btnbrowse.Location = new System.Drawing.Point(149, 34);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(16, 16);
            this.btnbrowse.TabIndex = 2;
            this.btnbrowse.TabStop = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interval:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(171, 29);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(87, 23);
            this.numericUpDown1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "ms";
            // 
            // fbd
            // 
            this.fbd.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // LogSett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 58);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnbrowse);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogSett";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autolog Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogSett_FormClosing);
            this.Load += new System.EventHandler(this.LogSett_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnbrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.PictureBox btnbrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}
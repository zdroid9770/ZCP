using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZCP_3
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        public Block block;
        public void Form2_Load(object sender, EventArgs e)
        {
            this.Text = block.name + " settings";
            procname.Text = block.procname;
            path.Text = block.path;
        }
        public void SetBlock(ref Block b) { block = b; }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            block.path = path.Text;
            block.procname = procname.Text;
            if (File.Exists(block.path)) { 
                block.write("Path specified!");
                //block.runpath = block.createshortcut();
            }
            
            if (block.procname != "") block.write("Process name specified!");
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            path.Text = ofd.FileName;
        }
    }
}

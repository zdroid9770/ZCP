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
    public partial class LogSett : Form
    {
        public LogSett()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            fbd.ShowDialog();
            path.Text = fbd.SelectedPath;

        }

        private void LogSett_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZCP_3._1.Properties.Settings.Default.logpath = path.Text;
            pathh = path.Text;
            intervall = Convert.ToInt32(numericUpDown1.Value);
        }
        public static string pathh;
        public static int intervall;
        private void LogSett_Load(object sender, EventArgs e)
        {
            path.Text = ZCP_3._1.Properties.Settings.Default.logpath;
            numericUpDown1.Value = ZCP_3._1.Properties.Settings.Default.loginterval;
        }
    }
}

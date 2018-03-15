using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ZCP_3._1;
using System.IO;


namespace ZCP_3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public int logw = 642;
        public int nonw = 418;
        public bool ext = false;
        Block world;
        Block mysql;
        Block logon;
        Block apache;
        public static DateTime now = DateTime.Now;
        private void Main_Load(object sender, EventArgs e)
        {
            timer.Start();
            if (ZCP_3._1.Properties.Settings.Default.autolog) ckbsave.Checked = true;
            ckbhide.Checked = ZCP_3._1.Properties.Settings.Default.hide;
            world = new Block(ZCP_3._1.Properties.Settings.Default.wpath, ZCP_3._1.Properties.Settings.Default.wproc, ref wbtn, ref wflag, ref wckb, ref log, "World", ref wtime);
            mysql = new Block(ZCP_3._1.Properties.Settings.Default.mpath, ZCP_3._1.Properties.Settings.Default.mproc, ref mbtn, ref mflag, ref mckb, ref log, "MySQL", ref mtime);
            logon = new Block(ZCP_3._1.Properties.Settings.Default.lpath, ZCP_3._1.Properties.Settings.Default.lproc, ref lbtn, ref lflag, ref lckb, ref log, "Logon", ref ltime);
            apache = new Block(ZCP_3._1.Properties.Settings.Default.apath, ZCP_3._1.Properties.Settings.Default.aproc, ref abtn, ref aflag, ref ackb, ref log, "Apache", ref atime);

        }

        public void CheckButtons()
        {
            if (!world.running) wbtn.Cursor = Cursors.Default;
            if (!logon.running) lbtn.Cursor = Cursors.Default;
            if (!mysql.running) mbtn.Cursor = Cursors.Default;
            if (!apache.running) abtn.Cursor = Cursors.Default;
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (ext)
            {
                ext = false;
                Width = nonw;
                grplog.Visible = false;
            }
            else
            {
                ext = true;
                Width = logw;
                grplog.Visible = true;
            }
        }

        private void wflag_Click(object sender, EventArgs e)
        {
            var sett = new Settings();
            sett.SetBlock(ref world);
            sett.ShowDialog();
        }

        private void lflag_Click(object sender, EventArgs e)
        {
            var sett = new Settings();
            sett.SetBlock(ref logon);
            sett.ShowDialog();
        }

        private void mflag_Click(object sender, EventArgs e)
        {
            var sett = new Settings();
            sett.SetBlock(ref mysql);
            sett.ShowDialog();
        }

        private void aflag_Click(object sender, EventArgs e)
        {
            var sett = new Settings();
            sett.SetBlock(ref apache);
            sett.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZCP_3._1.Properties.Settings.Default.wpath = world.path;
            ZCP_3._1.Properties.Settings.Default.wproc = world.procname;
            ZCP_3._1.Properties.Settings.Default.lpath = logon.path;
            ZCP_3._1.Properties.Settings.Default.lproc = logon.procname;
            ZCP_3._1.Properties.Settings.Default.mpath = mysql.path;
            ZCP_3._1.Properties.Settings.Default.mproc = mysql.procname;
            ZCP_3._1.Properties.Settings.Default.apath = apache.path;
            ZCP_3._1.Properties.Settings.Default.aproc = apache.procname;
            ZCP_3._1.Properties.Settings.Default.logpath = LogSett.pathh;
            ZCP_3._1.Properties.Settings.Default.loginterval = LogSett.intervall;
            ZCP_3._1.Properties.Settings.Default.autolog = ckbsave.Checked;
            ZCP_3._1.Properties.Settings.Default.hide = ckbhide.Checked;
            
            ZCP_3._1.Properties.Settings.Default.Save();
            if (System.IO.File.Exists(world.runpath)) System.IO.File.Delete(world.runpath);
            if (System.IO.File.Exists(logon.runpath)) System.IO.File.Delete(logon.runpath);
            if (System.IO.File.Exists(mysql.runpath)) System.IO.File.Delete(mysql.runpath);
            if (System.IO.File.Exists(apache.runpath)) System.IO.File.Delete(apache.runpath);
        }

        private void log_TextChanged(object sender, EventArgs e)
        {
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {

            LogSett logs = new LogSett();
            logs.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!ckbsave.Checked) return;
            StreamWriter sr = new StreamWriter((now.ToString() + ".txt").Replace(":", "."));
            for (int i = 0; i < log.Lines.Length; i++)
            {
                sr.WriteLine(log.Lines[i] + "\n");
            }
            
            sr.Flush();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            sfd.FileName = (now.ToString() + ".txt").Replace(":", ".");
            sfd.ShowDialog();
            StreamWriter sr = new StreamWriter(sfd.FileName);
            for (int i = 0; i < log.Lines.Length; i++)
            {
                sr.WriteLine(log.Lines[i] + "\n");
            }

            sr.Flush();
        }
    }
}

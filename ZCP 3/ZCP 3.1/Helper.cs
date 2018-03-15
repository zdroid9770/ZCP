using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace ZCP_3
{
    public class Block
    {
        public Block(string pa, string p, ref PictureBox b, ref PictureBox f, ref CheckBox c, ref RichTextBox r, string n, ref Label l)
        {
            timer = new System.Windows.Forms.Timer();
            ckb = c;
            log = r;
            name = n;
            procname = p;
            path = pa;
            seconds = 0;
            running = false;
            timer.Interval = 1000;
            timer.Tick += timer_tick;
            button = b;
            button.Click += btn_click;
            flag = f;
            timer.Start();
            time = l;
            if (ckb.Checked && !running && path != "")
            {
                if (start() != null)
                {
                    write("Start failed: " + start().Message);
                }
                else
                {
                    write("Started successfully.");
                }
            }
            else if (path == "")
            {
                write("You need to specify a path for me.");
            }
            //runpath = createshortcut();

        }
        public Main main { get; set; }
        public int seconds { get; set; }
        public bool running { get; set; }
        public string path { get; set; }
        public string procname { get; set; }
        public string name { get; set; }
        public CheckBox ckb { get; set; }
        public RichTextBox log { get; set; }
        public System.Windows.Forms.Timer timer { get; set; }
        public PictureBox button { get; set; }
        public PictureBox flag { get; set; }
        public Label time { get; set; }
        public bool lasttick { get; set; }
        public bool juststarted { get; set; }
        public string runpath = "";
        string lastlog = "";
        public bool juststopped { get; set; }

        public void timer_tick(object sender, EventArgs e)
        {
            
            if (!running)
            {
                
                seconds = 0;
                button.Image = ZCP_3._1.Properties.Resources.control_play_blue;
                
            }
            else
            {
                seconds++;
                button.Image = ZCP_3._1.Properties.Resources.control_stop_blue;
            }
                #region time
                int s = seconds, m = seconds/60, h = m/60, d = h/24;
                
                string ss, sm, sh, sd;
                s = s - 60 * m;
                m = m - 60 * h;
                h = h - 24 * d;
               
                if (s < 10) ss = "0" + s.ToString();
                else ss = s.ToString();
                if (m < 10) sm = "0" + m.ToString();
                else sm = m.ToString();
                if (h < 10) sh = "0" + h.ToString();
                else sh = h.ToString();
                if (d < 10) sd = "0" + d.ToString();
                else sd = d.ToString();

                time.Text = sd + ":" + sh + ":" + sm + ":" + ss;
                #endregion
                Process[] proc;
                proc = Process.GetProcesses();
                
                foreach (Process procc in proc)
                {
                    if (procc.ProcessName == procname)
                    {
                        running = true;
                        lasttick = true;
                        write("Process detected.");
                        if (!procc.Responding)
                        {
                            write("I'm not responding, terminating.");
                            procc.Kill();
                        }
                        break;
                    }
                    running = false;
                    //lasttick = false;
                }
                if (lasttick && !running)
                {
                    if (!juststopped)
                    {
                    juststopped = false;
                    write("I crashed!");
                    if (ckb.Checked) start();
                    }
                    else
                    {
                    juststopped = false;
                    write("I stopped.");
                    lasttick = false;
                    }
                }

                if (running) flag.Image =            ZCP_3._1.Properties.Resources.flag_green;
                else if (!System.IO.File.Exists(path)) flag.Image =    ZCP_3._1.Properties.Resources.flag_3;
                else flag.Image =                    ZCP_3._1.Properties.Resources.flag_red;
                juststarted = false;
            }      
        public void btn_click(object sender, EventArgs e)
        {
            if (path == "")
            {
                MessageBox.Show("You haven't specified a path for " + name + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!running)
            if (start() != null) write("Start failed: " + start().Message, true);
            else
            {
                write("I started.");
                juststarted = true;
            }
            else
            {
                Process[] proc = Process.GetProcesses();
                foreach (Process procc in proc)
                {
                    if (procc.ProcessName == procname)
                    {

                        write("I stopped.");
                        juststopped = true;
                        //timer.Stop();
                        procc.Kill();
                        break;
                    }
                }
            }
        }
        public Exception start()
        {
            try
            {
                string workdir;
                for (int i = path.Length - 1; true; i--)
                {
                    if (path[i] == '\\')
                    {
                        workdir = path.Substring(0, i + 1);
                        break;
                    }
                }
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = path;
                p.WorkingDirectory = workdir;
                
                if (Program.main.ckbhide.Checked) p.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(p);
                write("I started.");
                return null;
            }
            catch(Exception ex)
            {
                return ex;
            }
        }
        public void write(string str, bool force = false)
        {
            if (lastlog != str && !force) log.Text += "\n" + name + "[" + DateTime.Now.ToString() + "]> " + str;
            else if (lastlog == str && force) log.Text += "\n" + name + "[" + DateTime.Now.ToString() + "]> " + str;
            lastlog = str;
        }
    };
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZCP_3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static Main main;

        [STAThread]
        static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new Main();
            Application.Run(main);
        }
    }
}

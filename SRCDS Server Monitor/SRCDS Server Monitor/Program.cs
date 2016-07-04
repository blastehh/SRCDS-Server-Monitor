using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRCDS_Server_Monitor
{

    static class Program
    {

        private static int verMajor = 0;
        private static int verMinor = 13;
        private static int verRevision = 2;
        public static string version
        {
            get { return string.Format("{0}.{1}.{2}", verMajor, verMinor, verRevision); }
        }
        public static int versionMaj
        { 
            get { return verMajor; }
        }
        public static int versionMin
        {
            get { return verMinor; }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}

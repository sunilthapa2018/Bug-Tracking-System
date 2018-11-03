using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking_Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new formLogin());//Login Form
            Application.Run(new formUser("sunil","11"));
            //Application.Run(new formUserReportBug("11"));
            //Application.Run(new formUserEditBugReport("11"));
            //Application.Run(new formUserEditReport("19"));

        }
    }
}

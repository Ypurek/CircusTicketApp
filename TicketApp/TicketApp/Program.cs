using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketApp
{
    static class Program
    {
        private static Form_Logon logonForm;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            logonForm = new Form_Logon();
            Application.Run(logonForm);
        }

        public static Form_Logon LogonForm { get { return logonForm; } }
    }
}

using System;
using System.Windows.Forms;
using T02_Source_Code.Presentation;

namespace T02_Source_Code
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
            Application.Run(new FrmLogin());}
    }
}

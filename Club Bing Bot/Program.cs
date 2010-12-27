using System;
using System.Windows.Forms;

//[assembly: System.Runtime.CompilerServices.SuppressIldasm]

namespace Xenix
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
            Application.Run(Form1.Instance);
        }  
    }
}

using System;
using System.Windows.Forms;

namespace Genius
{
    static class Program
    {
        /// <summary>
        /// O principal ponto de entrada do aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplashScreen());
        }
    }
}
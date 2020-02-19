using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMD2_Snake
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

            SnakeWindowForm swf = new SnakeWindowForm();
            swf.Text = "GMD2 - Snake";
            Application.Run(swf);
            swf.GameLoop();
        }
    }
}

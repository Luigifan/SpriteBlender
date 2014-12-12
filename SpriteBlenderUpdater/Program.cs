using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpriteBlenderUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Main(args[0]));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Hey you! Stay outta here!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteBlender
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
            Application.SetCompatibleTextRenderingDefault(true);
            //
            Form1 form = new Form1();
            var screen = Screen.FromPoint(form.Location);
            form.Location = new Point(screen.WorkingArea.Right - form.Width, screen.WorkingArea.Bottom - form.Height);
            form.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            form.notifyIcon.BalloonTipTitle = "Sprite Blender is running!";
            form.notifyIcon.BalloonTipText = "Double click the system tray icon to open it, or right click the icon and select 'Show Application'";
            form.notifyIcon.ShowBalloonTip(2000);
            //
            Application.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SpriteBlenderUpdater
{
    public partial class Main : Form
    {
        static string exeLocation = "https://raw.githubusercontent.com/Luigifan/SpriteBlender/master/updates/SpriteBlender.exe";
        string spriteBlenderLoc = "";
        string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpriteBlender";

        public Main(string spriteBlenderLocation)
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
            spriteBlenderLoc = spriteBlenderLocation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(TryKillProcess);
            t.Start();
        }

        private void TryKillProcess()
        {
            statusLabel.Text = "Checking if a process is still running..";
            try
            {
                Process[] proc = Process.GetProcessesByName("SpriteBlender");
                statusLabel.Text = "Killing processes..";
                foreach(var i in proc)
                {
                    i.Kill();
                }
            }
            catch
            { Console.WriteLine("SpriteBlender not running"); }
            DownloadUpdate();
        }

        private void DownloadUpdate()
        {
            statusLabel.Text = "Download update..";
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(exeLocation, appDataLocation + Path.DirectorySeparatorChar + "SpriteBlender_Latest.exe");
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred while trying to update!\n\nStack: {0}", ex.Message), 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                Environment.Exit(-2); //-2 means an error occurred while trying to download
            }
            Replace();
        }
        
        private void Replace()
        {
            statusLabel.Text = "Replacing original...";
            File.Delete(spriteBlenderLoc);
            try
            {
                File.Move(appDataLocation + Path.DirectorySeparatorChar + "SpriteBlender_Latest.exe", spriteBlenderLoc);
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred while trying to update!\n\nStack: {0}", ex.InnerException), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-3); //-3 means an error occurred while trying to replace
            }
            Complete();
        }

        private void Complete()
        {
            statusLabel.Text = "Updated!";
            Thread.Sleep(1000);
            DialogResult dr = MessageBox.Show("SpriteBlender finished updating successfully! Would you like to launch now?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch(dr)
            {
                case(DialogResult.Yes):
                    Process.Start(spriteBlenderLoc);
                    break;
                case(DialogResult.No):
                    //do nothing
                    break;
            }
            Environment.Exit(1); //1 means success!
        }
    }
}

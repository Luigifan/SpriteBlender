using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SpriteBlender
{
    public partial class UpdateChecker : Form
    {
        static string versionUrl = "https://raw.githubusercontent.com/Luigifan/SpriteBlender/master/version.txt";
        static string changelogUrl;
        static string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpriteBlender";
        static Version curVersion = new Version(Application.ProductVersion);
        static Version latestVersion = new Version();
        int expandedHeight;
        int expandedWidth;
        
        public UpdateChecker()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }

        private void UpdateChecker_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(CheckForUpdates);
            t.Start();
        }

        /// <summary>
        /// Check if an update is applicable
        /// </summary>
        private void CheckForUpdates()
        {
            WebClient wc = new WebClient();
            byte[] data = wc.DownloadData(versionUrl);
            try
            {
                latestVersion = Version.Parse(Encoding.ASCII.GetString(data));
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred while trying to check for updates\n\nStack: {0}", ex.Message),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            int result = curVersion.CompareTo(latestVersion); //0 = same, 1 or more = newer, less than 0 = older
            if(result < 1)
            {
                int newWidth = this.Width + 100;
                int newHeight = this.Height + 400;
                while(this.Width < newWidth && this.Height < newHeight)
                {
                    this.Width++;
                    this.Height++;
                    Application.DoEvents();
                }
                //blah blah 
                progressBar.Style = ProgressBarStyle.Blocks;
                statusLabel.Text = "Update available!";
                byte[] changelog = wc.DownloadData(changelogUrl);

            }
            else if(result > 1 || result == 0)
            {
                MessageBox.Show("You are up to date!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// Download updater, launch, etc
        /// </summary>
        private void DoUpdates()
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

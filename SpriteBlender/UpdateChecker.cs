using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        static string changelogUrl = "https://raw.githubusercontent.com/Luigifan/SpriteBlender/master/changelog.txt";
        static string updaterUrl = "https://raw.githubusercontent.com/Luigifan/SpriteBlender/master/updates/SpriteBlenderUpdater.exe";
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
            expandedHeight = this.Height;
            expandedWidth = this.Width;
            //
            this.Height = this.Height - groupBox.Height;
            groupBox.Visible = false;
            //
            if(Directory.Exists(AppDataFolder) != true)
            {
                Directory.CreateDirectory(AppDataFolder);
            }
            //
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
            if(result <= -1)
            {
                statusLabel.Text = "Retrieveing changelog..";
                byte[] changelog = wc.DownloadData(changelogUrl);
                while(this.Height < expandedHeight)
                {
                    this.Height++;
                    Application.DoEvents();
                }
                //blah blah 
                progressBar.Style = ProgressBarStyle.Continuous;
                statusLabel.Text = "Update available!";
                groupBox.Visible = true;
                changelogRtf.Text = Encoding.ASCII.GetString(changelog);
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
            progressBar.Style = ProgressBarStyle.Continuous;
            statusLabel.Text = "Downloading updater..";
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(updaterUrl, AppDataFolder + Path.DirectorySeparatorChar + "SpriteBlenderUpdater.exe");
                progressBar.Style = ProgressBarStyle.Marquee;
                statusLabel.Text = "Updater downloaded.";
                Process.Start(AppDataFolder + Path.DirectorySeparatorChar + "SpriteBlenderUpdater.exe", Application.ExecutablePath);
                Environment.Exit(5); //5 means we're closing for updates
            }
            catch(System.Net.WebException ex)
            {
                MessageBox.Show(string.Format("An error occurred while downloading the updater!\n\nStack: {0}", ex.InnerException), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(DoUpdates);
            t.Start();
        }
    }
}

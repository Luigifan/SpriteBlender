using GlassMoth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteBlender
{
    public partial class Form1 : Form
    {
        //
        private MARGINS margins = new MARGINS();
        private Rectangle topRect = new Rectangle();
        private Rectangle leftRect = new Rectangle();
        private Rectangle rightRect = new Rectangle();
        private Rectangle botRect = new Rectangle();
        //
        PictureBox imagePictureBox = new PictureBox();
        PictureBox maskPictureBox = new PictureBox();
        //
        public Form1()
        {
            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(DwmIsCompositionEnabled())
            {
                Rectangle together = new Rectangle(imageGroupBox.Location.X, imageGroupBox.Location.Y,
                    imageGroupBox.Width + maskGroupBox.Width, imageGroupBox.Height + resultGroupBox.Height + saveResultButton.Height);
                margins = new MARGINS();
                margins.Top = (this.Height - together.Height)/2/2;
                margins.Left = (this.Width - together.Width)/2/2;
                margins.Right = margins.Left;
                margins.Bottom = margins.Top;
                //Define rectnangles, for detection of whether or not the selected area is glass
                topRect = new Rectangle(0, 0, ClientSize.Width, margins.Top);
                leftRect = new Rectangle(0, 0, (ClientSize.Width - together.Width) /2, margins.Top);
                rightRect = leftRect;
                botRect = topRect;
                //
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled())
            {
                this.Update();
                e.Graphics.Clear(Color.Black);
                Rectangle clientArea = new Rectangle(
                    margins.Left,
                    margins.Top,
                    this.ClientRectangle.Width - margins.Left - margins.Right,
                    this.ClientRectangle.Height - margins.Top - margins.Bottom
                    );
                Brush b = new SolidBrush(this.BackColor);
                e.Graphics.FillRectangle(b, clientArea);
                this.Update();
            }
            //
            /*notifyIcon.Visible = true;
            //this.Visible = false;
            this.Hide();
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipTitle = "Sprite Blender is running!";
            notifyIcon.BalloonTipText = "Double click the system tray icon to open it, or right click the icon and select 'Show Application'";
            notifyIcon.ShowBalloonTip(2000);*/
        }

        #region Ugly PInvoke stuff
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmExtendFrameIntoClientArea
                        (IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        #endregion
        #region ifGlassSelected
        protected override void WndProc(ref Message m)
        {
            /*base.WndProc(ref m);

            if (m.Msg == VistaApi.WM_NCHITTEST // if this is a click
              && m.Result.ToInt32() == VistaApi.HTCLIENT // ...and it is on the client
              && this.IsOnGlass(m.LParam.ToInt32())) // ...and specifically in the glass area
            {
                m.Result = new IntPtr(VistaApi.HTCAPTION); // lie and say they clicked on the title bar
            }*/ //if we were still interested in having glass portions move, sure this would be great
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref m);
        }

        private bool IsGlassEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                Debug.WriteLine("Not drawing glass");
                return false;
            }

            //Check if DWM is enabled
            bool isGlassSupported = false;
            VistaApi.DwmIsCompositionEnabled(ref isGlassSupported);
            return isGlassSupported;
        }

        private bool IsOnGlass(int lParam)
        {
            // sanity check
            if (!this.IsGlassEnabled())
            {
                return false;
            }

            // get screen coordinates
            int x = (lParam << 16) >> 16; // lo order word
            int y = lParam >> 16; // hi order word

            // translate screen coordinates to client area
            Point p = this.PointToClient(new Point(x, y));

            // work out if point clicked is on glass
            if (topRect.Contains(p) || leftRect.Contains(p) || rightRect.Contains(p) || botRect.Contains(p))
            {
                return true;
            }

            return false;
        }
        #endregion

        private void clickSelImageLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image..";
            ofd.Filter = "Image Files|*.png;*.gif;*.bmp;*.jpg;*.jpeg";
            DialogResult dr = ofd.ShowDialog();
            switch(dr)
            {
                case (DialogResult.OK):
                    imagePictureBox = new PictureBox();
                    imagePictureBox.Image = Image.FromFile(ofd.FileName);
                    imagePictureBox.Dock = DockStyle.Fill;
                    imagePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    clickSelImageLabel.Visible = false;
                    imageGroupBox.Controls.Add(imagePictureBox);
                    bothReady();
                    break;
                case (DialogResult.Cancel):
                    break;
            }
        }

        private void clickSelMaskLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Mask..";
            ofd.Filter = "Image Files|*.png;*.gif;*.bmp;*.jpg;*.jpeg";
            DialogResult dr = ofd.ShowDialog();
            switch(dr)
            {
                case (DialogResult.OK):
                    maskPictureBox = new PictureBox();
                    maskPictureBox.Image = Image.FromFile(ofd.FileName);
                    maskPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    maskPictureBox.Dock = DockStyle.Fill;
                    clickSelMaskLabel.Visible = false;
                    maskGroupBox.Controls.Add(maskPictureBox);
                    bothReady();
                    break;
                case(DialogResult.Cancel):
                    break;
            }
        }

        private void bothReady()
        {
            if(maskPictureBox.Image != null && imagePictureBox.Image != null)
            {
                try
                {
                    MaskedSprite ms = new MaskedSprite(imagePictureBox.Image, maskPictureBox.Image);
                    finalPictureBox.Image = ms.GetMaskedImage;
                    finalPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    saveResultButton.Enabled = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error attempting to blend sprites!\n\nStack Trace: {0}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetImagesButton_Click(object sender, EventArgs e)
        {
            if(finalPictureBox.Image != null)
                finalPictureBox.Image.Dispose();
            if(maskPictureBox.Image != null)
                maskPictureBox.Image.Dispose();
            if(imagePictureBox.Image != null)
                imagePictureBox.Image.Dispose();

            imageGroupBox.Controls.Remove(imagePictureBox);
            maskGroupBox.Controls.Remove(maskPictureBox);
            saveResultButton.Enabled = false;
            clickSelMaskLabel.Visible = true;
            clickSelImageLabel.Visible = true;
        }

        private void saveResultButton_Click(object sender, EventArgs e)
        {
            if(finalPictureBox.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save result as..";
                sfd.Filter = "PNG Files (transparency)|*.png|BMP Files (no transparency)|*.bmp|JPEG Files (no transparency)|*.jpeg;*.jpg";
                DialogResult dr = sfd.ShowDialog();
                switch(dr)
                {
                    case (DialogResult.OK):
                        Image img = finalPictureBox.Image;
                        try
                        {
                            img.Save(sfd.FileName);
                            MessageBox.Show("Image written to '" + sfd.FileName + "' successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error trying to write to file!\n\nStack Trace: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
            notifyIcon.Visible = false;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.FormOwnerClosing || e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
                notifyIcon.Visible = true;
            }
            else if(e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                e.Cancel = false;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            var screen = Screen.FromPoint(this.Location);
            this.Location = new Point(screen.WorkingArea.Right - this.Width, screen.WorkingArea.Bottom - this.Height);
            notifyIcon.Visible = false;
        }
        //
    }
}

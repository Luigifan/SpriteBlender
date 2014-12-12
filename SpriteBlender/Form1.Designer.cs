namespace SpriteBlender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.maskGroupBox = new System.Windows.Forms.GroupBox();
            this.clickSelMaskLabel = new System.Windows.Forms.Label();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.clickSelImageLabel = new System.Windows.Forms.Label();
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.finalPictureBox = new System.Windows.Forms.PictureBox();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.resetImagesButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyContextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.versionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.maskGroupBox.SuspendLayout();
            this.imageGroupBox.SuspendLayout();
            this.resultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskGroupBox
            // 
            this.maskGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskGroupBox.Controls.Add(this.clickSelMaskLabel);
            this.maskGroupBox.ForeColor = System.Drawing.Color.Black;
            this.maskGroupBox.Location = new System.Drawing.Point(208, 52);
            this.maskGroupBox.Name = "maskGroupBox";
            this.maskGroupBox.Size = new System.Drawing.Size(160, 177);
            this.maskGroupBox.TabIndex = 3;
            this.maskGroupBox.TabStop = false;
            this.maskGroupBox.Text = "Mask";
            this.maskGroupBox.UseCompatibleTextRendering = true;
            // 
            // clickSelMaskLabel
            // 
            this.clickSelMaskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickSelMaskLabel.AutoSize = true;
            this.clickSelMaskLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clickSelMaskLabel.Location = new System.Drawing.Point(27, 78);
            this.clickSelMaskLabel.Name = "clickSelMaskLabel";
            this.clickSelMaskLabel.Size = new System.Drawing.Size(101, 13);
            this.clickSelMaskLabel.TabIndex = 1;
            this.clickSelMaskLabel.Text = "Click to select mask";
            this.clickSelMaskLabel.Click += new System.EventHandler(this.clickSelMaskLabel_Click);
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageGroupBox.Controls.Add(this.clickSelImageLabel);
            this.imageGroupBox.ForeColor = System.Drawing.Color.Black;
            this.imageGroupBox.Location = new System.Drawing.Point(44, 52);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(160, 177);
            this.imageGroupBox.TabIndex = 2;
            this.imageGroupBox.TabStop = false;
            this.imageGroupBox.Text = "Image";
            this.imageGroupBox.UseCompatibleTextRendering = true;
            // 
            // clickSelImageLabel
            // 
            this.clickSelImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickSelImageLabel.AutoSize = true;
            this.clickSelImageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clickSelImageLabel.Location = new System.Drawing.Point(30, 78);
            this.clickSelImageLabel.Name = "clickSelImageLabel";
            this.clickSelImageLabel.Size = new System.Drawing.Size(104, 13);
            this.clickSelImageLabel.TabIndex = 0;
            this.clickSelImageLabel.Text = "Click to select image";
            this.clickSelImageLabel.Click += new System.EventHandler(this.clickSelImageLabel_Click);
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGroupBox.Controls.Add(this.finalPictureBox);
            this.resultGroupBox.ForeColor = System.Drawing.Color.Black;
            this.resultGroupBox.Location = new System.Drawing.Point(44, 239);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(324, 133);
            this.resultGroupBox.TabIndex = 3;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Result";
            this.resultGroupBox.UseCompatibleTextRendering = true;
            // 
            // finalPictureBox
            // 
            this.finalPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.finalPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalPictureBox.Location = new System.Drawing.Point(3, 16);
            this.finalPictureBox.Name = "finalPictureBox";
            this.finalPictureBox.Size = new System.Drawing.Size(318, 114);
            this.finalPictureBox.TabIndex = 0;
            this.finalPictureBox.TabStop = false;
            // 
            // saveResultButton
            // 
            this.saveResultButton.Enabled = false;
            this.saveResultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.saveResultButton.Location = new System.Drawing.Point(44, 375);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(156, 26);
            this.saveResultButton.TabIndex = 4;
            this.saveResultButton.Text = "Save Result as PNG";
            this.saveResultButton.UseVisualStyleBackColor = true;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click);
            // 
            // resetImagesButton
            // 
            this.resetImagesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetImagesButton.Location = new System.Drawing.Point(208, 375);
            this.resetImagesButton.Name = "resetImagesButton";
            this.resetImagesButton.Size = new System.Drawing.Size(156, 26);
            this.resetImagesButton.TabIndex = 5;
            this.resetImagesButton.Text = "Reset Images";
            this.resetImagesButton.UseVisualStyleBackColor = true;
            this.resetImagesButton.Click += new System.EventHandler(this.resetImagesButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Sprite Blender";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 54);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showApplicationToolStripMenuItem.Text = "Show Application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Show Application";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Exit";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // versionLinkLabel
            // 
            this.versionLinkLabel.AutoSize = true;
            this.versionLinkLabel.Location = new System.Drawing.Point(47, 408);
            this.versionLinkLabel.Name = "versionLinkLabel";
            this.versionLinkLabel.Size = new System.Drawing.Size(27, 13);
            this.versionLinkLabel.TabIndex = 6;
            this.versionLinkLabel.TabStop = true;
            this.versionLinkLabel.Text = "v{0}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 445);
            this.Controls.Add(this.versionLinkLabel);
            this.Controls.Add(this.resetImagesButton);
            this.Controls.Add(this.saveResultButton);
            this.Controls.Add(this.resultGroupBox);
            this.Controls.Add(this.maskGroupBox);
            this.Controls.Add(this.imageGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.maskGroupBox.ResumeLayout(false);
            this.maskGroupBox.PerformLayout();
            this.imageGroupBox.ResumeLayout(false);
            this.imageGroupBox.PerformLayout();
            this.resultGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finalPictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox maskGroupBox;
        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.Button saveResultButton;
        private System.Windows.Forms.Button resetImagesButton;
        private System.Windows.Forms.Label clickSelMaskLabel;
        private System.Windows.Forms.Label clickSelImageLabel;
        private System.Windows.Forms.PictureBox finalPictureBox;
        private System.Windows.Forms.ContextMenu notifyContextMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel versionLinkLabel;
    }
}


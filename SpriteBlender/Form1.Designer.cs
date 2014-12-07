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
            this.maskGroupBox = new System.Windows.Forms.GroupBox();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.resetImagesButton = new System.Windows.Forms.Button();
            this.clickSelImageLabel = new System.Windows.Forms.Label();
            this.clickSelMaskLabel = new System.Windows.Forms.Label();
            this.finalPictureBox = new System.Windows.Forms.PictureBox();
            this.maskGroupBox.SuspendLayout();
            this.imageGroupBox.SuspendLayout();
            this.resultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalPictureBox)).BeginInit();
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
            this.maskGroupBox.Size = new System.Drawing.Size(156, 177);
            this.maskGroupBox.TabIndex = 3;
            this.maskGroupBox.TabStop = false;
            this.maskGroupBox.Text = "Mask";
            this.maskGroupBox.UseCompatibleTextRendering = true;
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageGroupBox.Controls.Add(this.clickSelImageLabel);
            this.imageGroupBox.ForeColor = System.Drawing.Color.Black;
            this.imageGroupBox.Location = new System.Drawing.Point(44, 52);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(156, 177);
            this.imageGroupBox.TabIndex = 2;
            this.imageGroupBox.TabStop = false;
            this.imageGroupBox.Text = "Image";
            this.imageGroupBox.UseCompatibleTextRendering = true;
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGroupBox.Controls.Add(this.finalPictureBox);
            this.resultGroupBox.ForeColor = System.Drawing.Color.Black;
            this.resultGroupBox.Location = new System.Drawing.Point(44, 235);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(320, 133);
            this.resultGroupBox.TabIndex = 3;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Result";
            this.resultGroupBox.UseCompatibleTextRendering = true;
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
            // finalPictureBox
            // 
            this.finalPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.finalPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalPictureBox.Location = new System.Drawing.Point(3, 16);
            this.finalPictureBox.Name = "finalPictureBox";
            this.finalPictureBox.Size = new System.Drawing.Size(314, 114);
            this.finalPictureBox.TabIndex = 0;
            this.finalPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 441);
            this.Controls.Add(this.resetImagesButton);
            this.Controls.Add(this.saveResultButton);
            this.Controls.Add(this.resultGroupBox);
            this.Controls.Add(this.maskGroupBox);
            this.Controls.Add(this.imageGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.maskGroupBox.ResumeLayout(false);
            this.maskGroupBox.PerformLayout();
            this.imageGroupBox.ResumeLayout(false);
            this.imageGroupBox.PerformLayout();
            this.resultGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finalPictureBox)).EndInit();
            this.ResumeLayout(false);

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
    }
}


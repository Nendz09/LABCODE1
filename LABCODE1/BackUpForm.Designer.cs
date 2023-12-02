namespace LABCODE1
{
    partial class BackUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpForm));
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse_Recover = new System.Windows.Forms.Button();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBackup1 = new LABCODE1.UserButton();
            this.btnRestore1 = new LABCODE1.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(37, 59);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(275, 20);
            this.txtBackupPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(318, 59);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse_Recover
            // 
            this.btnBrowse_Recover.Location = new System.Drawing.Point(318, 195);
            this.btnBrowse_Recover.Name = "btnBrowse_Recover";
            this.btnBrowse_Recover.Size = new System.Drawing.Size(75, 21);
            this.btnBrowse_Recover.TabIndex = 7;
            this.btnBrowse_Recover.Text = "Browse";
            this.btnBrowse_Recover.UseVisualStyleBackColor = true;
            this.btnBrowse_Recover.Click += new System.EventHandler(this.btnBrowse_Recover_Click);
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(37, 195);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(275, 20);
            this.txtRestorePath.TabIndex = 6;
            // 
            // btnBackup1
            // 
            this.btnBackup1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup1.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup1.Image")));
            this.btnBackup1.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnBackup1.ImageHover")));
            this.btnBackup1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnBackup1.ImageNormal")));
            this.btnBackup1.Location = new System.Drawing.Point(93, 85);
            this.btnBackup1.Name = "btnBackup1";
            this.btnBackup1.Size = new System.Drawing.Size(187, 85);
            this.btnBackup1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBackup1.TabIndex = 9;
            this.btnBackup1.TabStop = false;
            this.btnBackup1.Click += new System.EventHandler(this.btnBackup1_Click);
            // 
            // btnRestore1
            // 
            this.btnRestore1.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore1.Image")));
            this.btnRestore1.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnRestore1.ImageHover")));
            this.btnRestore1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnRestore1.ImageNormal")));
            this.btnRestore1.Location = new System.Drawing.Point(93, 221);
            this.btnRestore1.Name = "btnRestore1";
            this.btnRestore1.Size = new System.Drawing.Size(187, 85);
            this.btnRestore1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestore1.TabIndex = 10;
            this.btnRestore1.TabStop = false;
            this.btnRestore1.Click += new System.EventHandler(this.btnRestore1_Click);
            // 
            // BackUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 332);
            this.Controls.Add(this.btnRestore1);
            this.Controls.Add(this.btnBackup1);
            this.Controls.Add(this.btnBrowse_Recover);
            this.Controls.Add(this.txtRestorePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupPath);
            this.Name = "BackUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUpForm";
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Button btnBrowse_Recover;
        public System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public UserButton btnBackup1;
        public UserButton btnRestore1;
    }
}
namespace LABCODE1
{
    partial class AccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelFullname = new System.Windows.Forms.Label();
            this.userButton1 = new LABCODE1.UserButton();
            this.labelPassword = new System.Windows.Forms.Label();
            this.userButton2 = new LABCODE1.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.userButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.Black;
            this.labelUsername.Location = new System.Drawing.Point(25, 23);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(180, 39);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "username";
            this.labelUsername.TextChanged += new System.EventHandler(this.labelReturn_TextChanged);
            // 
            // labelFullname
            // 
            this.labelFullname.AutoSize = true;
            this.labelFullname.BackColor = System.Drawing.Color.Transparent;
            this.labelFullname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullname.ForeColor = System.Drawing.Color.Black;
            this.labelFullname.Location = new System.Drawing.Point(25, 98);
            this.labelFullname.Name = "labelFullname";
            this.labelFullname.Size = new System.Drawing.Size(157, 39);
            this.labelFullname.TabIndex = 4;
            this.labelFullname.Text = "fullname";
            // 
            // userButton1
            // 
            this.userButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userButton1.Image = ((System.Drawing.Image)(resources.GetObject("userButton1.Image")));
            this.userButton1.ImageHover = ((System.Drawing.Image)(resources.GetObject("userButton1.ImageHover")));
            this.userButton1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userButton1.ImageNormal")));
            this.userButton1.Location = new System.Drawing.Point(32, 285);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(226, 105);
            this.userButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userButton1.TabIndex = 5;
            this.userButton1.TabStop = false;
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.Black;
            this.labelPassword.Location = new System.Drawing.Point(463, 37);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(95, 39);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "pass";
            this.labelPassword.Visible = false;
            // 
            // userButton2
            // 
            this.userButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userButton2.BackColor = System.Drawing.Color.Transparent;
            this.userButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userButton2.Image = ((System.Drawing.Image)(resources.GetObject("userButton2.Image")));
            this.userButton2.ImageHover = ((System.Drawing.Image)(resources.GetObject("userButton2.ImageHover")));
            this.userButton2.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userButton2.ImageNormal")));
            this.userButton2.Location = new System.Drawing.Point(291, 285);
            this.userButton2.Name = "userButton2";
            this.userButton2.Size = new System.Drawing.Size(226, 105);
            this.userButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userButton2.TabIndex = 7;
            this.userButton2.TabStop = false;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LABCODE1.Properties.Resources.bg_trans_withstatue_noopacity;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(841, 606);
            this.Controls.Add(this.userButton2);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.userButton1);
            this.Controls.Add(this.labelFullname);
            this.Controls.Add(this.labelUsername);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            ((System.ComponentModel.ISupportInitialize)(this.userButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelUsername;
        public System.Windows.Forms.Label labelFullname;
        private UserButton userButton1;
        public System.Windows.Forms.Label labelPassword;
        private UserButton userButton2;
    }
}
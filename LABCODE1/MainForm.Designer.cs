namespace LABCODE1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.userButton2 = new LABCODE1.UserButton();
            this.userButton3 = new LABCODE1.UserButton();
            this.btnEquipment = new LABCODE1.UserButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.userButton2);
            this.panel1.Controls.Add(this.userButton3);
            this.panel1.Controls.Add(this.btnEquipment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 606);
            this.panel1.TabIndex = 0;
            // 
            // userButton2
            // 
            this.userButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userButton2.Image = ((System.Drawing.Image)(resources.GetObject("userButton2.Image")));
            this.userButton2.ImageHover = ((System.Drawing.Image)(resources.GetObject("userButton2.ImageHover")));
            this.userButton2.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userButton2.ImageNormal")));
            this.userButton2.Location = new System.Drawing.Point(1, 322);
            this.userButton2.Name = "userButton2";
            this.userButton2.Size = new System.Drawing.Size(176, 108);
            this.userButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userButton2.TabIndex = 3;
            this.userButton2.TabStop = false;
            // 
            // userButton3
            // 
            this.userButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userButton3.Image = ((System.Drawing.Image)(resources.GetObject("userButton3.Image")));
            this.userButton3.ImageHover = ((System.Drawing.Image)(resources.GetObject("userButton3.ImageHover")));
            this.userButton3.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userButton3.ImageNormal")));
            this.userButton3.Location = new System.Drawing.Point(1, 215);
            this.userButton3.Name = "userButton3";
            this.userButton3.Size = new System.Drawing.Size(176, 108);
            this.userButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userButton3.TabIndex = 2;
            this.userButton3.TabStop = false;
            // 
            // btnEquipment
            // 
            this.btnEquipment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipment.Image")));
            this.btnEquipment.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnEquipment.ImageHover")));
            this.btnEquipment.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnEquipment.ImageNormal")));
            this.btnEquipment.Location = new System.Drawing.Point(1, 108);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(176, 108);
            this.btnEquipment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEquipment.TabIndex = 0;
            this.btnEquipment.TabStop = false;
            this.btnEquipment.Click += new System.EventHandler(this.btnEquipment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "ICON";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(176, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(841, 606);
            this.panelMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 606);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private UserButton btnEquipment;
        private UserButton userButton2;
        private UserButton userButton3;
    }
}
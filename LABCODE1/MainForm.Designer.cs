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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStudentsMainPanel = new LABCODE1.UserButtonMainPanel();
            this.btnInventoryMainPanel = new LABCODE1.UserButtonMainPanel();
            this.btnDashboardMainPanel = new LABCODE1.UserButtonMainPanel();
            this.btnLogsMainPanel = new LABCODE1.UserButtonMainPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStudentsMainPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventoryMainPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDashboardMainPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogsMainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.btnLogsMainPanel);
            this.panel1.Controls.Add(this.btnStudentsMainPanel);
            this.panel1.Controls.Add(this.btnInventoryMainPanel);
            this.panel1.Controls.Add(this.btnDashboardMainPanel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 736);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(153, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.flowLayoutPanel1);
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(207, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1113, 736);
            this.panelMain.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(359, 274);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(432, 274);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 177);
            this.label1.TabIndex = 7;
            this.label1.Text = "Depatment of Biological and Physical Sciences";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStudentsMainPanel
            // 
            this.btnStudentsMainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudentsMainPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnStudentsMainPanel.Image")));
            this.btnStudentsMainPanel.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnStudentsMainPanel.ImageHover")));
            this.btnStudentsMainPanel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnStudentsMainPanel.ImageNormal")));
            this.btnStudentsMainPanel.Location = new System.Drawing.Point(0, 309);
            this.btnStudentsMainPanel.Name = "btnStudentsMainPanel";
            this.btnStudentsMainPanel.Size = new System.Drawing.Size(206, 94);
            this.btnStudentsMainPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnStudentsMainPanel.TabIndex = 12;
            this.btnStudentsMainPanel.TabStop = false;
            this.btnStudentsMainPanel.Click += new System.EventHandler(this.btnStudentsMainPanel_Click);
            // 
            // btnInventoryMainPanel
            // 
            this.btnInventoryMainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryMainPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnInventoryMainPanel.Image")));
            this.btnInventoryMainPanel.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnInventoryMainPanel.ImageHover")));
            this.btnInventoryMainPanel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnInventoryMainPanel.ImageNormal")));
            this.btnInventoryMainPanel.Location = new System.Drawing.Point(0, 209);
            this.btnInventoryMainPanel.Name = "btnInventoryMainPanel";
            this.btnInventoryMainPanel.Size = new System.Drawing.Size(206, 94);
            this.btnInventoryMainPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnInventoryMainPanel.TabIndex = 11;
            this.btnInventoryMainPanel.TabStop = false;
            this.btnInventoryMainPanel.Click += new System.EventHandler(this.btnInventoryMainPanel_Click);
            // 
            // btnDashboardMainPanel
            // 
            this.btnDashboardMainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboardMainPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboardMainPanel.Image")));
            this.btnDashboardMainPanel.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnDashboardMainPanel.ImageHover")));
            this.btnDashboardMainPanel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnDashboardMainPanel.ImageNormal")));
            this.btnDashboardMainPanel.Location = new System.Drawing.Point(0, 109);
            this.btnDashboardMainPanel.Name = "btnDashboardMainPanel";
            this.btnDashboardMainPanel.Size = new System.Drawing.Size(206, 94);
            this.btnDashboardMainPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDashboardMainPanel.TabIndex = 10;
            this.btnDashboardMainPanel.TabStop = false;
            this.btnDashboardMainPanel.Click += new System.EventHandler(this.btnDashboardMainPanel_Click);
            // 
            // btnLogsMainPanel
            // 
            this.btnLogsMainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogsMainPanel.Image = ((System.Drawing.Image)(resources.GetObject("btnLogsMainPanel.Image")));
            this.btnLogsMainPanel.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnLogsMainPanel.ImageHover")));
            this.btnLogsMainPanel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnLogsMainPanel.ImageNormal")));
            this.btnLogsMainPanel.Location = new System.Drawing.Point(0, 409);
            this.btnLogsMainPanel.Name = "btnLogsMainPanel";
            this.btnLogsMainPanel.Size = new System.Drawing.Size(206, 94);
            this.btnLogsMainPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnLogsMainPanel.TabIndex = 13;
            this.btnLogsMainPanel.TabStop = false;
            this.btnLogsMainPanel.Click += new System.EventHandler(this.btnLogsMainPanel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 736);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing_1);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStudentsMainPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInventoryMainPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDashboardMainPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogsMainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private UserButtonMainPanel btnDashboardMainPanel;
        private UserButtonMainPanel btnInventoryMainPanel;
        private UserButtonMainPanel btnStudentsMainPanel;
        private UserButtonMainPanel btnLogsMainPanel;
    }
}
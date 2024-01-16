namespace LABCODE1
{
    partial class StudentModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentModuleForm));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.labelAdd = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYearSec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_StdExists = new System.Windows.Forms.Label();
            this.label_PhoneFormat = new System.Windows.Forms.Label();
            this.studentPicture = new System.Windows.Forms.PictureBox();
            this.btnUpload = new LABCODE1.UserButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(329, 385);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 53);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(186, 385);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(125, 53);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(41, 385);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 53);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.labelUpdate);
            this.panel1.Controls.Add(this.labelAdd);
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 84);
            this.panel1.TabIndex = 12;
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdate.ForeColor = System.Drawing.Color.White;
            this.labelUpdate.Location = new System.Drawing.Point(257, 27);
            this.labelUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(74, 18);
            this.labelUpdate.TabIndex = 14;
            this.labelUpdate.Text = "UPDATE";
            this.labelUpdate.Visible = false;
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.BackColor = System.Drawing.Color.Transparent;
            this.labelAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdd.ForeColor = System.Drawing.Color.White;
            this.labelAdd.Location = new System.Drawing.Point(257, 27);
            this.labelAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(42, 18);
            this.labelAdd.TabIndex = 13;
            this.labelAdd.Text = "ADD";
            this.labelAdd.Visible = false;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(711, 11);
            this.pictureBoxClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(30, 27);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 12;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Module";
            // 
            // txtStudID
            // 
            this.txtStudID.Location = new System.Drawing.Point(261, 124);
            this.txtStudID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStudID.Name = "txtStudID";
            this.txtStudID.Size = new System.Drawing.Size(179, 26);
            this.txtStudID.TabIndex = 17;
            this.txtStudID.TextChanged += new System.EventHandler(this.txtStudID_TextChanged);
            this.txtStudID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudID_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Student ID:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(261, 188);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(179, 26);
            this.txtFullName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Full Name:";
            // 
            // txtYearSec
            // 
            this.txtYearSec.Location = new System.Drawing.Point(261, 248);
            this.txtYearSec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYearSec.Name = "txtYearSec";
            this.txtYearSec.Size = new System.Drawing.Size(179, 26);
            this.txtYearSec.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Year and Section:";
            // 
            // txtPNo
            // 
            this.txtPNo.Location = new System.Drawing.Point(261, 308);
            this.txtPNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPNo.MaxLength = 11;
            this.txtPNo.Name = "txtPNo";
            this.txtPNo.Size = new System.Drawing.Size(179, 26);
            this.txtPNo.TabIndex = 23;
            this.txtPNo.TextChanged += new System.EventHandler(this.txtPNo_TextChanged);
            this.txtPNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPNo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 309);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Phone No.:";
            // 
            // label_StdExists
            // 
            this.label_StdExists.AutoSize = true;
            this.label_StdExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StdExists.ForeColor = System.Drawing.Color.Red;
            this.label_StdExists.Location = new System.Drawing.Point(257, 100);
            this.label_StdExists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_StdExists.Name = "label_StdExists";
            this.label_StdExists.Size = new System.Drawing.Size(155, 15);
            this.label_StdExists.TabIndex = 24;
            this.label_StdExists.Text = "*Student Already Exists";
            this.label_StdExists.Visible = false;
            // 
            // label_PhoneFormat
            // 
            this.label_PhoneFormat.AutoSize = true;
            this.label_PhoneFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhoneFormat.ForeColor = System.Drawing.Color.Red;
            this.label_PhoneFormat.Location = new System.Drawing.Point(257, 284);
            this.label_PhoneFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PhoneFormat.Name = "label_PhoneFormat";
            this.label_PhoneFormat.Size = new System.Drawing.Size(161, 15);
            this.label_PhoneFormat.TabIndex = 25;
            this.label_PhoneFormat.Text = "*Wrong Format (0948**)";
            this.label_PhoneFormat.Visible = false;
            // 
            // studentPicture
            // 
            this.studentPicture.BackColor = System.Drawing.SystemColors.Control;
            this.studentPicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("studentPicture.ErrorImage")));
            this.studentPicture.Image = ((System.Drawing.Image)(resources.GetObject("studentPicture.Image")));
            this.studentPicture.Location = new System.Drawing.Point(501, 111);
            this.studentPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentPicture.Name = "studentPicture";
            this.studentPicture.Size = new System.Drawing.Size(216, 224);
            this.studentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.studentPicture.TabIndex = 26;
            this.studentPicture.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnUpload.ImageHover")));
            this.btnUpload.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnUpload.ImageNormal")));
            this.btnUpload.Location = new System.Drawing.Point(545, 343);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(129, 67);
            this.btnUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUpload.TabIndex = 27;
            this.btnUpload.TabStop = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // StudentModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 479);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.studentPicture);
            this.Controls.Add(this.label_PhoneFormat);
            this.Controls.Add(this.label_StdExists);
            this.Controls.Add(this.txtPNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYearSec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStudID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "StudentModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelUpdate;
        public System.Windows.Forms.TextBox txtStudID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtYearSec;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPNo;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtFullName;
        public System.Windows.Forms.Label label_StdExists;
        public System.Windows.Forms.Label label_PhoneFormat;
        public System.Windows.Forms.PictureBox studentPicture;
        public UserButton btnUpload;
    }
}
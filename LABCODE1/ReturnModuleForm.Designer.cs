namespace LABCODE1
{
    partial class ReturnModuleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnModuleForm));
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label_studentSection = new System.Windows.Forms.Label();
            this.label_studentName = new System.Windows.Forms.Label();
            this.dgvReturn = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.studentPicture = new System.Windows.Forms.PictureBox();
            this.Return = new System.Windows.Forms.DataGridViewImageColumn();
            this.clearStudentID = new LABCODE1.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Barcode.Location = new System.Drawing.Point(196, 305);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(245, 26);
            this.txt_Barcode.TabIndex = 4;
            this.txt_Barcode.TextChanged += new System.EventHandler(this.txt_Barcode_TextChanged);
            this.txt_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Barcode_KeyPress);
            // 
            // label_studentSection
            // 
            this.label_studentSection.AutoSize = true;
            this.label_studentSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_studentSection.Location = new System.Drawing.Point(192, 392);
            this.label_studentSection.Name = "label_studentSection";
            this.label_studentSection.Size = new System.Drawing.Size(93, 24);
            this.label_studentSection.TabIndex = 19;
            this.label_studentSection.Text = "SECTION";
            // 
            // label_studentName
            // 
            this.label_studentName.AutoSize = true;
            this.label_studentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_studentName.Location = new System.Drawing.Point(192, 351);
            this.label_studentName.Name = "label_studentName";
            this.label_studentName.Size = new System.Drawing.Size(160, 24);
            this.label_studentName.TabIndex = 18;
            this.label_studentName.Text = "STUDENT NAME";
            // 
            // dgvReturn
            // 
            this.dgvReturn.AllowUserToAddRows = false;
            this.dgvReturn.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReturn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReturn.ColumnHeadersHeight = 30;
            this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Return});
            this.dgvReturn.EnableHeadersVisualStyles = false;
            this.dgvReturn.Location = new System.Drawing.Point(12, 24);
            this.dgvReturn.Name = "dgvReturn";
            this.dgvReturn.ReadOnly = true;
            this.dgvReturn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvReturn.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReturn.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReturn.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturn.RowTemplate.Height = 40;
            this.dgvReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturn.Size = new System.Drawing.Size(627, 228);
            this.dgvReturn.TabIndex = 20;
            this.dgvReturn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturn_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "Date of Borrow";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "Date of Return";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 160;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = "Item ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Size/Calibration";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "STUDENT ID";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "Action";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 44;
            // 
            // studentPicture
            // 
            this.studentPicture.BackColor = System.Drawing.SystemColors.Control;
            this.studentPicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("studentPicture.ErrorImage")));
            this.studentPicture.Image = global::LABCODE1.Properties.Resources.user_ddefault;
            this.studentPicture.Location = new System.Drawing.Point(12, 267);
            this.studentPicture.Name = "studentPicture";
            this.studentPicture.Size = new System.Drawing.Size(168, 168);
            this.studentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.studentPicture.TabIndex = 28;
            this.studentPicture.TabStop = false;
            // 
            // Return
            // 
            this.Return.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Return.HeaderText = "Action";
            this.Return.Image = ((System.Drawing.Image)(resources.GetObject("Return.Image")));
            this.Return.Name = "Return";
            this.Return.ReadOnly = true;
            this.Return.Width = 44;
            // 
            // clearStudentID
            // 
            this.clearStudentID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearStudentID.Image = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.ImageHover = ((System.Drawing.Image)(resources.GetObject("clearStudentID.ImageHover")));
            this.clearStudentID.ImageNormal = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.Location = new System.Drawing.Point(447, 305);
            this.clearStudentID.Name = "clearStudentID";
            this.clearStudentID.Size = new System.Drawing.Size(26, 26);
            this.clearStudentID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clearStudentID.TabIndex = 30;
            this.clearStudentID.TabStop = false;
            this.clearStudentID.Click += new System.EventHandler(this.clearStudentID_Click);
            // 
            // ReturnModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 460);
            this.Controls.Add(this.clearStudentID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentPicture);
            this.Controls.Add(this.dgvReturn);
            this.Controls.Add(this.label_studentSection);
            this.Controls.Add(this.label_studentName);
            this.Controls.Add(this.txt_Barcode);
            this.Name = "ReturnModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnModuleForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txt_Barcode;
        public System.Windows.Forms.DataGridView dgvReturn;
        public System.Windows.Forms.Label label_studentSection;
        public System.Windows.Forms.Label label_studentName;
        public System.Windows.Forms.PictureBox studentPicture;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Return;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private UserButton clearStudentID;
    }
}
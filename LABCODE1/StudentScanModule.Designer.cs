using System.Windows.Forms;

namespace LABCODE1
{
    partial class StudentScanModule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentScanModule));
            this.cboCam = new System.Windows.Forms.ComboBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label_studentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_studentSection = new System.Windows.Forms.Label();
            this.dgvItemBorrow = new System.Windows.Forms.DataGridView();
            this.col_dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.cmbPickCateg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.clearStudentID = new LABCODE1.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCam
            // 
            this.cboCam.FormattingEnabled = true;
            this.cboCam.Location = new System.Drawing.Point(198, 48);
            this.cboCam.Name = "cboCam";
            this.cboCam.Size = new System.Drawing.Size(293, 21);
            this.cboCam.TabIndex = 0;
            // 
            // btnProceed
            // 
            this.btnProceed.Enabled = false;
            this.btnProceed.Location = new System.Drawing.Point(481, 418);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 1;
            this.btnProceed.Text = "PROCEED";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Enabled = false;
            this.txt_Barcode.Location = new System.Drawing.Point(198, 418);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(245, 20);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.TextChanged += new System.EventHandler(this.txt_Barcode_TextChanged);
            this.txt_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Barcode_KeyPress);
            // 
            // label_studentName
            // 
            this.label_studentName.AutoSize = true;
            this.label_studentName.Location = new System.Drawing.Point(35, 136);
            this.label_studentName.Name = "label_studentName";
            this.label_studentName.Size = new System.Drawing.Size(93, 13);
            this.label_studentName.TabIndex = 4;
            this.label_studentName.Text = "STUDENT NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "SCANNER:";
            // 
            // label_studentSection
            // 
            this.label_studentSection.AutoSize = true;
            this.label_studentSection.Location = new System.Drawing.Point(35, 177);
            this.label_studentSection.Name = "label_studentSection";
            this.label_studentSection.Size = new System.Drawing.Size(54, 13);
            this.label_studentSection.TabIndex = 15;
            this.label_studentSection.Text = "SECTION";
            // 
            // dgvItemBorrow
            // 
            this.dgvItemBorrow.AllowUserToAddRows = false;
            this.dgvItemBorrow.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItemBorrow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemBorrow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemBorrow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_dob,
            this.col_dor,
            this.col_itemid,
            this.col_itemname,
            this.col_size,
            this.Delete});
            this.dgvItemBorrow.EnableHeadersVisualStyles = false;
            this.dgvItemBorrow.Location = new System.Drawing.Point(198, 91);
            this.dgvItemBorrow.Name = "dgvItemBorrow";
            this.dgvItemBorrow.ReadOnly = true;
            this.dgvItemBorrow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvItemBorrow.Size = new System.Drawing.Size(579, 268);
            this.dgvItemBorrow.TabIndex = 16;
            this.dgvItemBorrow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemBorrow_CellClick);
            this.dgvItemBorrow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemBorrow_CellContentClick);
            // 
            // col_dob
            // 
            this.col_dob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_dob.HeaderText = "Date of Borrow";
            this.col_dob.Name = "col_dob";
            this.col_dob.ReadOnly = true;
            this.col_dob.Width = 110;
            // 
            // col_dor
            // 
            this.col_dor.HeaderText = "Date of Return";
            this.col_dor.Name = "col_dor";
            this.col_dor.ReadOnly = true;
            // 
            // col_itemid
            // 
            this.col_itemid.HeaderText = "Item ID";
            this.col_itemid.Name = "col_itemid";
            this.col_itemid.ReadOnly = true;
            // 
            // col_itemname
            // 
            this.col_itemname.HeaderText = "Item Name";
            this.col_itemname.Name = "col_itemname";
            this.col_itemname.ReadOnly = true;
            // 
            // col_size
            // 
            this.col_size.HeaderText = "Size/Calibration";
            this.col_size.Name = "col_size";
            this.col_size.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 5;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(620, 39);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(20, 18);
            this.dateLabel.TabIndex = 17;
            this.dateLabel.Text = "...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbItem
            // 
            this.cmbItem.Enabled = false;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(198, 382);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(268, 21);
            this.cmbItem.TabIndex = 20;
            this.cmbItem.DropDown += new System.EventHandler(this.cmbItem_DropDown);
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            this.cmbItem.TextChanged += new System.EventHandler(this.cmbItem_TextChanged);
            // 
            // cmbPickCateg
            // 
            this.cmbPickCateg.FormattingEnabled = true;
            this.cmbPickCateg.Items.AddRange(new object[] {
            "GENERAL SCIENCE",
            "BIOLOGY",
            "PHYSICS",
            "CHEMISTRY",
            "SUBSTANCES",
            "OTHER"});
            this.cmbPickCateg.Location = new System.Drawing.Point(60, 382);
            this.cmbPickCateg.Name = "cmbPickCateg";
            this.cmbPickCateg.Size = new System.Drawing.Size(121, 21);
            this.cmbPickCateg.TabIndex = 21;
            this.cmbPickCateg.SelectedIndexChanged += new System.EventHandler(this.cmbPickCateg_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "CATEGORY";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(772, 6);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 13;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // clearStudentID
            // 
            this.clearStudentID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearStudentID.Enabled = false;
            this.clearStudentID.Image = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.ImageHover = ((System.Drawing.Image)(resources.GetObject("clearStudentID.ImageHover")));
            this.clearStudentID.ImageNormal = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.Location = new System.Drawing.Point(445, 418);
            this.clearStudentID.Name = "clearStudentID";
            this.clearStudentID.Size = new System.Drawing.Size(21, 20);
            this.clearStudentID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clearStudentID.TabIndex = 24;
            this.clearStudentID.TabStop = false;
            this.clearStudentID.Click += new System.EventHandler(this.clearStudentID_Click_1);
            // 
            // StudentScanModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.clearStudentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPickCateg);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dgvItemBorrow);
            this.Controls.Add(this.label_studentSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.label_studentName);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.cboCam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentScanModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentScanModule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentScanModule_FormClosing);
            this.Load += new System.EventHandler(this.StudentScanModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCam;
        private System.Windows.Forms.Label label_studentName;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_studentSection;
        private Label dateLabel;
        private Timer timer1;
        public TextBox txt_Barcode;
        public Button btnProceed;
        public Button button1;
        public DataGridView dgvItemBorrow;
        private DataGridViewTextBoxColumn col_dob;
        private DataGridViewTextBoxColumn col_dor;
        private DataGridViewTextBoxColumn col_itemid;
        private DataGridViewTextBoxColumn col_itemname;
        private DataGridViewTextBoxColumn col_size;
        private DataGridViewImageColumn Delete;
        public ComboBox cmbItem;
        public ComboBox cmbPickCateg;
        private Label label2;
        private UserButton clearStudentID;
        private DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
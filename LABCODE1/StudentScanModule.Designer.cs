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
            this.btnProceed = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label_studentName = new System.Windows.Forms.Label();
            this.label_studentSection = new System.Windows.Forms.Label();
            this.dgvItemBorrow = new System.Windows.Forms.DataGridView();
            this.col_dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateLabelDate = new System.Windows.Forms.Label();
            this.label_studentID = new System.Windows.Forms.Label();
            this.txt_BarcodeItem = new System.Windows.Forms.TextBox();
            this.label_itemName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.itemPicture = new System.Windows.Forms.PictureBox();
            this.studentPicture = new System.Windows.Forms.PictureBox();
            this.clearStudentID = new LABCODE1.UserButton();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemBorrow)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProceed
            // 
            this.btnProceed.Enabled = false;
            this.btnProceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(429, 380);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(93, 26);
            this.btnProceed.TabIndex = 1;
            this.btnProceed.Text = "PROCEED";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Barcode.Location = new System.Drawing.Point(146, 341);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(245, 26);
            this.txt_Barcode.TabIndex = 3;
            this.txt_Barcode.TextChanged += new System.EventHandler(this.txt_Barcode_TextChanged);
            this.txt_Barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Barcode_KeyPress);
            // 
            // label_studentName
            // 
            this.label_studentName.AutoSize = true;
            this.label_studentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_studentName.Location = new System.Drawing.Point(208, 466);
            this.label_studentName.Name = "label_studentName";
            this.label_studentName.Size = new System.Drawing.Size(160, 24);
            this.label_studentName.TabIndex = 4;
            this.label_studentName.Text = "STUDENT NAME";
            // 
            // label_studentSection
            // 
            this.label_studentSection.AutoSize = true;
            this.label_studentSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_studentSection.Location = new System.Drawing.Point(208, 510);
            this.label_studentSection.Name = "label_studentSection";
            this.label_studentSection.Size = new System.Drawing.Size(93, 24);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemBorrow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemBorrow.ColumnHeadersHeight = 30;
            this.dgvItemBorrow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemBorrow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_dob,
            this.col_dor,
            this.Duration,
            this.col_itemid,
            this.col_itemname,
            this.col_size,
            this.Delete});
            this.dgvItemBorrow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItemBorrow.EnableHeadersVisualStyles = false;
            this.dgvItemBorrow.Location = new System.Drawing.Point(18, 47);
            this.dgvItemBorrow.Name = "dgvItemBorrow";
            this.dgvItemBorrow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvItemBorrow.RowHeadersVisible = false;
            this.dgvItemBorrow.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemBorrow.RowTemplate.Height = 35;
            this.dgvItemBorrow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemBorrow.Size = new System.Drawing.Size(715, 268);
            this.dgvItemBorrow.TabIndex = 16;
            this.dgvItemBorrow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemBorrow_CellClick);
            this.dgvItemBorrow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemBorrow_CellContentClick);
            this.dgvItemBorrow.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemBorrow_CellLeave);
            this.dgvItemBorrow.SelectionChanged += new System.EventHandler(this.dgvItemBorrow_SelectionChanged);
            // 
            // col_dob
            // 
            this.col_dob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_dob.HeaderText = "Date of Borrow";
            this.col_dob.Name = "col_dob";
            this.col_dob.ReadOnly = true;
            this.col_dob.Width = 170;
            // 
            // col_dor
            // 
            this.col_dor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_dor.HeaderText = "Date of Return";
            this.col_dor.Name = "col_dor";
            this.col_dor.ReadOnly = true;
            this.col_dor.Width = 110;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Items.AddRange(new object[] {
            "1 hr",
            "2 hrs",
            "3 hrs",
            "4 hrs",
            "5 hrs",
            "6 hrs",
            "7 hrs"});
            this.Duration.Name = "Duration";
            // 
            // col_itemid
            // 
            this.col_itemid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_itemid.HeaderText = "Item ID";
            this.col_itemid.Name = "col_itemid";
            this.col_itemid.ReadOnly = true;
            this.col_itemid.Width = 50;
            // 
            // col_itemname
            // 
            this.col_itemname.HeaderText = "Item Name";
            this.col_itemname.Name = "col_itemname";
            this.col_itemname.ReadOnly = true;
            this.col_itemname.Width = 130;
            // 
            // col_size
            // 
            this.col_size.HeaderText = "Size/Calibration";
            this.col_size.Name = "col_size";
            this.col_size.ReadOnly = true;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(3, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(25, 24);
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
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(429, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "ITEM SCAN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "STUDENT ID";
            // 
            // dateLabelDate
            // 
            this.dateLabelDate.AutoSize = true;
            this.dateLabelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabelDate.Location = new System.Drawing.Point(565, 341);
            this.dateLabelDate.Name = "dateLabelDate";
            this.dateLabelDate.Size = new System.Drawing.Size(55, 18);
            this.dateLabelDate.TabIndex = 26;
            this.dateLabelDate.Text = "...HIDE";
            this.dateLabelDate.Visible = false;
            // 
            // label_studentID
            // 
            this.label_studentID.AutoSize = true;
            this.label_studentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_studentID.Location = new System.Drawing.Point(208, 423);
            this.label_studentID.Name = "label_studentID";
            this.label_studentID.Size = new System.Drawing.Size(121, 24);
            this.label_studentID.TabIndex = 28;
            this.label_studentID.Text = "STUDENT ID";
            // 
            // txt_BarcodeItem
            // 
            this.txt_BarcodeItem.Enabled = false;
            this.txt_BarcodeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BarcodeItem.Location = new System.Drawing.Point(146, 380);
            this.txt_BarcodeItem.Name = "txt_BarcodeItem";
            this.txt_BarcodeItem.Size = new System.Drawing.Size(245, 26);
            this.txt_BarcodeItem.TabIndex = 29;
            this.txt_BarcodeItem.TextChanged += new System.EventHandler(this.txt_BarcodeItem_TextChanged);
            this.txt_BarcodeItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_BarcodeItem_KeyPress);
            // 
            // label_itemName
            // 
            this.label_itemName.AutoSize = true;
            this.label_itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_itemName.Location = new System.Drawing.Point(953, 473);
            this.label_itemName.Name = "label_itemName";
            this.label_itemName.Size = new System.Drawing.Size(116, 24);
            this.label_itemName.TabIndex = 44;
            this.label_itemName.Text = "ITEM NAME";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Wheat;
            this.flowLayoutPanel1.Controls.Add(this.dateLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 634);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(218, 26);
            this.flowLayoutPanel1.TabIndex = 46;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(747, 510);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(520, 148);
            this.textBox1.TabIndex = 49;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 5;
            // 
            // itemPicture
            // 
            this.itemPicture.BackColor = System.Drawing.SystemColors.Control;
            this.itemPicture.ErrorImage = global::LABCODE1.Properties.Resources.item_unavailable;
            this.itemPicture.Image = global::LABCODE1.Properties.Resources.item_unavailable;
            this.itemPicture.Location = new System.Drawing.Point(747, 47);
            this.itemPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(519, 410);
            this.itemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itemPicture.TabIndex = 43;
            this.itemPicture.TabStop = false;
            // 
            // studentPicture
            // 
            this.studentPicture.BackColor = System.Drawing.SystemColors.Control;
            this.studentPicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("studentPicture.ErrorImage")));
            this.studentPicture.Image = global::LABCODE1.Properties.Resources.user_ddefault;
            this.studentPicture.Location = new System.Drawing.Point(18, 423);
            this.studentPicture.Name = "studentPicture";
            this.studentPicture.Size = new System.Drawing.Size(168, 168);
            this.studentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.studentPicture.TabIndex = 27;
            this.studentPicture.TabStop = false;
            // 
            // clearStudentID
            // 
            this.clearStudentID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearStudentID.Enabled = false;
            this.clearStudentID.Image = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.ImageHover = ((System.Drawing.Image)(resources.GetObject("clearStudentID.ImageHover")));
            this.clearStudentID.ImageNormal = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.clearStudentID.Location = new System.Drawing.Point(393, 341);
            this.clearStudentID.Name = "clearStudentID";
            this.clearStudentID.Size = new System.Drawing.Size(21, 20);
            this.clearStudentID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clearStudentID.TabIndex = 24;
            this.clearStudentID.TabStop = false;
            this.clearStudentID.Click += new System.EventHandler(this.clearStudentID_Click_1);
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
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1244, 12);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 13;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // StudentScanModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 667);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label_itemName);
            this.Controls.Add(this.itemPicture);
            this.Controls.Add(this.txt_BarcodeItem);
            this.Controls.Add(this.label_studentID);
            this.Controls.Add(this.studentPicture);
            this.Controls.Add(this.dateLabelDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clearStudentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvItemBorrow);
            this.Controls.Add(this.label_studentSection);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.label_studentName);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.btnProceed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentScanModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentScanModule";
            this.Load += new System.EventHandler(this.StudentScanModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemBorrow)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearStudentID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_studentName;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label_studentSection;
        private Label dateLabel;
        private Timer timer1;
        public TextBox txt_Barcode;
        public Button btnProceed;
        public Button button1;
        public DataGridView dgvItemBorrow;
        private Label label2;
        private UserButton clearStudentID;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private Label label3;
        private Label dateLabelDate;
        public PictureBox studentPicture;
        private Label label_studentID;
        public TextBox txt_BarcodeItem;
        public PictureBox itemPicture;
        public Label label_itemName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn col_dob;
        private DataGridViewTextBoxColumn col_dor;
        private DataGridViewComboBoxColumn Duration;
        private DataGridViewTextBoxColumn col_itemid;
        private DataGridViewTextBoxColumn col_itemname;
        private DataGridViewTextBoxColumn col_size;
        private DataGridViewImageColumn Delete;
    }
}
namespace LABCODE1
{
    partial class LogsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReturn = new System.Windows.Forms.Label();
            this.labelBorrow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBorrowed = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.br_col_returnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReturned = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelPage = new System.Windows.Forms.Label();
            this.picBorrowLegend = new System.Windows.Forms.PictureBox();
            this.picReturnLegend = new System.Windows.Forms.PictureBox();
            this.btnDelete = new LABCODE1.UserButton();
            this.btnBackup_Restore = new LABCODE1.UserButton();
            this.btnReturnLogs = new LABCODE1.UserButton();
            this.btnBorrowLogs = new LABCODE1.UserButton();
            this.btnPrev1 = new LABCODE1.UserButton();
            this.btnNext1 = new LABCODE1.UserButton();
            this.btnExport = new LABCODE1.UserButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturned)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBorrowLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturnLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup_Restore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrowLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.labelReturn);
            this.panel1.Controls.Add(this.labelBorrow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 52);
            this.panel1.TabIndex = 1;
            // 
            // labelReturn
            // 
            this.labelReturn.AutoSize = true;
            this.labelReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturn.ForeColor = System.Drawing.Color.White;
            this.labelReturn.Location = new System.Drawing.Point(96, 14);
            this.labelReturn.Name = "labelReturn";
            this.labelReturn.Size = new System.Drawing.Size(108, 25);
            this.labelReturn.TabIndex = 2;
            this.labelReturn.Text = "Returned";
            this.labelReturn.Visible = false;
            this.labelReturn.Click += new System.EventHandler(this.labelReturn_Click);
            // 
            // labelBorrow
            // 
            this.labelBorrow.AutoSize = true;
            this.labelBorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBorrow.ForeColor = System.Drawing.Color.White;
            this.labelBorrow.Location = new System.Drawing.Point(96, 14);
            this.labelBorrow.Name = "labelBorrow";
            this.labelBorrow.Size = new System.Drawing.Size(111, 25);
            this.labelBorrow.TabIndex = 1;
            this.labelBorrow.Text = "Borrowed";
            this.labelBorrow.Click += new System.EventHandler(this.labelBorrow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logs";
            // 
            // dgvBorrowed
            // 
            this.dgvBorrowed.AllowUserToAddRows = false;
            this.dgvBorrowed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowed.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrowed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowed.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBorrowed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBorrowed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBorrowed.ColumnHeadersHeight = 35;
            this.dgvBorrowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrowed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column8,
            this.Column5,
            this.Column6,
            this.br_col_returnDate});
            this.dgvBorrowed.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBorrowed.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBorrowed.EnableHeadersVisualStyles = false;
            this.dgvBorrowed.GridColor = System.Drawing.Color.White;
            this.dgvBorrowed.Location = new System.Drawing.Point(82, 92);
            this.dgvBorrowed.Name = "dgvBorrowed";
            this.dgvBorrowed.ReadOnly = true;
            this.dgvBorrowed.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvBorrowed.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBorrowed.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBorrowed.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBorrowed.RowTemplate.Height = 30;
            this.dgvBorrowed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowed.Size = new System.Drawing.Size(694, 365);
            this.dgvBorrowed.TabIndex = 2;
            this.dgvBorrowed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBorrowed_CellFormatting);
            this.dgvBorrowed.SelectionChanged += new System.EventHandler(this.dgvBorrowed_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Student ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Full Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 120F;
            this.Column4.HeaderText = "Year & Section";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.FillWeight = 30F;
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Item Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Item Size";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // br_col_returnDate
            // 
            this.br_col_returnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.br_col_returnDate.HeaderText = "Return Date";
            this.br_col_returnDate.Name = "br_col_returnDate";
            this.br_col_returnDate.ReadOnly = true;
            // 
            // dgvReturned
            // 
            this.dgvReturned.AllowUserToAddRows = false;
            this.dgvReturned.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturned.BackgroundColor = System.Drawing.Color.White;
            this.dgvReturned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReturned.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvReturned.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturned.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReturned.ColumnHeadersHeight = 35;
            this.dgvReturned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReturned.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column7});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReturned.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReturned.EnableHeadersVisualStyles = false;
            this.dgvReturned.GridColor = System.Drawing.Color.White;
            this.dgvReturned.Location = new System.Drawing.Point(82, 92);
            this.dgvReturned.Name = "dgvReturned";
            this.dgvReturned.ReadOnly = true;
            this.dgvReturned.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvReturned.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReturned.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReturned.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturned.RowTemplate.Height = 30;
            this.dgvReturned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturned.Size = new System.Drawing.Size(694, 365);
            this.dgvReturned.TabIndex = 3;
            this.dgvReturned.Visible = false;
            this.dgvReturned.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvReturned_CellFormatting);
            this.dgvReturned.SelectionChanged += new System.EventHandler(this.dgvReturned_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Returned";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Student ID";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.HeaderText = "Full Name";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column12.HeaderText = "Year & Section";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column13.FillWeight = 35F;
            this.Column13.HeaderText = "ID";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column14.HeaderText = "Item Name";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column15.HeaderText = "Item Size";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column16.HeaderText = "Remarks";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Replacement";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn3.HeaderText = "Replacement";
            this.dataGridViewImageColumn3.Image = global::LABCODE1.Properties.Resources.replacement_20pixels;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnPrev1);
            this.flowLayoutPanel1.Controls.Add(this.labelPage);
            this.flowLayoutPanel1.Controls.Add(this.btnNext1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(269, 494);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(309, 54);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // labelPage
            // 
            this.labelPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPage.AutoSize = true;
            this.labelPage.BackColor = System.Drawing.Color.White;
            this.labelPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPage.Location = new System.Drawing.Point(114, 18);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(40, 16);
            this.labelPage.TabIndex = 2;
            this.labelPage.Text = "Page";
            // 
            // picBorrowLegend
            // 
            this.picBorrowLegend.BackColor = System.Drawing.Color.Transparent;
            this.picBorrowLegend.Image = ((System.Drawing.Image)(resources.GetObject("picBorrowLegend.Image")));
            this.picBorrowLegend.Location = new System.Drawing.Point(344, 31);
            this.picBorrowLegend.Name = "picBorrowLegend";
            this.picBorrowLegend.Size = new System.Drawing.Size(158, 45);
            this.picBorrowLegend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBorrowLegend.TabIndex = 12;
            this.picBorrowLegend.TabStop = false;
            // 
            // picReturnLegend
            // 
            this.picReturnLegend.BackColor = System.Drawing.Color.Transparent;
            this.picReturnLegend.Image = ((System.Drawing.Image)(resources.GetObject("picReturnLegend.Image")));
            this.picReturnLegend.Location = new System.Drawing.Point(344, 31);
            this.picReturnLegend.Name = "picReturnLegend";
            this.picReturnLegend.Size = new System.Drawing.Size(158, 45);
            this.picReturnLegend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReturnLegend.TabIndex = 13;
            this.picReturnLegend.TabStop = false;
            this.picReturnLegend.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageHover")));
            this.btnDelete.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageNormal")));
            this.btnDelete.Location = new System.Drawing.Point(688, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 36);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDelete.TabIndex = 11;
            this.btnDelete.TabStop = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBackup_Restore
            // 
            this.btnBackup_Restore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup_Restore.BackColor = System.Drawing.Color.Transparent;
            this.btnBackup_Restore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup_Restore.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup_Restore.Image")));
            this.btnBackup_Restore.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnBackup_Restore.ImageHover")));
            this.btnBackup_Restore.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnBackup_Restore.ImageNormal")));
            this.btnBackup_Restore.Location = new System.Drawing.Point(609, 481);
            this.btnBackup_Restore.Name = "btnBackup_Restore";
            this.btnBackup_Restore.Size = new System.Drawing.Size(167, 63);
            this.btnBackup_Restore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBackup_Restore.TabIndex = 10;
            this.btnBackup_Restore.TabStop = false;
            this.btnBackup_Restore.Click += new System.EventHandler(this.btnBackup_Restore_Click);
            // 
            // btnReturnLogs
            // 
            this.btnReturnLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnLogs.Image")));
            this.btnReturnLogs.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnReturnLogs.ImageHover")));
            this.btnReturnLogs.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReturnLogs.ImageNormal")));
            this.btnReturnLogs.Location = new System.Drawing.Point(213, 23);
            this.btnReturnLogs.Name = "btnReturnLogs";
            this.btnReturnLogs.Size = new System.Drawing.Size(125, 63);
            this.btnReturnLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnReturnLogs.TabIndex = 9;
            this.btnReturnLogs.TabStop = false;
            this.btnReturnLogs.Click += new System.EventHandler(this.btnReturnLogs_Click);
            // 
            // btnBorrowLogs
            // 
            this.btnBorrowLogs.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrowLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrowLogs.Image")));
            this.btnBorrowLogs.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnBorrowLogs.ImageHover")));
            this.btnBorrowLogs.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnBorrowLogs.ImageNormal")));
            this.btnBorrowLogs.Location = new System.Drawing.Point(82, 23);
            this.btnBorrowLogs.Name = "btnBorrowLogs";
            this.btnBorrowLogs.Size = new System.Drawing.Size(125, 63);
            this.btnBorrowLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBorrowLogs.TabIndex = 8;
            this.btnBorrowLogs.TabStop = false;
            this.btnBorrowLogs.Click += new System.EventHandler(this.btnBorrowLogs_Click);
            // 
            // btnPrev1
            // 
            this.btnPrev1.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev1.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev1.Image")));
            this.btnPrev1.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnPrev1.ImageHover")));
            this.btnPrev1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnPrev1.ImageNormal")));
            this.btnPrev1.Location = new System.Drawing.Point(3, 3);
            this.btnPrev1.Name = "btnPrev1";
            this.btnPrev1.Size = new System.Drawing.Size(105, 47);
            this.btnPrev1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrev1.TabIndex = 7;
            this.btnPrev1.TabStop = false;
            this.btnPrev1.Click += new System.EventHandler(this.btnPrev1_Click);
            // 
            // btnNext1
            // 
            this.btnNext1.BackColor = System.Drawing.Color.Transparent;
            this.btnNext1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext1.Image = ((System.Drawing.Image)(resources.GetObject("btnNext1.Image")));
            this.btnNext1.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnNext1.ImageHover")));
            this.btnNext1.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnNext1.ImageNormal")));
            this.btnNext1.Location = new System.Drawing.Point(160, 3);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(105, 47);
            this.btnNext1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext1.TabIndex = 6;
            this.btnNext1.TabStop = false;
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageHover")));
            this.btnExport.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageNormal")));
            this.btnExport.Location = new System.Drawing.Point(703, -2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(126, 56);
            this.btnExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExport.TabIndex = 12;
            this.btnExport.TabStop = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(841, 606);
            this.Controls.Add(this.picReturnLegend);
            this.Controls.Add(this.picBorrowLegend);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBackup_Restore);
            this.Controls.Add(this.btnReturnLogs);
            this.Controls.Add(this.btnBorrowLogs);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvReturned);
            this.Controls.Add(this.dgvBorrowed);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturned)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBorrowLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReturnLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup_Restore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrowLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBorrow;
        private System.Windows.Forms.Label labelReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn br_col_returnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.DataGridView dgvReturned;
        public System.Windows.Forms.DataGridView dgvBorrowed;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserButton btnPrev1;
        private System.Windows.Forms.Label labelPage;
        private UserButton btnNext1;
        private UserButton btnBorrowLogs;
        private UserButton btnReturnLogs;
        private UserButton btnBackup_Restore;
        private UserButton btnDelete;
        private UserButton btnExport;
        private System.Windows.Forms.PictureBox picBorrowLegend;
        private System.Windows.Forms.PictureBox picReturnLegend;
    }
}
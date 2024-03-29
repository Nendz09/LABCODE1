﻿namespace LABCODE1
{
    partial class InventoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportPDF = new LABCODE1.UserButton();
            this.btnExport = new LABCODE1.UserButton();
            this.btnAdd = new LABCODE1.UserButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLab = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Replacement = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.labelPage = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrev1 = new LABCODE1.UserButton();
            this.btnNext1 = new LABCODE1.UserButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbCateg = new System.Windows.Forms.ComboBox();
            this.searchSizeCalibration = new LABCODE1.UserTextbox();
            this.userTextbox1 = new LABCODE1.UserTextbox();
            this.countLabel = new System.Windows.Forms.Label();
            this.reportBtn = new LABCODE1.UserButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLab)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.reportBtn);
            this.panel1.Controls.Add(this.btnExportPDF);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.Image")));
            this.btnExportPDF.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.ImageHover")));
            this.btnExportPDF.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.ImageNormal")));
            this.btnExportPDF.Location = new System.Drawing.Point(438, -3);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(126, 56);
            this.btnExportPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExportPDF.TabIndex = 5;
            this.btnExportPDF.TabStop = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageHover")));
            this.btnExport.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageNormal")));
            this.btnExport.Location = new System.Drawing.Point(570, -3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(126, 56);
            this.btnExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExport.TabIndex = 4;
            this.btnExport.TabStop = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageHover")));
            this.btnAdd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageNormal")));
            this.btnAdd.Location = new System.Drawing.Point(702, -3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 56);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laboratory Equipment";
            // 
            // dgvLab
            // 
            this.dgvLab.AllowUserToAddRows = false;
            this.dgvLab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLab.BackgroundColor = System.Drawing.Color.White;
            this.dgvLab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLab.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLab.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLab.ColumnHeadersHeight = 35;
            this.dgvLab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.col_status,
            this.Column5,
            this.Edit,
            this.Delete,
            this.Replacement});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLab.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLab.EnableHeadersVisualStyles = false;
            this.dgvLab.GridColor = System.Drawing.Color.White;
            this.dgvLab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvLab.Location = new System.Drawing.Point(82, 92);
            this.dgvLab.Name = "dgvLab";
            this.dgvLab.ReadOnly = true;
            this.dgvLab.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvLab.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLab.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLab.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvLab.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLab.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLab.RowTemplate.Height = 40;
            this.dgvLab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLab.Size = new System.Drawing.Size(694, 365);
            this.dgvLab.TabIndex = 1;
            this.dgvLab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLab_CellContentClick);
            this.dgvLab.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLab_CellFormatting);
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 42;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 36.2891F;
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 30.90991F;
            this.Column3.HeaderText = "Category";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 25.10812F;
            this.Column4.HeaderText = "Size/Calibration";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_status.FillWeight = 20F;
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Acquired Remarks";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.FillWeight = 285.1613F;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 11;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.FillWeight = 55.91398F;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 11;
            // 
            // Replacement
            // 
            this.Replacement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Replacement.FillWeight = 55.91398F;
            this.Replacement.HeaderText = "";
            this.Replacement.Image = ((System.Drawing.Image)(resources.GetObject("Replacement.Image")));
            this.Replacement.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Replacement.Name = "Replacement";
            this.Replacement.ReadOnly = true;
            this.Replacement.Width = 11;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn3.HeaderText = "Replacement";
            this.dataGridViewImageColumn3.Image = global::LABCODE1.Properties.Resources.replacement_20pixels;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnPrev1);
            this.flowLayoutPanel1.Controls.Add(this.labelPage);
            this.flowLayoutPanel1.Controls.Add(this.btnNext1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(261, 498);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(344, 54);
            this.flowLayoutPanel1.TabIndex = 5;
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
            // cmbStatus
            // 
            this.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Borrowed",
            "Available",
            "Unavailable"});
            this.cmbStatus.Location = new System.Drawing.Point(145, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(115, 28);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Status/Category:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.cmbStatus);
            this.flowLayoutPanel2.Controls.Add(this.cmbCateg);
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(561, 54);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(472, 32);
            this.flowLayoutPanel2.TabIndex = 36;
            // 
            // cmbCateg
            // 
            this.cmbCateg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCateg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCateg.FormattingEnabled = true;
            this.cmbCateg.Location = new System.Drawing.Point(266, 3);
            this.cmbCateg.Name = "cmbCateg";
            this.cmbCateg.Size = new System.Drawing.Size(149, 28);
            this.cmbCateg.TabIndex = 37;
            this.cmbCateg.DropDown += new System.EventHandler(this.cmbCateg_DropDown);
            this.cmbCateg.SelectedIndexChanged += new System.EventHandler(this.cmbCateg_SelectedIndexChanged);
            // 
            // searchSizeCalibration
            // 
            this.searchSizeCalibration.BackColor = System.Drawing.SystemColors.Window;
            this.searchSizeCalibration.BorderColor = System.Drawing.Color.Green;
            this.searchSizeCalibration.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchSizeCalibration.BorderRadius = 15;
            this.searchSizeCalibration.BorderSize = 2;
            this.searchSizeCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchSizeCalibration.ForeColor = System.Drawing.Color.Black;
            this.searchSizeCalibration.Location = new System.Drawing.Point(358, 54);
            this.searchSizeCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.searchSizeCalibration.Multiline = false;
            this.searchSizeCalibration.Name = "searchSizeCalibration";
            this.searchSizeCalibration.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.searchSizeCalibration.PasswordChar = false;
            this.searchSizeCalibration.PlaceholderColor = System.Drawing.Color.Gray;
            this.searchSizeCalibration.PlaceholderText = "Search Size/Calibration";
            this.searchSizeCalibration.Size = new System.Drawing.Size(196, 31);
            this.searchSizeCalibration.TabIndex = 6;
            this.searchSizeCalibration.Texts = "";
            this.searchSizeCalibration.UnderlinedStyle = false;
            this.searchSizeCalibration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchSizeCalibration_KeyDown);
            // 
            // userTextbox1
            // 
            this.userTextbox1.BackColor = System.Drawing.SystemColors.Window;
            this.userTextbox1.BorderColor = System.Drawing.Color.Green;
            this.userTextbox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.userTextbox1.BorderRadius = 15;
            this.userTextbox1.BorderSize = 2;
            this.userTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextbox1.ForeColor = System.Drawing.Color.Black;
            this.userTextbox1.Location = new System.Drawing.Point(73, 54);
            this.userTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.userTextbox1.Multiline = false;
            this.userTextbox1.Name = "userTextbox1";
            this.userTextbox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.userTextbox1.PasswordChar = false;
            this.userTextbox1.PlaceholderColor = System.Drawing.Color.Gray;
            this.userTextbox1.PlaceholderText = "Search Equipment Name or ID";
            this.userTextbox1.Size = new System.Drawing.Size(277, 31);
            this.userTextbox1.TabIndex = 3;
            this.userTextbox1.Texts = "";
            this.userTextbox1.UnderlinedStyle = false;
            this.userTextbox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userTextbox1_KeyDown);
            // 
            // countLabel
            // 
            this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(78, 460);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(62, 24);
            this.countLabel.TabIndex = 38;
            this.countLabel.Text = "count";
            // 
            // reportBtn
            // 
            this.reportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportBtn.Image")));
            this.reportBtn.ImageHover = ((System.Drawing.Image)(resources.GetObject("reportBtn.ImageHover")));
            this.reportBtn.ImageNormal = ((System.Drawing.Image)(resources.GetObject("reportBtn.ImageNormal")));
            this.reportBtn.Location = new System.Drawing.Point(306, -3);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(126, 56);
            this.reportBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reportBtn.TabIndex = 6;
            this.reportBtn.TabStop = false;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(841, 606);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.searchSizeCalibration);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.userTextbox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLab);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLab)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private UserButton btnAdd;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private UserTextbox userTextbox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserButton btnNext1;
        private UserButton btnPrev1;
        public System.Windows.Forms.DataGridView dgvLab;
        public UserButton btnExport;
        private System.Windows.Forms.DataGridViewImageColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Replacement;
        public UserButton btnExportPDF;
        private UserTextbox searchSizeCalibration;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox cmbCateg;
        public System.Windows.Forms.Label countLabel;
        public UserButton reportBtn;
    }
}
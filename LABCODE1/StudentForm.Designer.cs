namespace LABCODE1
{
    partial class StudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReturn = new LABCODE1.UserButton();
            this.searchTextbox = new LABCODE1.UserTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrow = new LABCODE1.UserButton();
            this.btnAdd = new LABCODE1.UserButton();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewImageColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.searchTextbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBorrow);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 52);
            this.panel1.TabIndex = 2;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DarkGreen;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnReturn.ImageHover")));
            this.btnReturn.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReturn.ImageNormal")));
            this.btnReturn.Location = new System.Drawing.Point(723, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(49, 46);
            this.btnReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnReturn.TabIndex = 6;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // searchTextbox
            // 
            this.searchTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.searchTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.searchTextbox.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.searchTextbox.BorderRadius = 15;
            this.searchTextbox.BorderSize = 2;
            this.searchTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextbox.ForeColor = System.Drawing.Color.Black;
            this.searchTextbox.Location = new System.Drawing.Point(235, 11);
            this.searchTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextbox.Multiline = false;
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.searchTextbox.PasswordChar = false;
            this.searchTextbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.searchTextbox.PlaceholderText = "Search...";
            this.searchTextbox.Size = new System.Drawing.Size(200, 31);
            this.searchTextbox.TabIndex = 5;
            this.searchTextbox.Texts = "";
            this.searchTextbox.UnderlinedStyle = false;
            this.searchTextbox._TextChanged += new System.EventHandler(this.searchTextbox__TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(490, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Borrow/Return";
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.DarkGreen;
            this.btnBorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrow.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrow.Image")));
            this.btnBorrow.ImageHover = null;
            this.btnBorrow.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnBorrow.ImageNormal")));
            this.btnBorrow.Location = new System.Drawing.Point(658, 0);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(60, 49);
            this.btnBorrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBorrow.TabIndex = 3;
            this.btnBorrow.TabStop = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageHover")));
            this.btnAdd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageNormal")));
            this.btnAdd.Location = new System.Drawing.Point(792, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 36);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudents.ColumnHeadersHeight = 35;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.View,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.GridColor = System.Drawing.Color.Black;
            this.dgvStudents.Location = new System.Drawing.Point(0, 0);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvStudents.Size = new System.Drawing.Size(841, 606);
            this.dgvStudents.TabIndex = 3;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Student ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Full Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "Year and Section";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 40F;
            this.Column4.HeaderText = "Phone Number";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // View
            // 
            this.View.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.View.HeaderText = "";
            this.View.Image = ((System.Drawing.Image)(resources.GetObject("View.Image")));
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Width = 5;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 5;
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
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStudents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private UserButton btnAdd;
        private System.Windows.Forms.DataGridView dgvStudents;
        private UserButton btnBorrow;
        private System.Windows.Forms.Label label2;
        private UserTextbox searchTextbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn View;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private UserButton btnReturn;
    }
}
namespace LABCODE1
{
    partial class AddCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCateg = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtCategName = new LABCODE1.UserTextbox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new LABCODE1.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "List of Categories";
            // 
            // dgvCateg
            // 
            this.dgvCateg.AllowUserToAddRows = false;
            this.dgvCateg.BackgroundColor = System.Drawing.Color.White;
            this.dgvCateg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCateg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCateg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCateg.ColumnHeadersVisible = false;
            this.dgvCateg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Delete});
            this.dgvCateg.EnableHeadersVisualStyles = false;
            this.dgvCateg.GridColor = System.Drawing.Color.White;
            this.dgvCateg.Location = new System.Drawing.Point(51, 174);
            this.dgvCateg.Name = "dgvCateg";
            this.dgvCateg.ReadOnly = true;
            this.dgvCateg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvCateg.RowHeadersVisible = false;
            this.dgvCateg.Size = new System.Drawing.Size(200, 150);
            this.dgvCateg.TabIndex = 5;
            this.dgvCateg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCateg_CellContentClick);
            this.dgvCateg.SelectionChanged += new System.EventHandler(this.dgvCateg_SelectionChanged);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Category Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // txtCategName
            // 
            this.txtCategName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCategName.BorderFocusColor = System.Drawing.Color.Empty;
            this.txtCategName.BorderRadius = 0;
            this.txtCategName.BorderSize = 2;
            this.txtCategName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategName.ForeColor = System.Drawing.Color.Black;
            this.txtCategName.Location = new System.Drawing.Point(51, 74);
            this.txtCategName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategName.Multiline = false;
            this.txtCategName.Name = "txtCategName";
            this.txtCategName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCategName.PasswordChar = false;
            this.txtCategName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCategName.PlaceholderText = "Category Name";
            this.txtCategName.Size = new System.Drawing.Size(200, 31);
            this.txtCategName.TabIndex = 27;
            this.txtCategName.Texts = "";
            this.txtCategName.UnderlinedStyle = false;
            this.txtCategName._TextChanged += new System.EventHandler(this.txtCategName__TextChanged);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::LABCODE1.Properties.Resources.ekis_border_25px_red;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = global::LABCODE1.Properties.Resources.general_add_btn;
            this.btnAdd.ImageHover = global::LABCODE1.Properties.Resources.general_add_btn_highlight;
            this.btnAdd.ImageNormal = global::LABCODE1.Properties.Resources.general_add_btn;
            this.btnAdd.Location = new System.Drawing.Point(92, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(118, 53);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 25;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 425);
            this.Controls.Add(this.txtCategName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvCateg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCategory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public UserButton btnAdd;
        public UserTextbox txtCategName;
        public System.Windows.Forms.DataGridView dgvCateg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
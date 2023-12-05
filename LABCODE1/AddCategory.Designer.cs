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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategory));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCateg = new System.Windows.Forms.DataGridView();
            this.txtCategName = new LABCODE1.UserTextbox();
            this.btnAdd = new LABCODE1.UserButton();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCateg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "List of Categories";
            // 
            // dgvCateg
            // 
            this.dgvCateg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCateg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dgvCateg.Location = new System.Drawing.Point(61, 215);
            this.dgvCateg.Name = "dgvCateg";
            this.dgvCateg.RowHeadersVisible = false;
            this.dgvCateg.Size = new System.Drawing.Size(469, 150);
            this.dgvCateg.TabIndex = 5;
            // 
            // txtCategName
            // 
            this.txtCategName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCategName.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtCategName.BorderFocusColor = System.Drawing.Color.Empty;
            this.txtCategName.BorderRadius = 0;
            this.txtCategName.BorderSize = 2;
            this.txtCategName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategName.ForeColor = System.Drawing.Color.Gray;
            this.txtCategName.Location = new System.Drawing.Point(232, 118);
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
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageHover")));
            this.btnAdd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageNormal")));
            this.btnAdd.Location = new System.Drawing.Point(503, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(176, 56);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 25;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Category Name";
            this.Column2.Name = "Column2";
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCategName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvCateg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.DataGridView dgvCateg;
        public UserButton btnAdd;
        public UserTextbox txtCategName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
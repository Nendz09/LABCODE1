namespace LABCODE1
{
    partial class ReturnRemarksForm
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_remarks = new LABCODE1.UserTextbox();
            this.txt_itemName = new System.Windows.Forms.Label();
            this.txt_itemId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_Yes = new System.Windows.Forms.RadioButton();
            this.rb_No = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(497, 388);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "REMARKS";
            // 
            // txt_remarks
            // 
            this.txt_remarks.BackColor = System.Drawing.SystemColors.Window;
            this.txt_remarks.BorderColor = System.Drawing.Color.Green;
            this.txt_remarks.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_remarks.BorderRadius = 15;
            this.txt_remarks.BorderSize = 3;
            this.txt_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.ForeColor = System.Drawing.Color.Black;
            this.txt_remarks.Location = new System.Drawing.Point(205, 231);
            this.txt_remarks.Margin = new System.Windows.Forms.Padding(4);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_remarks.PasswordChar = false;
            this.txt_remarks.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_remarks.PlaceholderText = "Remarks";
            this.txt_remarks.Size = new System.Drawing.Size(200, 127);
            this.txt_remarks.TabIndex = 20;
            this.txt_remarks.Texts = "";
            this.txt_remarks.UnderlinedStyle = false;
            // 
            // txt_itemName
            // 
            this.txt_itemName.AutoSize = true;
            this.txt_itemName.Location = new System.Drawing.Point(142, 110);
            this.txt_itemName.Name = "txt_itemName";
            this.txt_itemName.Size = new System.Drawing.Size(67, 13);
            this.txt_itemName.TabIndex = 21;
            this.txt_itemName.Text = "ITEM NAME";
            // 
            // txt_itemId
            // 
            this.txt_itemId.AutoSize = true;
            this.txt_itemId.Location = new System.Drawing.Point(273, 110);
            this.txt_itemId.Name = "txt_itemId";
            this.txt_itemId.Size = new System.Drawing.Size(47, 13);
            this.txt_itemId.TabIndex = 22;
            this.txt_itemId.Text = "ITEM ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "REPLACEMENT";
            // 
            // rb_Yes
            // 
            this.rb_Yes.AutoSize = true;
            this.rb_Yes.Location = new System.Drawing.Point(230, 371);
            this.rb_Yes.Name = "rb_Yes";
            this.rb_Yes.Size = new System.Drawing.Size(43, 17);
            this.rb_Yes.TabIndex = 27;
            this.rb_Yes.TabStop = true;
            this.rb_Yes.Text = "Yes";
            this.rb_Yes.UseVisualStyleBackColor = true;
            // 
            // rb_No
            // 
            this.rb_No.AutoSize = true;
            this.rb_No.Location = new System.Drawing.Point(337, 371);
            this.rb_No.Name = "rb_No";
            this.rb_No.Size = new System.Drawing.Size(39, 17);
            this.rb_No.TabIndex = 28;
            this.rb_No.TabStop = true;
            this.rb_No.Text = "No";
            this.rb_No.UseVisualStyleBackColor = true;
            // 
            // ReturnRemarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rb_No);
            this.Controls.Add(this.rb_Yes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_itemId);
            this.Controls.Add(this.txt_itemName);
            this.Controls.Add(this.txt_remarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReturn);
            this.Name = "ReturnRemarksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnRemarksForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label1;
        private UserTextbox txt_remarks;
        public System.Windows.Forms.Label txt_itemName;
        public System.Windows.Forms.Label txt_itemId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rb_Yes;
        public System.Windows.Forms.RadioButton rb_No;
    }
}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnRemarksForm));
            this.btnReturn = new System.Windows.Forms.Button();
            this.txt_itemName = new System.Windows.Forms.Label();
            this.txt_itemId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_Yes = new System.Windows.Forms.RadioButton();
            this.rb_No = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_studSec = new System.Windows.Forms.Label();
            this.txt_studName = new System.Windows.Forms.Label();
            this.txt_studId = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.currentDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.borrowDate = new System.Windows.Forms.Label();
            this.txt_itemSize = new System.Windows.Forms.Label();
            this.txt_remarks1 = new LABCODE1.UserTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(179, 453);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txt_itemName
            // 
            this.txt_itemName.AutoSize = true;
            this.txt_itemName.Location = new System.Drawing.Point(176, 562);
            this.txt_itemName.Name = "txt_itemName";
            this.txt_itemName.Size = new System.Drawing.Size(67, 13);
            this.txt_itemName.TabIndex = 21;
            this.txt_itemName.Text = "ITEM NAME";
            // 
            // txt_itemId
            // 
            this.txt_itemId.AutoSize = true;
            this.txt_itemId.Location = new System.Drawing.Point(12, 562);
            this.txt_itemId.Name = "txt_itemId";
            this.txt_itemId.Size = new System.Drawing.Size(47, 13);
            this.txt_itemId.TabIndex = 22;
            this.txt_itemId.Text = "ITEM ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "REPLACEMENT";
            // 
            // rb_Yes
            // 
            this.rb_Yes.AutoSize = true;
            this.rb_Yes.Location = new System.Drawing.Point(164, 409);
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
            this.rb_No.Location = new System.Drawing.Point(271, 409);
            this.rb_No.Name = "rb_No";
            this.rb_No.Size = new System.Drawing.Size(39, 17);
            this.rb_No.TabIndex = 28;
            this.rb_No.TabStop = true;
            this.rb_No.Text = "No";
            this.rb_No.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.txt_studSec);
            this.panel1.Controls.Add(this.txt_studName);
            this.panel1.Controls.Add(this.txt_studId);
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 65);
            this.panel1.TabIndex = 29;
            // 
            // txt_studSec
            // 
            this.txt_studSec.AutoSize = true;
            this.txt_studSec.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_studSec.ForeColor = System.Drawing.Color.White;
            this.txt_studSec.Location = new System.Drawing.Point(244, 9);
            this.txt_studSec.Name = "txt_studSec";
            this.txt_studSec.Size = new System.Drawing.Size(114, 19);
            this.txt_studSec.TabIndex = 34;
            this.txt_studSec.Text = "STUDENT SEC";
            // 
            // txt_studName
            // 
            this.txt_studName.AutoSize = true;
            this.txt_studName.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_studName.ForeColor = System.Drawing.Color.White;
            this.txt_studName.Location = new System.Drawing.Point(12, 10);
            this.txt_studName.Name = "txt_studName";
            this.txt_studName.Size = new System.Drawing.Size(129, 19);
            this.txt_studName.TabIndex = 33;
            this.txt_studName.Text = "STUDENT NAME";
            // 
            // txt_studId
            // 
            this.txt_studId.AutoSize = true;
            this.txt_studId.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_studId.ForeColor = System.Drawing.Color.White;
            this.txt_studId.Location = new System.Drawing.Point(11, 36);
            this.txt_studId.Name = "txt_studId";
            this.txt_studId.Size = new System.Drawing.Size(101, 19);
            this.txt_studId.TabIndex = 32;
            this.txt_studId.Text = "STUDENT ID";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(393, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 30;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // currentDate
            // 
            this.currentDate.AutoSize = true;
            this.currentDate.Location = new System.Drawing.Point(245, 105);
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(16, 13);
            this.currentDate.TabIndex = 30;
            this.currentDate.Text = "...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(245, 79);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(92, 13);
            this.labelDate.TabIndex = 31;
            this.labelDate.Text = "CURRENT DATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "DATE BORROWED";
            // 
            // borrowDate
            // 
            this.borrowDate.AutoSize = true;
            this.borrowDate.Location = new System.Drawing.Point(13, 105);
            this.borrowDate.Name = "borrowDate";
            this.borrowDate.Size = new System.Drawing.Size(16, 13);
            this.borrowDate.TabIndex = 33;
            this.borrowDate.Text = "...";
            // 
            // txt_itemSize
            // 
            this.txt_itemSize.AutoSize = true;
            this.txt_itemSize.Location = new System.Drawing.Point(323, 562);
            this.txt_itemSize.Name = "txt_itemSize";
            this.txt_itemSize.Size = new System.Drawing.Size(60, 13);
            this.txt_itemSize.TabIndex = 34;
            this.txt_itemSize.Text = "ITEM SIZE";
            // 
            // txt_remarks1
            // 
            this.txt_remarks1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_remarks1.BorderColor = System.Drawing.Color.Green;
            this.txt_remarks1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_remarks1.BorderRadius = 15;
            this.txt_remarks1.BorderSize = 3;
            this.txt_remarks1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks1.ForeColor = System.Drawing.Color.Black;
            this.txt_remarks1.Location = new System.Drawing.Point(139, 269);
            this.txt_remarks1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_remarks1.Multiline = true;
            this.txt_remarks1.Name = "txt_remarks1";
            this.txt_remarks1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_remarks1.PasswordChar = false;
            this.txt_remarks1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_remarks1.PlaceholderText = "Remarks";
            this.txt_remarks1.Size = new System.Drawing.Size(200, 127);
            this.txt_remarks1.TabIndex = 20;
            this.txt_remarks1.Texts = "";
            this.txt_remarks1.UnderlinedStyle = false;
            // 
            // ReturnRemarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 584);
            this.Controls.Add(this.txt_itemSize);
            this.Controls.Add(this.borrowDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.currentDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rb_No);
            this.Controls.Add(this.rb_Yes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_itemId);
            this.Controls.Add(this.txt_itemName);
            this.Controls.Add(this.txt_remarks1);
            this.Controls.Add(this.btnReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnRemarksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnRemarksForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        public System.Windows.Forms.Label txt_itemName;
        public System.Windows.Forms.Label txt_itemId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rb_Yes;
        public System.Windows.Forms.RadioButton rb_No;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label currentDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.Label txt_studId;
        public System.Windows.Forms.Label txt_studName;
        public System.Windows.Forms.Label txt_studSec;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label txt_itemSize;
        public System.Windows.Forms.Label borrowDate;
        public UserTextbox txt_remarks1;
    }
}
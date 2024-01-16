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
            this.txt_itemName = new System.Windows.Forms.Label();
            this.txt_itemId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_Yes = new System.Windows.Forms.RadioButton();
            this.rb_No = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.borrowDate = new System.Windows.Forms.Label();
            this.txt_studSec = new System.Windows.Forms.Label();
            this.txt_studName = new System.Windows.Forms.Label();
            this.txt_studId = new System.Windows.Forms.Label();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.currentDateAndTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_itemSize = new System.Windows.Forms.Label();
            this.itemPicture = new System.Windows.Forms.PictureBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_remarks1 = new LABCODE1.UserTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.userBtnReturn = new LABCODE1.UserButton();
            this.returnBtnPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBtnReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_itemName
            // 
            this.txt_itemName.AutoSize = true;
            this.txt_itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemName.Location = new System.Drawing.Point(547, 120);
            this.txt_itemName.Name = "txt_itemName";
            this.txt_itemName.Size = new System.Drawing.Size(97, 20);
            this.txt_itemName.TabIndex = 21;
            this.txt_itemName.Text = "ITEM NAME";
            this.txt_itemName.TextChanged += new System.EventHandler(this.txt_itemName_TextChanged);
            // 
            // txt_itemId
            // 
            this.txt_itemId.AutoSize = true;
            this.txt_itemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemId.Location = new System.Drawing.Point(447, 120);
            this.txt_itemId.Name = "txt_itemId";
            this.txt_itemId.Size = new System.Drawing.Size(68, 20);
            this.txt_itemId.TabIndex = 22;
            this.txt_itemId.Text = "ITEM ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "REPLACEMENT";
            // 
            // rb_Yes
            // 
            this.rb_Yes.AutoSize = true;
            this.rb_Yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Yes.Location = new System.Drawing.Point(3, 23);
            this.rb_Yes.Name = "rb_Yes";
            this.rb_Yes.Size = new System.Drawing.Size(55, 24);
            this.rb_Yes.TabIndex = 27;
            this.rb_Yes.TabStop = true;
            this.rb_Yes.Text = "Yes";
            this.rb_Yes.UseVisualStyleBackColor = true;
            // 
            // rb_No
            // 
            this.rb_No.AutoSize = true;
            this.rb_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_No.Location = new System.Drawing.Point(64, 23);
            this.rb_No.Name = "rb_No";
            this.rb_No.Size = new System.Drawing.Size(47, 24);
            this.rb_No.TabIndex = 28;
            this.rb_No.TabStop = true;
            this.rb_No.Text = "No";
            this.rb_No.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.borrowDate);
            this.panel1.Controls.Add(this.txt_studSec);
            this.panel1.Controls.Add(this.txt_studName);
            this.panel1.Controls.Add(this.txt_studId);
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.currentDateAndTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 65);
            this.panel1.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(463, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "BORROWED DATE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(482, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "CURRENT DATE:";
            // 
            // borrowDate
            // 
            this.borrowDate.AutoSize = true;
            this.borrowDate.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowDate.ForeColor = System.Drawing.Color.White;
            this.borrowDate.Location = new System.Drawing.Point(623, 7);
            this.borrowDate.Name = "borrowDate";
            this.borrowDate.Size = new System.Drawing.Size(21, 19);
            this.borrowDate.TabIndex = 33;
            this.borrowDate.Text = "...";
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
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(771, 4);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 20);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 30;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // currentDateAndTime
            // 
            this.currentDateAndTime.AutoSize = true;
            this.currentDateAndTime.Font = new System.Drawing.Font("Novecento DemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateAndTime.ForeColor = System.Drawing.Color.White;
            this.currentDateAndTime.Location = new System.Drawing.Point(623, 36);
            this.currentDateAndTime.Name = "currentDateAndTime";
            this.currentDateAndTime.Size = new System.Drawing.Size(21, 19);
            this.currentDateAndTime.TabIndex = 30;
            this.currentDateAndTime.Text = "...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_itemSize
            // 
            this.txt_itemSize.AutoSize = true;
            this.txt_itemSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_itemSize.Location = new System.Drawing.Point(689, 120);
            this.txt_itemSize.Name = "txt_itemSize";
            this.txt_itemSize.Size = new System.Drawing.Size(88, 20);
            this.txt_itemSize.TabIndex = 34;
            this.txt_itemSize.Text = "ITEM SIZE";
            // 
            // itemPicture
            // 
            this.itemPicture.BackColor = System.Drawing.SystemColors.Control;
            this.itemPicture.ErrorImage = global::LABCODE1.Properties.Resources.item_unavailable_square;
            this.itemPicture.Image = global::LABCODE1.Properties.Resources.item_unavailable_square;
            this.itemPicture.Location = new System.Drawing.Point(16, 84);
            this.itemPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(381, 334);
            this.itemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itemPicture.TabIndex = 44;
            this.itemPicture.TabStop = false;
            // 
            // txt_desc
            // 
            this.txt_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc.Location = new System.Drawing.Point(16, 443);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.ReadOnly = true;
            this.txt_desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_desc.Size = new System.Drawing.Size(468, 115);
            this.txt_desc.TabIndex = 51;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.rb_Yes);
            this.flowLayoutPanel1.Controls.Add(this.rb_No);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(514, 443);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 55);
            this.flowLayoutPanel1.TabIndex = 52;
            // 
            // txt_remarks1
            // 
            this.txt_remarks1.BackColor = System.Drawing.SystemColors.Window;
            this.txt_remarks1.BorderColor = System.Drawing.Color.Green;
            this.txt_remarks1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txt_remarks1.BorderRadius = 15;
            this.txt_remarks1.BorderSize = 3;
            this.txt_remarks1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks1.ForeColor = System.Drawing.Color.Black;
            this.txt_remarks1.Location = new System.Drawing.Point(420, 198);
            this.txt_remarks1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_remarks1.Multiline = true;
            this.txt_remarks1.Name = "txt_remarks1";
            this.txt_remarks1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt_remarks1.PasswordChar = false;
            this.txt_remarks1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_remarks1.PlaceholderText = "Remarks";
            this.txt_remarks1.Size = new System.Drawing.Size(357, 220);
            this.txt_remarks1.TabIndex = 20;
            this.txt_remarks1.Texts = "";
            this.txt_remarks1.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "ID:";
            // 
            // userBtnReturn
            // 
            this.userBtnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userBtnReturn.BackColor = System.Drawing.Color.Transparent;
            this.userBtnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userBtnReturn.Enabled = false;
            this.userBtnReturn.Image = ((System.Drawing.Image)(resources.GetObject("userBtnReturn.Image")));
            this.userBtnReturn.ImageHover = ((System.Drawing.Image)(resources.GetObject("userBtnReturn.ImageHover")));
            this.userBtnReturn.ImageNormal = ((System.Drawing.Image)(resources.GetObject("userBtnReturn.ImageNormal")));
            this.userBtnReturn.Location = new System.Drawing.Point(641, 513);
            this.userBtnReturn.Name = "userBtnReturn";
            this.userBtnReturn.Size = new System.Drawing.Size(136, 45);
            this.userBtnReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userBtnReturn.TabIndex = 54;
            this.userBtnReturn.TabStop = false;
            this.userBtnReturn.Click += new System.EventHandler(this.userBtnReturn_Click);
            // 
            // returnBtnPanel
            // 
            this.returnBtnPanel.Cursor = System.Windows.Forms.Cursors.No;
            this.returnBtnPanel.Location = new System.Drawing.Point(641, 513);
            this.returnBtnPanel.Name = "returnBtnPanel";
            this.returnBtnPanel.Size = new System.Drawing.Size(136, 45);
            this.returnBtnPanel.TabIndex = 55;
            // 
            // ReturnRemarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 578);
            this.Controls.Add(this.userBtnReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.itemPicture);
            this.Controls.Add(this.txt_itemSize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_itemId);
            this.Controls.Add(this.txt_itemName);
            this.Controls.Add(this.txt_remarks1);
            this.Controls.Add(this.returnBtnPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnRemarksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnRemarksForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBtnReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label txt_itemName;
        public System.Windows.Forms.Label txt_itemId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rb_Yes;
        public System.Windows.Forms.RadioButton rb_No;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label currentDateAndTime;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label txt_studId;
        public System.Windows.Forms.Label txt_studName;
        public System.Windows.Forms.Label txt_studSec;
        public System.Windows.Forms.Label txt_itemSize;
        public System.Windows.Forms.Label borrowDate;
        public UserTextbox txt_remarks1;
        public System.Windows.Forms.PictureBox itemPicture;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label label1;
        private UserButton userBtnReturn;
        private System.Windows.Forms.Panel returnBtnPanel;
    }
}
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
            this.userTextbox1 = new LABCODE1.UserTextbox();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(663, 415);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "REMARKS";
            // 
            // userTextbox1
            // 
            this.userTextbox1.BackColor = System.Drawing.SystemColors.Window;
            this.userTextbox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.userTextbox1.BorderFocusColor = System.Drawing.Color.Empty;
            this.userTextbox1.BorderRadius = 0;
            this.userTextbox1.BorderSize = 2;
            this.userTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextbox1.ForeColor = System.Drawing.Color.Gray;
            this.userTextbox1.Location = new System.Drawing.Point(302, 169);
            this.userTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.userTextbox1.Multiline = false;
            this.userTextbox1.Name = "userTextbox1";
            this.userTextbox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.userTextbox1.PasswordChar = false;
            this.userTextbox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.userTextbox1.PlaceholderText = "";
            this.userTextbox1.Size = new System.Drawing.Size(200, 31);
            this.userTextbox1.TabIndex = 20;
            this.userTextbox1.Texts = "";
            this.userTextbox1.UnderlinedStyle = false;
            // 
            // ReturnRemarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userTextbox1);
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
        private UserTextbox userTextbox1;
    }
}
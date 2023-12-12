namespace LABCODE1
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dgvRecentActivities = new System.Windows.Forms.DataGridView();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new LABCODE1.UserButton();
            this.btnExport = new LABCODE1.UserButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecentActivities
            // 
            this.dgvRecentActivities.AllowUserToAddRows = false;
            this.dgvRecentActivities.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRecentActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivities.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentActivities.ColumnHeadersVisible = false;
            this.dgvRecentActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_date,
            this.col_message,
            this.col_time});
            this.dgvRecentActivities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRecentActivities.EnableHeadersVisualStyles = false;
            this.dgvRecentActivities.Location = new System.Drawing.Point(0, 547);
            this.dgvRecentActivities.Name = "dgvRecentActivities";
            this.dgvRecentActivities.ReadOnly = true;
            this.dgvRecentActivities.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvRecentActivities.RowHeadersVisible = false;
            this.dgvRecentActivities.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentActivities.RowTemplate.Height = 40;
            this.dgvRecentActivities.Size = new System.Drawing.Size(1244, 218);
            this.dgvRecentActivities.TabIndex = 0;
            this.dgvRecentActivities.SelectionChanged += new System.EventHandler(this.dgvActivities_SelectionChanged);
            // 
            // col_date
            // 
            this.col_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_date.FillWeight = 30F;
            this.col_date.HeaderText = "";
            this.col_date.Name = "col_date";
            this.col_date.ReadOnly = true;
            // 
            // col_message
            // 
            this.col_message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_message.FillWeight = 150F;
            this.col_message.HeaderText = "";
            this.col_message.Name = "col_message";
            this.col_message.ReadOnly = true;
            // 
            // col_time
            // 
            this.col_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_time.FillWeight = 20F;
            this.col_time.HeaderText = "";
            this.col_time.Name = "col_time";
            this.col_time.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recent Activities";
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series7.IsVisibleInLegend = false;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(487, 419);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.chart1);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(741, 482);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(496, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chart2
            // 
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX2.MajorGrid.Enabled = false;
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY2.InterlacedColor = System.Drawing.Color.White;
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(3, 3);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "topEqp";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(413, 500);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "TOP 3 MOST USED ITEM";
            title4.Text = "TOP 3 MOST USED";
            this.chart2.Titles.Add(title4);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 509);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(355, 29);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.chart2);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(694, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(538, 541);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageHover")));
            this.btnDelete.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageNormal")));
            this.btnDelete.Location = new System.Drawing.Point(337, 502);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 50);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDelete.TabIndex = 11;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageHover")));
            this.btnExport.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageNormal")));
            this.btnExport.Location = new System.Drawing.Point(198, 501);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(119, 50);
            this.btnExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExport.TabIndex = 13;
            this.btnExport.TabStop = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(422, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1244, 765);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRecentActivities);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgvRecentActivities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_message;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UserButton btnDelete;
        public UserButton btnExport;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
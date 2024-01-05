using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class TIMERTRY : Form
    {
        int seconds = 0;
        public TIMERTRY()
        {
            InitializeComponent();
        }

        private void TIMERTRY_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1 hr") 
            {
                seconds = 3600;
                timer1.Start();
            }
            if (comboBox1.Text == "2 hrs")
            {
                seconds = 3600 * 2;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                TimeSpan timeRemaining = TimeSpan.FromSeconds(seconds);
                label_timer.Text = timeRemaining.ToString("hh\\:mm\\:ss");

                // Assuming you want to update the first row's "col_timer" column
                int rowIndex = 0; // You might want to change this based on your actual requirement
                int columnIndex = dataGridView1.Columns["col_timer"].Index;
                dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = timeRemaining.ToString("hh\\:mm\\:ss");

                seconds--;
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class LogsForm : Form
    {
        //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public LogsForm()
        {
            InitializeComponent();
            LoadBorrows();
            LoadReturns();
        }

        
        private void labelBorrow_Click(object sender, EventArgs e)
        {
            
            dgvBorrowed.Visible = false;
            labelBorrow.Visible = false;
            labelReturn.Visible = true;
            dgvReturned.Visible = true;
            LoadReturns();
        }

        private void labelReturn_Click(object sender, EventArgs e)
        {
            labelReturn.Visible = false;
            dgvReturned.Visible = false;
            labelBorrow.Visible = true;
            dgvBorrowed.Visible = true;
            LoadBorrows();
        }


        private void LoadBorrows() 
        {
            con.Open();
            int i = 0;
            dgvBorrowed.Rows.Clear();
            string querySelectBorrows = "SELECT date_borrow, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, date_return FROM lab_borrows";
            cmd = new SqlCommand(querySelectBorrows, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ++i;

                dgvBorrowed.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), 
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void LoadReturns() 
        {
            con.Open();
            int i = 0;
            dgvReturned.Rows.Clear();
            string querySelectReturns = "SELECT date_borrow, actual_date_return, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, remarks FROM lab_logs";
            cmd = new SqlCommand(querySelectReturns, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ++i;

                dgvReturned.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dgvBorrowed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBorrowed.Columns[e.ColumnIndex].Name == "br_col_returnDate" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime returnDate))
                {
                    TimeSpan daysDifference = returnDate - DateTime.Now;

                    if (daysDifference.Days < 0) //overdue
                    {
                        //e.CellStyle.ForeColor = Color.Black;
                        //e.CellStyle.BackColor = Color.LightCoral; 
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else if (daysDifference.Days <= 3)
                    {
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dgvBorrowed.DefaultCellStyle.ForeColor;
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvBorrowed.DefaultCellStyle.BackColor;
                    }
                    //e.FormattingApplied = true;
                }
            }
        }






        //CLEAR HIGHLIGHTS
        private void dgvBorrowed_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvBorrowed.ClearSelection();
        }
        private void dgvReturned_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvReturned.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackUpForm backUp = new BackUpForm();
            backUp.ShowDialog();
            //try
            //{
            //    //EXPORT
            //    // Specify the connection string to your database
            //    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True";
            //    string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup", "Inventory_Labcode.bak");

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        // Create a backup command
            //        string backupCommand = $"BACKUP DATABASE [{connection.Database}] TO DISK = '{backupPath}'";
            //        using (SqlCommand command = new SqlCommand(backupCommand, connection))
            //        {
            //            command.ExecuteNonQuery();
            //            MessageBox.Show("Database exported successfully!");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error exporting database: {ex.Message}");
            //}
        }
    }
}

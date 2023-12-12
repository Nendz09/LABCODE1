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

        //for clickable pages
        private int currentPage = 1;
        private int recordsPerPage = 15; //limit per page
        private int totalRecords;

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


        

        
        //mga kulor
        private void dgvBorrowed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBorrowed.Columns[e.ColumnIndex].Name == "br_col_returnDate" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime returnDate))
                {
                    //TimeSpan daysDifference = returnDate - DateTime.Now;
                    TimeSpan timeDifference = returnDate - DateTime.Now;


                    if (timeDifference.TotalHours < 0) // overdue
                    {
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else if (timeDifference.TotalHours <= 5) // within 3 days
                    {
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dgvBorrowed.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 216, 110);//ORANGE???
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

        private void dgvReturned_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                string col_replacement = dgvReturned.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (col_replacement == "Yes")
                {
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 216, 110);
                }
                else if (col_replacement == "Replaced") 
                {
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dgvBorrowed.DefaultCellStyle.ForeColor;
                    dgvReturned.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvBorrowed.DefaultCellStyle.BackColor;
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

        //PAGES LOAD
        private void LoadReturns()
        {
            //con.Open();
            //int i = 0;
            //dgvReturned.Rows.Clear();
            //string querySelectReturns = "SELECT date_borrow, actual_date_return, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, remarks, replacement FROM lab_logs";
            //cmd = new SqlCommand(querySelectReturns, con);
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ++i;

            //    dgvReturned.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
            //        dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
            //}
            //dr.Close();
            //con.Close();

            //CLICKABLE PAGE
            cmd = new SqlCommand("SELECT COUNT(*) FROM lab_logs", con);
            con.Open();
            totalRecords = (int)cmd.ExecuteScalar();
            con.Close();

            UpdatePageInfo();

            //Load data for the current page
            LoadData();
        }
        private void LoadBorrows()
        {
            //con.Open();
            //int i = 0;
            //dgvBorrowed.Rows.Clear();
            //string querySelectBorrows = "SELECT date_borrow, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, date_return FROM lab_borrows";
            //cmd = new SqlCommand(querySelectBorrows, con);
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ++i;

            //    dgvBorrowed.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
            //        dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            //}
            //dr.Close();
            //con.Close();

            //CLICKABLE PAGE
            cmd = new SqlCommand("SELECT COUNT(*) FROM lab_borrows", con);
            con.Open();
            totalRecords = (int)cmd.ExecuteScalar();
            con.Close();

            UpdatePageInfo();

            //Load data for the current page
            LoadData();
        }

        //PAGE
        private void LoadData()
        {
            dgvBorrowed.Rows.Clear();//clear current row para di pumatong
            dgvReturned.Rows.Clear();

            int startIndex = (currentPage - 1) * recordsPerPage + 1;
            int endIndex = currentPage * recordsPerPage;

            string queryLabLogs = $@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY date_borrow DESC) AS RowNum FROM lab_logs) 
                              AS Temp WHERE RowNum BETWEEN {startIndex} AND {endIndex};";

            string queryLabBorrowed = $@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY date_borrow DESC) AS RowNum FROM lab_borrows) 
                              AS Temp WHERE RowNum BETWEEN {startIndex} AND {endIndex};";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            {
                cmd = new SqlCommand(queryLabLogs, con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvReturned.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                        dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),
                        dr[9].ToString(), dr[10].ToString());
                }
                dr.Close();
                UpdatePageInfo();
            }
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            {
                cmd = new SqlCommand(queryLabBorrowed, con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvBorrowed.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                        dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), 
                        dr[8].ToString());
                }
                dr.Close();
                UpdatePageInfo();
            }


        }



        private void UpdatePageInfo()
        {
            /*The Math.Ceiling method is used to round up the result to the nearest whole number. 
             * This ensures that even if there is a fraction of a page, it is counted as a whole page.*/
            int totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);
            labelPage.Text = $"Page {currentPage} of {totalPages}";
        }

        private void btnPrev1_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            /*The Math.Ceiling method is used to round up the result to the nearest whole number. 
             * This ensures that even if there is a fraction of a page, it is counted as a whole page.*/
            if (currentPage < (int)Math.Ceiling((double)totalRecords / recordsPerPage))
            {
                currentPage++;
                LoadData();
            }
        }

        
    }
}

using ClosedXML.Excel;
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

        DashboardForm dbForm = new DashboardForm();

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
                    else if (timeDifference.TotalHours <= 2) // within 3 days
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

        private void btnBorrowLogs_Click(object sender, EventArgs e)
        {
            labelReturn.Visible = false;
            dgvReturned.Visible = false;
            labelBorrow.Visible = true;
            dgvBorrowed.Visible = true;
            LoadBorrows();
            btnDelete.Visible = false;
            btnExport.Visible = false;
            picReturnLegend.Visible = false;
            picBorrowLegend.Visible = true;
        }

        private void btnReturnLogs_Click(object sender, EventArgs e)
        {
            dgvBorrowed.Visible = false;
            labelBorrow.Visible = false;
            labelReturn.Visible = true;
            dgvReturned.Visible = true;
            LoadReturns();
            btnDelete.Visible = true;
            btnExport.Visible = true;
            picReturnLegend.Visible = true;
            picBorrowLegend.Visible = false;
        }

        private void btnBackup_Restore_Click(object sender, EventArgs e)
        {
            BackUpForm backUp = new BackUpForm();
            backUp.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool haveReplacement = false;

            foreach (DataGridViewRow row in dgvReturned.Rows)
            {
                string replaceValue = row.Cells[9].Value.ToString();

                if (replaceValue == "Yes")
                {
                    haveReplacement = true;
                    break; // No need to continue checking once 'Yes' is found
                }
            }

            if (haveReplacement)
            {
                MessageBox.Show(@"Please make sure that there are no replacements that is needed before deleting the logs.",
                                "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show(@"Deleting the return logs will lose permanently. Do you want to export it in excel first?",
                                    "Deleting Logs/Exporting Logs",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadAllDataDGVRETURNED();
                ExportToExcel();

                //dashboard
                string msg = "You exported the the returned logs in excel file.";
                dbForm.InsertRecentActivities(msg);
            }
            else if (MessageBox.Show(@"The return logs will be deleted permanently. Proceed?",
                        "Deleting Return Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteWithReseeding();
            }
        }

        //LOAD DATA MUNA
        private void LoadAllDataDGVRETURNED()
        {
            dgvReturned.Rows.Clear();

            string query = "SELECT * FROM lab_logs ORDER BY date_borrow DESC;";
            cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvReturned.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                        dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),
                        dr[9].ToString(), dr[10].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }


        //EXPORT METHOD
        private void ExportToExcel()
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Workbook|*.xlsx";
                    saveDialog.ValidateNames = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("EquipmentData");
                            int column = 10; //this is not index

                            //add headers
                            for (int i = 0; i < column; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvReturned.Columns[i].HeaderText;
                            }

                            //add data
                            for (int i = 0; i < dgvReturned.Rows.Count; i++)//this is row, so bale lahat from 0 to hanggang saan yung nasa data
                            {
                                for (int j = 0; j < column; j++)//j sa column cell na nasa row
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvReturned.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            workbook.SaveAs(saveDialog.FileName);
                        }
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //DELETE RETURN LOGS (RESEEDING)
        private void DeleteWithReseeding() 
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            {
                con.Open();
                string deleteQuery = "DELETE FROM lab_logs;";
                string reseedQuery = "DBCC CHECKIDENT ('lab_logs', RESEED, 0);";
                string combineDeleteReseedQuery = deleteQuery + reseedQuery;

                cmd = new SqlCommand(combineDeleteReseedQuery, con);
                cmd.ExecuteNonQuery();
            }
        }

        //THIS EXPORT IS FOR RETURN LOGS ONLY
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to export the return logs into excel file?", "Export",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadAllDataDGVRETURNED();
                ExportToExcel();

                //dashboard
                string msg = "You exported the the returned logs in excel file.";
                dbForm.InsertRecentActivities(msg);
            }
        }
    }
}

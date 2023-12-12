using CircularProgressBar;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace LABCODE1
{
    public partial class DashboardForm : Form
    {
        //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;



        public DashboardForm()
        {
            InitializeComponent();
            dgvDashboardLoad();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;

        }

        public void dgvDashboardLoad() 
        {
            dgvRecentActivities.CellBorderStyle = DataGridViewCellBorderStyle.None; //remove black lines of cell
            try
            {
                int i = 0;
                string readQuery = "SELECT * from lab_recent_activities ORDER BY activityDate DESC, activityTime DESC";
                
                con.Open();
                cmd = new SqlCommand(readQuery, con);
                dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    i++;
                    dgvRecentActivities.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void dgvActivities_SelectionChanged(object sender, EventArgs e)//remove highlight
        {
            this.dgvRecentActivities.ClearSelection();
        }

        public void InsertRecentActivities(string message) 
        {
            string dateFormat = DateTime.Now.ToString("yyyy-MM-dd");
            string timeFormat = DateTime.Now.ToString("HH:mm"); //24 hr format

            try
            {
                string insertQuery = "INSERT INTO lab_recent_activities (activityDate, activityMessage, activityTime) VALUES (@activityDate, @activityMessage, @activityTime)";

                con.Open();
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@activityDate", dateFormat);
                cmd.Parameters.AddWithValue("@activityMessage", message);
                cmd.Parameters.AddWithValue("@activityTime", timeFormat);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }


        private void totalBorrowedItems() 
        {


            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            {
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                string totalBorrowedQuery = "SELECT COUNT(*) AS total_rows FROM lab_eqpment WHERE status = 'Borrowed'";
                string totalAvailableQuery = "SELECT COUNT(*) AS total_rows FROM lab_eqpment WHERE status = 'Available'";
                string totalUnavailableQuery = "SELECT COUNT(*) AS total_rows FROM lab_eqpment WHERE status = 'Unavailable'";
                con.Open();

                cmd = new SqlCommand(totalBorrowedQuery, con);
                int totalBorrowed = (int)cmd.ExecuteScalar();
                chart1.Series["Series1"].Points.AddXY("Borrowed", totalBorrowed);

                cmd = new SqlCommand(totalAvailableQuery, con);
                int totalAvailable = (int)cmd.ExecuteScalar();
                chart1.Series["Series1"].Points.AddXY("Available", totalAvailable);

                cmd = new SqlCommand(totalUnavailableQuery, con);
                int totalUnavailable = (int)cmd.ExecuteScalar();

                // Show or hide label for "Unavailable" based on count
                //chart1.Series["Series1"].Points[2].IsValueShownAsLabel = (totalUnavailable == 0);

                chart1.Series["Series1"].Points.AddXY("Unavailable", totalUnavailable);

                if (totalUnavailable == 0)
                {
                    //chart1.Series["Series1"].Points[2].IsValueShownAsLabel = false;
                    chart1.Series["Series1"].Points[2].Label = " ";
                }
                if (totalBorrowed == 0)
                {
                    chart1.Series["Series1"].Points[0].Label = " ";
                }
                if (totalAvailable == 0)
                {
                    chart1.Series["Series1"].Points[1].Label = " ";
                }


                chart1.Series["Series1"].Points[2].IsValueShownAsLabel = (totalUnavailable > 0);
            }


            chart1.Series["Series1"].Points[0].Color = Color.Orange;
            chart1.Series["Series1"].Points[1].Color = Color.LightGreen;
            chart1.Series["Series1"].Points[2].Color = Color.LightCoral;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            totalBorrowedItems();
            chart2.Legends.Clear();
            chart2TopItems();

            //chart2.Series["topEqp"].Points.AddXY("asdasd", 70);
            //chart2.Series["topEqp"].Points.AddXY("qweqwe", 100);
            //chart2.Series["topEqp"].Points.AddXY("zxczxc", 20);

            //chart2.Series["topEqp"].Points[2].Color = Color.LightCoral;
            //chart2.Series["topEqp"].Points[1].Color = Color.LightGreen;
            //chart2.Series["topEqp"].Points[0].Color = Color.LightYellow;

            //chart2.Series["topEqp"].Points.Add(1000);
            //chart2.Series["topEqp"].Points[0].Color = Color.Orange;
            //chart2.Series["topEqp"].Points[0].AxisLabel = "Equipment2";
            ////chart2.Series["topEqp"].Points[0].LegendText = "top 2";
            //chart2.Series["topEqp"].Points[0].Label = "1000";

            //chart2.Series["topEqp"].Points.Add(1500);
            //chart2.Series["topEqp"].Points[1].Color = Color.LightGreen;
            //chart2.Series["topEqp"].Points[1].AxisLabel = "Equipment1";
            ////chart2.Series["topEqp"].Points[1].LegendText = "top 1";
            //chart2.Series["topEqp"].Points[1].Label = "1500";

            //chart2.Series["topEqp"].Points.Add(500);
            //chart2.Series["topEqp"].Points[2].Color = Color.LightCoral;
            //chart2.Series["topEqp"].Points[2].AxisLabel = "Equipment3";
            ////chart2.Series["topEqp"].Points[2].LegendText = "top 3";
            //chart2.Series["topEqp"].Points[2].Label = "500";


        }

        private void chart2TopItems()
        {
            try
            {
                chart2.Series["topEqp"].Points.Clear();

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
                {
                    con.Open();

                    DateTime selectedDate = dateTimePicker1.Value;
                    DateTime startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                    DateTime endDate = startDate.AddMonths(1).AddDays(-1); //end of month

                    string query = @"SELECT TOP 3 eqp_name, COUNT(eqp_name) AS eqp_count
                            FROM lab_logs
                            WHERE actual_date_return >= @StartDate AND actual_date_return <= @EndDate
                            GROUP BY eqp_name
                            ORDER BY eqp_count DESC";


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    dr = cmd.ExecuteReader();
                    int index = 0;
                    while (dr.Read() && index < 3)
                    {
                        string eqpName = dr["eqp_name"].ToString();
                        int eqpCount = Convert.ToInt32(dr["eqp_count"]);

                        chart2.Series["topEqp"].Points.Add(eqpCount);
                        chart2.Series["topEqp"].Points[index].AxisLabel = eqpName;
                        chart2.Series["topEqp"].Points[index].Label = eqpCount.ToString();
                        chart2.Series["topEqp"].Points[index].Color = GetColorByIndex(index);

                        index++;
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Color GetColorByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Color.Orange;
                case 1:
                    return Color.LightGreen;
                case 2:
                    return Color.LightCoral;
                default:
                    return Color.Black; 
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            chart2TopItems();
        }


        //DELETE RECENT ACTIVITES (RESEEDING)
        private void DeleteWithReseeding()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            {
                con.Open();
                string deleteQuery = "DELETE FROM lab_recent_activities;";
                string reseedQuery = "DBCC CHECKIDENT ('lab_recent_activities', RESEED, 0);";
                string combineDeleteReseedQuery = deleteQuery + reseedQuery;

                cmd = new SqlCommand(combineDeleteReseedQuery, con);
                cmd.ExecuteNonQuery();
            }
        }

        

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deleting the recent activity logs will lose permanently. Do you want to export it in excel first?",
                                    "Deleting Recent Activites/Exporting Recent Activities",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvDashboardLoad();
                ExportToExcel();
            }
            else if (MessageBox.Show(@"The recent activities will be deleted permanently. Proceed?",
                        "Deleting Activities", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteWithReseeding();
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
                            int column = 3; //this is not index

                            //add headers
                            for (int i = 0; i < column; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvRecentActivities.Columns[i].HeaderText;
                            }

                            //add data
                            for (int i = 0; i < dgvRecentActivities.Rows.Count; i++)//this is row, so bale lahat from 0 to hanggang saan yung nasa data
                            {
                                for (int j = 0; j < column; j++)//j sa column cell na nasa row
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvRecentActivities.Rows[i].Cells[j].Value.ToString();
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

        
    }
}

using CircularProgressBar;
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


            chart1.Series["Series1"].Points[0].Color = Color.LightYellow;
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
                    DateTime endDate = startDate.AddMonths(1).AddDays(-1); // End of the selected month

                    string query = @"SELECT TOP 3 eqp_name, COUNT(eqp_name) AS eqp_count
                            FROM lab_logs
                            WHERE actual_date_return >= @StartDate AND actual_date_return <= @EndDate
                            GROUP BY eqp_name
                            ORDER BY eqp_count DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int index = 0;

                            while (reader.Read() && index < 3)
                            {
                                string eqpName = reader["eqp_name"].ToString();
                                int eqpCount = Convert.ToInt32(reader["eqp_count"]);

                                chart2.Series["topEqp"].Points.Add(eqpCount);
                                chart2.Series["topEqp"].Points[index].AxisLabel = eqpName;
                                chart2.Series["topEqp"].Points[index].Label = eqpCount.ToString();
                                chart2.Series["topEqp"].Points[index].Color = GetColorByIndex(index);

                                index++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (for debugging purposes, you can show a message box)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    return Color.Black; // Set a default color if needed
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            chart2TopItems();
        }


        //private void chart2TopItems()
        //{
        //    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
        //    {
        //        con.Open();

        //        // Assuming dateTimePicker1 is your datetimepicker
        //        DateTime selectedDate = dateTimePicker1.Value;

        //        string query = @"SELECT TOP 3 eqp_name, COUNT(eqp_name) AS eqp_count
        //                FROM lab_logs
        //                WHERE actual_date_return >= @StartDate AND actual_date_return < @EndDate
        //                GROUP BY eqp_name
        //                ORDER BY eqp_count DESC";

        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            // Adjust the parameters based on your date column's data type
        //            cmd.Parameters.AddWithValue("@StartDate", selectedDate);
        //            cmd.Parameters.AddWithValue("@EndDate", selectedDate.AddMonths(1)); // Assuming you want data for the whole month

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                int index = 0;

        //                while (reader.Read() && index < 3)
        //                {
        //                    string eqpName = reader["eqp_name"].ToString();
        //                    int eqpCount = Convert.ToInt32(reader["eqp_count"]);

        //                    // Add data points to the series
        //                    chart2.Series["topEqp"].Points.Add(eqpCount);
        //                    chart2.Series["topEqp"].Points[index].AxisLabel = eqpName;
        //                    chart2.Series["topEqp"].Points[index].Label = eqpCount.ToString();

        //                    // Set color based on the index
        //                    chart2.Series["topEqp"].Points[index].Color = GetColorByIndex(index);

        //                    index++;
        //                }
        //            }
        //        }
        //    }
        //}

        //private Color GetColorByIndex(int index)
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            return Color.Orange;
        //        case 1:
        //            return Color.LightGreen;
        //        case 2:
        //            return Color.LightCoral;
        //        default:
        //            return Color.Black; // Set a default color if needed
        //    }
        //}

        //private void chart2TopItems()
        //{
        //    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
        //    {
        //        string selectTopThree = @"SELECT TOP 3 eqp_name, COUNT(eqp_name) AS eqp_count
        //                FROM lab_logs
        //                WHERE actual_date_return >= '2023-12-01' AND actual_date_return < '2024-01-01'
        //                GROUP BY eqp_name
        //                ORDER BY eqp_count DESC";

        //        con.Open();
        //        cmd = new SqlCommand(selectTopThree, con);



        //        chart2.Series["topEqp"].Points.Add(1000);
        //        chart2.Series["topEqp"].Points[0].Color = Color.Orange;
        //        chart2.Series["topEqp"].Points[0].AxisLabel = "Equipment2";
        //        //chart2.Series["topEqp"].Points[0].LegendText = "top 2";
        //        chart2.Series["topEqp"].Points[0].Label = "1000";

        //        chart2.Series["topEqp"].Points.Add(1500);
        //        chart2.Series["topEqp"].Points[1].Color = Color.LightGreen;
        //        chart2.Series["topEqp"].Points[1].AxisLabel = "Equipment1";
        //        //chart2.Series["topEqp"].Points[1].LegendText = "top 1";
        //        chart2.Series["topEqp"].Points[1].Label = "1500";

        //        chart2.Series["topEqp"].Points.Add(500);
        //        chart2.Series["topEqp"].Points[2].Color = Color.LightCoral;
        //        chart2.Series["topEqp"].Points[2].AxisLabel = "Equipment3";
        //        //chart2.Series["topEqp"].Points[2].LegendText = "top 3";
        //        chart2.Series["topEqp"].Points[2].Label = "500";
        //    }


        //}



    }
}

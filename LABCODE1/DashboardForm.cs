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







        //private void InventoryModule_SaveClicked(string message)
        //{
        //    string dateFormat = DateTime.Now.ToString("MM-dd-yyyy");
        //    string timeFormat = DateTime.Now.ToString("hh:mm tt");

        //    int n = dgvRecentActivities.Rows.Add();
        //    dgvRecentActivities.Rows[n].Cells[0].Value = dateFormat;
        //    dgvRecentActivities.Rows[n].Cells[1].Value = message;
        //    dgvRecentActivities.Rows[n].Cells[2].Value = timeFormat;
        //}


        //public void AddRecentActivity(string message)
        //{
        //    string dateFormat = DateTime.Now.ToString("MM-dd-yyyy");
        //    string timeFormat = DateTime.Now.ToString("hh:mm tt");

        //    int n = dgvRecentActivities.Rows.Add();
        //    dgvRecentActivities.Rows[n].Cells[0].Value = dateFormat;
        //    dgvRecentActivities.Rows[n].Cells[1].Value = message;
        //    dgvRecentActivities.Rows[n].Cells[2].Value = timeFormat;
        //}

        //public void UpdateRecentActivities(string message)
        //{
        //    //inventoryModuleForm.Dashboard
        //    //string dateFormat = DateTime.Now.ToString("MM-dd-yyyy");
        //    //string timeFormat = DateTime.Now.ToString("hh:mm tt");

        //    //int n = dgvRecentActivities.Rows.Add();
        //    //dgvRecentActivities.Rows[n].Cells[0].Value = dateFormat;
        //    //dgvRecentActivities.Rows[n].Cells[1].Value = message;
        //    //dgvRecentActivities.Rows[n].Cells[2].Value = timeFormat;
        //}
    }
}

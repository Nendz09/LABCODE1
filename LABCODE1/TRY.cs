using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;


namespace LABCODE1
{
    public partial class TRY : Form
    {
        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;


        public TRY()
        {
            InitializeComponent();
            //con = DbConnection.GetConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string server = "srv1153.hstgr.io";
            //string uname = "u955379966_inv_labcode";
            //string dbname = "u955379966_inv_labcode";
            //string pass = "4=yyfZ*eM";

            //string connectionString = $"Server={server};Database={dbname};User Id={uname};Password={pass};";

            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Connected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Not connected. Error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


            try
            {
                CrystalReport2 report = new CrystalReport2(); // Replace with your report class name

                // Set report parameters or data source if needed
                // Example: report.SetDataSource(yourDataTable);

                //report.SetDatabaseLogon("inv_labcode_ODBC", "4=yyfZ*eM", "srv1153.hstgr.io", "u955379966_inv_labcode");



                //printReport viewerForm = new printReport();
                //viewerForm.crystalReportViewer1.ReportSource = report;
                //viewerForm.ShowDialog();

                //string connectionString = "DRIVER={MySQL ODBC 8.3 ANSI Driver}; SERVER=srv1153.hstgr.io; DATABASE=u955379966_inv_labcode; UID=u955379966_inv_labcode; PASSWORD=4=yyfZ*eM; OPTION=3";
                //report.SetDatabaseLogon("inv_labcode_ODBC", "4=yyfZ*eM", connectionString);


                printReport viewerForm = new printReport();
                viewerForm.crystalReportViewer1.ReportSource = report;
                viewerForm.ShowDialog();
            }
            catch (LogOnException logonEx)
            {
                MessageBox.Show($"Crystal Reports Logon Error: {logonEx.Message}\nDetails: {logonEx.InnerException?.Message}");
            }

        }
    }
}

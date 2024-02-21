using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace LABCODE1
{
    public partial class printReport : Form
    {
        MySqlConnection con = DbConnection.GetConnection(); // Assuming this is a method to get the connection
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        public printReport()
        {
            InitializeComponent();
        }

        public static object ReportSource { get; private set; }

        private DataTable GetDataFromDatabase()
        {
            // Replace the following with your actual database connection and query logic
            //string query = " SELECT Command_4.eqp_name, Command_4.eqp_size, Command_4.eqp_remarks\r\nFROM  u955379966_inv_labcode.lab_eqpment lab_eqpment1\r\nGROUP BY Command_4.eqp_name, Command_4.eqp_size, Command_4.eqp_remarks\r\nORDER BY Command_4.eqp_name, Command_4.eqp_size, Command_4.eqp_remarks;\r\n";
            string query = "SELECT lab_eqpment1.eqp_name, lab_eqpment1.eqp_size, lab_eqpment1.acq_remarks, " +
               "(SELECT COUNT(*) FROM u955379966_inv_labcode.lab_eqpment Command_4 " +
               "WHERE lab_eqpment1.eqp_name = Command_4.eqp_name AND " +
               "lab_eqpment1.eqp_size = Command_4.eqp_size AND " +
               "lab_eqpment1.acq_remarks = Command_4.acq_remarks) AS quantity " +
               "FROM u955379966_inv_labcode.lab_eqpment lab_eqpment1 " +
               "GROUP BY lab_eqpment1.eqp_name, lab_eqpment1.eqp_size, lab_eqpment1.acq_remarks " +
               "ORDER BY lab_eqpment1.eqp_name, lab_eqpment1.eqp_size, lab_eqpment1.acq_remarks;";



            //string query = " SELECT * FROM lab_eqpment1";

            using (MySqlConnection con = DbConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        private void RefreshReport()
        {
            try
            {
                CrystalReport1 report = new CrystalReport1(); // Replace with your report class name

                // Get data from the database
                DataTable yourDataTable = GetDataFromDatabase();

                // Set the data source for the report
                report.SetDataSource(yourDataTable);

                // Set database logon information if needed
                // This is necessary if your report uses database authentication
                // You may need to replace "YourUser", "YourPassword", "YourServer", "YourDatabase" with your actual credentials
                report.SetDatabaseLogon("u955379966_inv_labcode", "4=yyfZ*eM", "srv1153.hstgr.io", "u955379966_inv_labcode");

                // Assuming you have a Crystal Report Viewer control named crystalReportViewer1
                crystalReportViewer1.ReportSource = report;

                // Refresh the Crystal Report Viewer
                crystalReportViewer1.Refresh();
            }
            catch (LogOnException logonEx)
            {
                MessageBox.Show($"Crystal Reports Logon Error: {logonEx.Message}\nDetails: {logonEx.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nDetails: {ex.StackTrace}");
            }
        }




        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }
    }
}

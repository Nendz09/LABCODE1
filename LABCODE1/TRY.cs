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


namespace LABCODE1
{
    public partial class TRY : Form
    {


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
    }
}

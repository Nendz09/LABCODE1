using System;
using System.Collections;
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
    public partial class ReturnRemarksForm : Form
    {
        //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

       

        public ReturnRemarksForm()
        {
            InitializeComponent();
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (rb_Yes.Checked)//if need replacement
                {
                    QueryUpdateStatusUnavailable();
                    MessageBox.Show("returned");
                }
                else if (rb_No.Checked)//no need replacement
                {
                    QueryUpdateStatusAvailable();
                    MessageBox.Show("RETURNED");
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }


        //methods
        private void QueryUpdateStatusUnavailable() 
        {
            string queryUnavailable = "UPDATE lab_eqpment SET status = 'Unavailable' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new SqlCommand(queryUnavailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryUpdateStatusAvailable()
        {
            string queryAvailable = "UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new SqlCommand(queryAvailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryInsert() 
        {
            string queryInsert= "INSERT INTO lab_log (date_borrow, date_return, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, remarks) " +
                                "VALUES (@date_borrow, @date_return, @student_id, @name, @year_sec, @eqp_id, @eqp_name, @eqp_size, @remarks)";
            cmd = new SqlCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@date_return", currentDate.Text);




            
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}

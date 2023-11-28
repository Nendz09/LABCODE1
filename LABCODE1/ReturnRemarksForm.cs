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
                if (rb_Yes.Checked)//if need replacement - status = unavailable
                {
                    //int eqpId = int.Parse(txt_itemId.Text);
                    //DateTime returnDate = DateTime.Now;
                    //string remarks = txt_remarks.Text;

                    //ReturnItem(eqpId, returnDate, remarks);
                    QueryInsertLabLogs();
                    QueryDeleteToBorrowTable();
                    QueryUpdateStatusUnavailable();
                    MessageBox.Show("Returned Successfully. Replacement is needed.");
                }
                else if (rb_No.Checked)//no need replacement
                {
                    QueryInsertLabLogs();
                    QueryDeleteToBorrowTable();
                    QueryUpdateStatusAvailable();
                    MessageBox.Show("Returned Successfully. Replacement is NOT needed.");
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
            con.Open();
            string queryUnavailable = "UPDATE lab_eqpment SET status = 'Unavailable' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new SqlCommand(queryUnavailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryUpdateStatusAvailable()
        {
            con.Open();
            string queryAvailable = "UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new SqlCommand(queryAvailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryInsertLabLogs()
        {
            con.Open();
            //string textRemarksValue = UserTextbox.txt_remarks1.Text;
            string queryInsert = "INSERT INTO lab_logs (date_borrow, actual_date_return, student_id, name, year_sec, eqp_id, eqp_name, eqp_size, remarks) " +
                                "VALUES (@date_borrow, @actual_date_return, @student_id, @name, @year_sec, @eqp_id, @eqp_name, @eqp_size, @remarks)";
            cmd = new SqlCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@date_borrow", borrowDate.Text);
            cmd.Parameters.AddWithValue("@actual_date_return", currentDate.Text);
            cmd.Parameters.AddWithValue("@student_id", txt_studId.Text);
            cmd.Parameters.AddWithValue("@name", txt_studName.Text);
            cmd.Parameters.AddWithValue("@year_sec", txt_studSec.Text);
            cmd.Parameters.AddWithValue("@eqp_id", txt_itemId.Text);
            cmd.Parameters.AddWithValue("@eqp_name", txt_itemName.Text);
            cmd.Parameters.AddWithValue("@eqp_size", txt_itemSize.Text);
            cmd.Parameters.AddWithValue("@remarks", txt_remarks1.Texts);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryDeleteToBorrowTable() 
        {
            con.Open();
            int eqpId = int.Parse(txt_itemId.Text);
            string queryDeleteBorrows = "DELETE FROM lab_borrows WHERE eqp_id = @eqpId";

            cmd = new SqlCommand(queryDeleteBorrows, con);
            cmd.Parameters.AddWithValue("@eqpId", eqpId); // use borrow_id here
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

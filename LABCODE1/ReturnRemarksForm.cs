using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class ReturnRemarksForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader dr;


        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        DashboardForm dbForm = new DashboardForm();

        public ReturnRemarksForm()
        {
            InitializeComponent();

            rb_Yes.CheckedChanged += RadioButton_CheckedChanged;
            rb_No.CheckedChanged += RadioButton_CheckedChanged;

        }




        private void userBtnReturn_Click(object sender, EventArgs e)
        {
            string studentName = txt_studName.Text;
            string studentSec = txt_studSec.Text;
            string itemName = txt_itemName.Text;
            try
            {
                if (rb_Yes.Checked)//if need replacement - status = unavailable
                {
                    //int eqpId = int.Parse(txt_itemId.Text);
                    //DateTime returnDate = DateTime.Now;
                    //string remarks = txt_remarks.Text;

                    //ReturnItem(eqpId, returnDate, remarks);
                    QueryInsertLabLogs_YesReplacement();
                    QueryDeleteToBorrowTable();
                    QueryUpdateStatusUnavailable();
                    MessageBox.Show("Returned Successfully. Replacement is needed.");

                    //dashboard
                    string msg = $"{studentName} from {studentSec} returned the item '{itemName}' with a replacement.";
                    dbForm.InsertRecentActivities(msg);
                }
                else if (rb_No.Checked)//no need replacement
                {
                    QueryInsertLabLogs_NoReplacement();
                    QueryDeleteToBorrowTable();
                    QueryUpdateStatusAvailable();
                    MessageBox.Show("Returned Successfully. Replacement is NOT needed.");

                    //dashboard
                    string msg = $"{studentName} from {studentSec} returned the item '{itemName}' with no replacement.";
                    dbForm.InsertRecentActivities(msg);
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
            currentDateAndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        
        //methods
        private void QueryUpdateStatusUnavailable() 
        {
            con.Open();
            string queryUnavailable = $"UPDATE lab_eqpment SET status = 'Unavailable' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new MySqlCommand(queryUnavailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryUpdateStatusAvailable()
        {
            con.Open();
            string queryAvailable = "UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = '" + txt_itemId.Text + "' ";
            cmd = new MySqlCommand(queryAvailable, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void QueryInsertLabLogs_YesReplacement()
        {
            con.Open();
            //string textRemarksValue = UserTextbox.txt_remarks1.Text;
            string queryInsert = @"INSERT INTO 
                                lab_logs (date_borrow, actual_date_return, student_id, name, year_sec, 
                                            eqp_id, eqp_name, eqp_size, remarks, replacement) 
                                VALUES (@date_borrow, @actual_date_return, @student_id, @name, @year_sec, 
                                            @eqp_id, @eqp_name, @eqp_size, @remarks, 'Yes')";
            cmd = new MySqlCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@date_borrow", borrowDate.Text);
            cmd.Parameters.AddWithValue("@actual_date_return", currentDateAndTime.Text);
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
        private void QueryInsertLabLogs_NoReplacement()
        {
            con.Open();
            //string textRemarksValue = UserTextbox.txt_remarks1.Text;
            string queryInsert = @"INSERT INTO 
                                lab_logs (date_borrow, actual_date_return, student_id, name, year_sec, 
                                            eqp_id, eqp_name, eqp_size, remarks, replacement) 
                                VALUES (@date_borrow, @actual_date_return, @student_id, @name, @year_sec, 
                                            @eqp_id, @eqp_name, @eqp_size, @remarks, 'No')";
            cmd = new MySqlCommand(queryInsert, con);
            cmd.Parameters.AddWithValue("@date_borrow", borrowDate.Text);
            cmd.Parameters.AddWithValue("@actual_date_return", currentDateAndTime.Text);
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

            cmd = new MySqlCommand(queryDeleteBorrows, con);
            cmd.Parameters.AddWithValue("@eqpId", eqpId); // use borrow_id here
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LoadItemPicture(string itemName)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT img_eqp FROM lab_eqpdetails WHERE name_eqp = @eqpName", con);
                cmd.Parameters.AddWithValue("@eqpName", itemName);
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                if (imageData != null)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        itemPicture.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    itemPicture.Image = Properties.Resources.item_unavailable_square;
                    //itemPicture.Image = null;
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void txt_itemName_TextChanged(object sender, EventArgs e)
        {
            string itemName = txt_itemName.Text;
            LoadItemPicture(itemName);
            LoadItemDescription();
        }


        private void LoadItemDescription()
        {
            string labelItemName = txt_itemName.Text;
            string queryDescription = "SELECT desc_eqp FROM lab_eqpdetails WHERE name_eqp = @nameEquip";

            try
            {
                using (MySqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();
                    MySqlCommand cmdDesc = new MySqlCommand(queryDescription, con);
                    cmdDesc.Parameters.AddWithValue("@nameEquip", labelItemName);

                    dr = cmdDesc.ExecuteReader();

                    if (dr.Read())
                    {
                        txt_desc.Text = dr["desc_eqp"].ToString();
                    }
                    else
                    {
                        txt_desc.Text = "ITEM DESCRIPTION";
                    }
                }
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }


            //string labelItemName = txt_itemName.Text;
            //string queryDescription = "SELECT desc_eqp FROM lab_eqpDetails WHERE name_eqp = @nameEquip";

            //SqlCommand cmdDesc = new SqlCommand(queryDescription, con);
            //cmdDesc.Parameters.AddWithValue("@nameEquip", labelItemName);

            //try
            //{
            //    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
            //    {
            //        con.Open();
            //        dr = cmdDesc.ExecuteReader();
            //        if (dr.Read())
            //        {
            //            txt_desc.Text = dr["desc_eqp"].ToString();
            //        }
            //        else
            //        {
            //            txt_desc.Text = "ITEM DESCRIPTION";
            //        }
            //    }
            //}
            //finally
            //{
            //    if (dr != null && !dr.IsClosed)
            //    {
            //        dr.Close();
            //    }
            //}
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Enable the Return button if either "Yes" or "No" is checked
            //btnReturn.Enabled = rb_Yes.Checked || rb_No.Checked;
            userBtnReturn.Enabled = rb_Yes.Checked || rb_No.Checked;
            returnBtnPanel.Enabled = rb_Yes.Checked || rb_No.Checked;
        }

        
    }
}

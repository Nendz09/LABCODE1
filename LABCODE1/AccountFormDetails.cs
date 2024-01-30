using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class AccountFormDetails : Form
    {
        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        DashboardForm dbForm = new DashboardForm();
        public AccountFormDetails()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_userpass.Text) || string.IsNullOrEmpty(txt_userfullname.Text))
                {
                    MessageBox.Show("Please fill out all required fields before saving.");
                }

                else if (MessageBox.Show("Are you sure you want to update this data?", "Update Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = DbConnection.GetConnection())
                    {

                        con.Open();

                        cmd = new MySqlCommand(@"UPDATE lab_user 
                                                SET password=@password, fullname=@fullname 
                                                WHERE username=@username ", con);
                        cmd.Parameters.AddWithValue("@username", txt_username.Text);
                        cmd.Parameters.AddWithValue("@password", txt_userpass.Text);
                        cmd.Parameters.AddWithValue("@fullname", txt_userfullname.Text);



                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Account has been updated.");

                        string itemName = txt_userfullname.Text;
                        string msg = $"You updated an account: {itemName}";
                        dbForm.InsertRecentActivities(msg);

                        //updates the datagridview
                        //ItemDetails itemDetailsForm = Application.OpenForms.OfType<ItemDetails>().FirstOrDefault();
                        //itemDetailsForm?.LoadDataDGV();

                        //ItemDetails itemDetails = new ItemDetails();
                        //itemDetails?.LoadDataDGV();
                        this.Dispose();
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating: {ex.Message}");
            }
            
        }
    }
}

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_userpass.Text) || string.IsNullOrEmpty(txt_userfullname.Text))
                {
                    MessageBox.Show("Please fill out all required fields before saving.");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to save this account?", "Saving Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (MySqlConnection con = DbConnection.GetConnection())
                        {
                            cmd = new MySqlCommand(@"INSERT INTO lab_user(username, password, fullname) 
                                            VALUES (@username, @password, @fullname)", con);
                            cmd.Parameters.AddWithValue("@username", txt_username.Text);
                            cmd.Parameters.AddWithValue("@password", txt_userpass.Text);
                            cmd.Parameters.AddWithValue("@fullname", txt_userfullname.Text);
                            

                            con.Open();
                            cmd.ExecuteNonQuery();
                            
                            MessageBox.Show("Account has been saved.");

                            //dashboard
                            string name = txt_userfullname.Text;
                            string msg = $"You added a new account: {name}";
                            dbForm.InsertRecentActivities(msg);

                            this.Dispose();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                try
                {
                    cmd = new MySqlCommand("SELECT COUNT(*) FROM lab_user WHERE username = @username", con);
                    cmd.Parameters.AddWithValue("@username", txt_username.Text);

                    

                    int usernameCount = Convert.ToInt32(cmd.ExecuteScalar());
                    label_StdExists.Visible = usernameCount > 0;
                    btnSave.Enabled = usernameCount == 0;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

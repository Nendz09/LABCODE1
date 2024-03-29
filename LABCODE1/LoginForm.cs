﻿using MySql.Data.MySqlClient;
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
    public partial class LoginForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader dr;

        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;


        

        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
                pass_txt.UseSystemPasswordChar = true;
            else
                pass_txt.UseSystemPasswordChar = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                AccountForm accForm = new AccountForm();
                cmd = new MySqlCommand("SELECT * FROM lab_user WHERE username=@username AND password=@password", con);
                cmd.Parameters.AddWithValue("@username", username_txt.Text);
                cmd.Parameters.AddWithValue("@password", pass_txt.Text);
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    string fullname = dr["fullname"].ToString();
                    string username = dr["username"].ToString();
                    string pass = dr["password"].ToString();
                    UserInfo.Fullname = fullname;
                    UserInfo.Username = username;
                    UserInfo.Password = pass;
                    //accForm.labelFullname.Text = fullname;
                    //accForm.labelUsername.Text = username;
                    //accForm.labelPassword.Text = pass;
                    MessageBox.Show($"Welcome {fullname}!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm main = new MainForm(/*accForm*/);

                    main.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("INVALID USERNAME AND PASSWORD", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
            }
        }

    }
}

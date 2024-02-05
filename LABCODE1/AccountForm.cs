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
    public partial class AccountForm : Form
    {
        public string Fullname
        {
            get { return labelFullname.Text; }
        }

        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        public AccountForm()
        {
            InitializeComponent();
        }

        private void labelReturn_TextChanged(object sender, EventArgs e)
        {

        }

        //EDIT
        private void userButton1_Click(object sender, EventArgs e)
        {
            string username = labelUsername.Text;
            string password = labelPassword.Text;
            string fullname = labelFullname.Text;

            AccountFormDetails accDetails = new AccountFormDetails();
            accDetails.txt_username.Text = username;
            accDetails.txt_userfullname.Text = fullname;
            accDetails.txt_userpass.Text = password;

            accDetails.txt_username.Enabled = false;
            accDetails.btnSave.Enabled = false;

            accDetails.ShowDialog();
        }

        private void userButton2_Click(object sender, EventArgs e)
        {
            AccountFormDetails accDetails = new AccountFormDetails();

            accDetails.btnUpdate.Enabled = false;

            accDetails.ShowDialog();
        }

        public string GetFullname()
        {
            return labelFullname.Text;
        }
    }
}

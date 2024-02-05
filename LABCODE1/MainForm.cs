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
    public partial class MainForm : Form
    {
        //private AccountForm _accountForm;

        public MainForm(/*AccountForm accountForm*/)
        {
            InitializeComponent();
            //_accountForm = accountForm;
        }

        //show the subForm in this MainForm by clicking the btn
        private Form activeForm = null;
        private void openChildForm(Form childForm) { 
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      
        private void btnDashboardMainPanel_Click(object sender, EventArgs e)
        {
            openChildForm(new DashboardForm());
        }
        private void btnInventoryMainPanel_Click(object sender, EventArgs e)
        {
            openChildForm(new InventoryForm());
        }
        private void btnStudentsMainPanel_Click(object sender, EventArgs e)
        {
            openChildForm(new StudentForm());
        }
        private void btnLogsMainPanel_Click(object sender, EventArgs e)
        {
            openChildForm(new LogsForm());
        }
        private void userButtonMainPanel1_Click(object sender, EventArgs e)
        {
            openChildForm(new ItemDetails());
        }
        private void standbyMode_Click(object sender, EventArgs e)
        {
            QRManual qrManual = new QRManual();
            qrManual.ShowDialog();
        }


        //terminate app
        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnAccountMainPanel_Click(object sender, EventArgs e)
        {
            //openChildForm(_accountForm);

            AccountForm accountForm = new AccountForm();
            accountForm.labelFullname.Text = UserInfo.Fullname;
            accountForm.labelUsername.Text = UserInfo.Username;
            accountForm.labelPassword.Text = UserInfo.Password;

            openChildForm(accountForm);
        }
    }
}

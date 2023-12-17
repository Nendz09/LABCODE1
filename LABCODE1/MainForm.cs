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

       
        public MainForm()
        {
            InitializeComponent();
            
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



        //terminate app
        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        
    }
}

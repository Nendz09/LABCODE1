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
    public partial class DashboardForm : Form
    {
        InventoryModuleForm inventoryModuleForm;
        public DashboardForm()
        {
            InitializeComponent();
            dgvDashboardLoad();
        }

        public void dgvDashboardLoad() 
        {
            dgvRecentActivities.CellBorderStyle = DataGridViewCellBorderStyle.None; //remove black lines of cell
            int n = dgvRecentActivities.Rows.Add();
            dgvRecentActivities.Rows[n].Cells[0].Value = "date";
            dgvRecentActivities.Rows[n].Cells[1].Value = "you add a new item [item name]";
            dgvRecentActivities.Rows[n].Cells[2].Value = "time";
        }

        private void dgvActivities_SelectionChanged(object sender, EventArgs e)//remove highligh
        {
            this.dgvRecentActivities.ClearSelection();
        }


        public void AddRecentActivity(string message)
        {
            string dateFormat = DateTime.Now.ToString("MM-dd-yyyy");
            string timeFormat = DateTime.Now.ToString("hh:mm tt");

            int n = dgvRecentActivities.Rows.Add();
            dgvRecentActivities.Rows[n].Cells[0].Value = dateFormat;
            dgvRecentActivities.Rows[n].Cells[1].Value = message;
            dgvRecentActivities.Rows[n].Cells[2].Value = timeFormat;
        }

        //public void UpdateRecentActivities(string message)
        //{
        //    //inventoryModuleForm.Dashboard
        //    //string dateFormat = DateTime.Now.ToString("MM-dd-yyyy");
        //    //string timeFormat = DateTime.Now.ToString("hh:mm tt");

        //    //int n = dgvRecentActivities.Rows.Add();
        //    //dgvRecentActivities.Rows[n].Cells[0].Value = dateFormat;
        //    //dgvRecentActivities.Rows[n].Cells[1].Value = message;
        //    //dgvRecentActivities.Rows[n].Cells[2].Value = timeFormat;
        //}
    }
}

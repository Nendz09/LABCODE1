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
    public partial class InventoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public InventoryForm()
        {
            InitializeComponent();
            LoadUser();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //---LOAD USER---//
        public void LoadUser()
        {

            int i = 0;
            dgvLab.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM lab_eqpment", con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ++i;
                dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }


        

        private void dgvLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvLab.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                InventoryModuleForm inventoryModule = new InventoryModuleForm();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[0].ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[0].ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[0].ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[0].ToString();
            }
        }
    }
}

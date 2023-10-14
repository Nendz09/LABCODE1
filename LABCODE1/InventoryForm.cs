using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using ToolTip = System.Windows.Forms.ToolTip;

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
            LoadEquipment();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
         
        //---LOAD EQUIPMENT INVENTORY---//
        public void LoadEquipment()
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InventoryModuleForm inventoryModule = new InventoryModuleForm();
            inventoryModule.txtEqpID.Enabled = false;
            inventoryModule.btnSave.Enabled = true;
            inventoryModule.btnUpdate.Enabled = false;
            inventoryModule.labelAdd.Visible = true;
            inventoryModule.ShowDialog();
            LoadEquipment();
        }

        //------ EDIT(UPDATE) AND DELETE BUTTON-----////
        private void dgvLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvLab.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                InventoryModuleForm inventoryModule = new InventoryModuleForm();
                inventoryModule.labelUpdate.Visible = true;
                inventoryModule.txtEqpID.Text = dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();
                inventoryModule.cmbCtg.Text = dgvLab.Rows[e.RowIndex].Cells[2].Value.ToString();
                inventoryModule.cmbSize.Text = dgvLab.Rows[e.RowIndex].Cells[3].Value.ToString();

                inventoryModule.btnSave.Enabled = false;
                inventoryModule.btnUpdate.Enabled = true;
                inventoryModule.txtEqpID.Enabled = false;

                inventoryModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Equipment?", "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id LIKE'" + dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been deleted successfully!");
                }
            }
            LoadEquipment();
        }

        private void dgvLab_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ToolTip toolTip1 = new ToolTip();
            //System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection.
            //Parameter name: index'
            //string colName = dgvLab.Columns[e.ColumnIndex].Name;

            //if (colName == "Delete" || colName == "Edit")
            //{
            //    dgvLab.Cursor = Cursors.Hand;
            //}
            //else 
            //{
            //    dgvLab.Cursor = Cursors.Default;
            //}

        }
    }
}

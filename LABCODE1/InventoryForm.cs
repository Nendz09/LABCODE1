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
         
        //METHODS
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
                dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InventoryModuleForm inventoryModule = new InventoryModuleForm();
            inventoryModule.txtEqpID.Enabled = false;
            //inventoryModule.btnSave.Enabled = true;
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

                inventoryModule.txtQuantity.Visible = false;
                inventoryModule.label_Quantity.Visible = false;

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
                    //cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id LIKE'" + dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id = @EquipmentID", con);
                    cmd.Parameters.AddWithValue("@EquipmentID", dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been deleted successfully!");
                }
            }
            LoadEquipment();
        }

        //SEARCH
        private void userTextbox1__TextChanged(object sender, EventArgs e)
        {
            string searchValue = userTextbox1.Texts;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadEquipment(); // If search box is empty, reload all equipment
            }
            else
            {
                // Filter and load equipment that match the searchValue
                int i = 0;
                dgvLab.Rows.Clear();

                cmd = new SqlCommand("SELECT * FROM lab_eqpment WHERE eqp_id LIKE @searchValue OR eqp_name LIKE @searchValue OR eqp_categ LIKE @searchValue OR eqp_size LIKE @searchValue", con);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Use '%' for partial matches

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
        }

        private void dgvLab_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string status = dgvLab.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (status == "Available")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status == "Borrowed")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                
            }
        }
    }
}

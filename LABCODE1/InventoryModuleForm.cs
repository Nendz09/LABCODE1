using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //POTANGINAAA

namespace LABCODE1
{
    public partial class InventoryModuleForm : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        public InventoryModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //------SAVE BUTTON--------//
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Equipment data?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) { 
                    cmd = new SqlCommand("INSERT INTO lab_eqpment(eqp_name, eqp_categ, eqp_size) VALUES(@eqp_name, @eqp_categ, @eqp_size)", con);
                    cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                    cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                    cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been saved.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //------CLEAR BUTTON--------//
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //-------CLEAR TEXT------//
        public void Clear() {
            txtEquipment.Clear();
            cmbCtg.SelectedIndex = -1;
            cmbSize.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Equipment data?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE lab_eqpment SET eqp_name=@eqp_name, eqp_categ=@eqp_categ, eqp_size=@eqp_size WHERE eqp_id LIKE '" + txtEqpID.Text + "' ", con);
                    cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                    cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                    cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been updated.");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

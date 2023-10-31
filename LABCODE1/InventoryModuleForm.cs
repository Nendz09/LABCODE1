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
            //txtQuantity_EventHandlers();
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
                if (int.TryParse(txtQuantity.Text, out int quantity)) 
                {
                    if(quantity > 0) 
                    {
                        if (MessageBox.Show("Are you sure you want to save this Equipment data?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();
                            
                            for (int i = 0; i < quantity; i++) 
                            {
                                cmd = new SqlCommand("INSERT INTO lab_eqpment(eqp_name, eqp_categ, eqp_size) VALUES(@eqp_name, @eqp_categ, @eqp_size)", con);
                                cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                                cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                                cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);

                                cmd.ExecuteNonQuery();
                            }
                            con.Close();
                            MessageBox.Show("Equipment has been saved.");
                            Clear();
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

        //------CLEAR BUTTON--------//
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //-------CLEAR TEXT------//
        public void Clear() {
            txtEquipment.Clear();
            txtQuantity.Clear();
            cmbCtg.ResetText();
            cmbSize.ResetText();
            //cmbCtg.SelectedIndex = -1;
            //cmbSize.SelectedIndex = -1;
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

        
        

        private void cmbCtg_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCtg.SelectedItem != null && cmbCtg.SelectedItem.ToString() == "OTHER")
            {
                cmbCtg.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cmbCtg.DropDownStyle = ComboBoxStyle.DropDownList;

                if (cmbCtg.SelectedItem.ToString() == "GENERAL SCIENCE") 
                {
                    cmbSize.Enabled = true;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("10 mL");
                    cmbSize.Items.Add("25 mL");
                    cmbSize.Items.Add("50 mL");
                    cmbSize.Items.Add("100 mL");
                    cmbSize.Items.Add("250 mL");
                    cmbSize.Items.Add("500 mL");
                    cmbSize.Items.Add("1000 mL");
                    cmbSize.Items.Add("OTHER");
                }
                else if (cmbCtg.SelectedItem.ToString() == "BIOLOGY")
                {
                    cmbSize.Enabled = true;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("Chromosome Studies");
                    cmbSize.Items.Add("Elementary Life Science");
                    cmbSize.Items.Add("General Biology");
                    cmbSize.Items.Add("Assorted Slides");
                    cmbSize.Items.Add("Human Pathology");
                    cmbSize.Items.Add("Assorted Slides");
                    cmbSize.Items.Add("Mammalian Reproductive");
                    cmbSize.Items.Add("Microbiology");
                    cmbSize.Items.Add("OTHER");
                }
                else if (cmbCtg.SelectedItem.ToString() == "PHYSICS")
                {
                    cmbSize.Enabled = true;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("Simple");
                    cmbSize.Items.Add("Advanced");
                    cmbSize.Items.Add("Minute-second");
                    cmbSize.Items.Add("Double Concave(50mm diameter)");
                    cmbSize.Items.Add("Double Convex");
                    cmbSize.Items.Add("Simple Kits");
                    cmbSize.Items.Add("Toolbox Set");
                    cmbSize.Items.Add("Wood/plastic");
                    cmbSize.Items.Add("Steel");
                    cmbSize.Items.Add("Bar");
                    cmbSize.Items.Add("U-shaped");
                    cmbSize.Items.Add("Rod");
                    cmbSize.Items.Add("OTHER");
                }
                else if (cmbCtg.SelectedItem.ToString() == "CHEMISTRY")
                {
                    cmbSize.Enabled = true;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("Ceramic");
                    cmbSize.Items.Add("Glass");
                    cmbSize.Items.Add("OTHER");
                }
                else if (cmbCtg.SelectedItem.ToString() == "SUBSTANCES")
                {
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Enabled = false;
                    //cmbSize.Items.Add("Ceramic");
                    //cmbSize.Items.Add("Glass");
                    //cmbSize.Items.Add("OTHER");
                }
            }

            isFilled();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null && cmbSize.SelectedItem.ToString() == "OTHER")
            {
               
                cmbSize.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {

                cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            isFilled();
        }


        //NO STRING ALLOWED QUANTITY
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbCtg.SelectedItem != null && cmbCtg.SelectedItem.ToString() == "SUBSTANCES")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        //LIMIT 10 ONLEH
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            isFilled();
            if (int.TryParse(txtQuantity.Text, out int quantity))
            {
                if (quantity > 10)
                {
                    txtQuantity.Text = "10";
                    txtQuantity.SelectionStart = txtQuantity.Text.Length; //makes the cursor to the right part
                }
                else if (quantity == 0)
                {
                    btnSave.Enabled = false;
                }
            }

        }

        private void txtEquipment_TextChanged(object sender, EventArgs e)
        {
            isFilled();
        }

        //every textbox filled
        private void isFilled()
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txtEquipment.Text)
                                && !string.IsNullOrEmpty(cmbCtg.Text)
                                && !string.IsNullOrEmpty(cmbSize.Text)
                                && !string.IsNullOrEmpty(txtQuantity.Text);
            btnSave.Enabled = allTextIsFilled;
        }


       
    }
}

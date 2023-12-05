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
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace LABCODE1
{
    public partial class InventoryModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        SqlDataReader dr;

        DashboardForm dbForm = new DashboardForm();
        //DashboardForm dbForm;
        //DateTime currentDateTime = DateTime.Now;

        public InventoryModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //methods
        //private void AddNewCategory()
        //{
        //    // Check if the entered category is not already in the cmbCtg items
        //    if (!cmbCtg.Items.Contains(cmbCtg.Text))
        //    {
        //        cmbCtg.Items.Add(cmbCtg.Text);
        //    }
        //}

        //------EVENT MODIFIER-----//
        public event Action<string> SaveClicked; //modified event name SaveClicked

        //------SAVE BUTTON--------//
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //DateTime currentDateTime = DateTime.Now;
            //DashboardForm dbForm = new DashboardForm();
            //string dateFormat = currentDateTime.ToString("MM-dd-yyyy");
            //string timeFormat = currentDateTime.ToString("hh:mm tt");
            try
            {
                if (int.TryParse(txtQuantity.Text, out int quantity))
                {
                    if (quantity > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to save this Equipment data?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con.Open();

                            if (cbMass.Checked) 
                            {
                                //concatenate qty text + cmb gram
                                string concatenateQtyGram = txtQuantity.Text + " " + cmbGram.Text;
                                string eqpName = txtEquipment.Text;

                                cmd = new SqlCommand($@"INSERT INTO lab_eqpment(eqp_name, eqp_categ, eqp_size, status, acq_remarks) 
                                                        VALUES (@eqp_name, @eqp_categ, @eqp_size, 'Available', @acq_remarks)", con);
                                cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                                cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                                cmd.Parameters.AddWithValue("@eqp_size", concatenateQtyGram);
                                cmd.Parameters.AddWithValue("@acq_remarks", txtRemarks.Text);

                                cmd.ExecuteNonQuery();
                                //dashboard
                                string msg = $"You added {concatenateQtyGram} new item {eqpName}.";
                                dbForm.InsertRecentActivities(msg);
                            }
                            else if (!cbMass.Checked)
                            {
                                for (int i = 0; i < quantity; i++)
                                {
                                    cmd = new SqlCommand($@"INSERT INTO lab_eqpment(eqp_name, eqp_categ, eqp_size, status, acq_remarks) 
                                                            VALUES (@eqp_name, @eqp_categ, @eqp_size, 'Available', @acq_remarks)", con);
                                    cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                                    cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                                    cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);
                                    cmd.Parameters.AddWithValue("@acq_remarks", txtRemarks.Text);

                                    cmd.ExecuteNonQuery();
                                }
                                //dashboard
                                string msg = "You added " + txtQuantity.Text + " new item " + txtEquipment.Text + "!";
                                dbForm.InsertRecentActivities(msg);
                            }

                            con.Close();
                            MessageBox.Show("Equipment has been saved.");

                            //string msg = $"You added a new item {txtEquipment.Text}.";
                            // txtEquipment.Font = new Font(txtEquipment.Font, FontStyle.Bold);
                            

                            Clear();
                            this.Hide();
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
            btnSave.Enabled = false;
        }

        //-------CLEAR TEXT------//
        public void Clear()
        {
            txtEquipment.Clear();
            txtQuantity.Clear();
            txtRemarks.Clear();

            cmbCtg.Text = string.Empty;
            cmbSize.Text = string.Empty;
            cmbGram.Text = string.Empty;


            cmbCtg.ResetText();
            cmbSize.ResetText();
            cmbGram.ResetText();


            //cmbCtg.SelectedIndex = -1;
            //cmbSize.SelectedIndex = -1;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Equipment data?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    //update sa lab_eqpment
                    //cmd = new SqlCommand("UPDATE lab_eqpment SET eqp_name=@eqp_name, eqp_categ=@eqp_categ, eqp_size=@eqp_size, status=@status WHERE eqp_id=@eqp_id ", con);
                    cmd = new SqlCommand("UPDATE lab_eqpment SET eqp_name=@eqp_name, eqp_categ=@eqp_categ, eqp_size=@eqp_size WHERE eqp_id=@eqp_id ", con);
                    cmd.Parameters.AddWithValue("@eqp_id", txtEqpID.Text);
                    cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                    cmd.Parameters.AddWithValue("@eqp_categ", cmbCtg.Text);
                    cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);
                    //cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.ExecuteNonQuery();

                    //update sa lab_borrows
                    cmd = new SqlCommand("UPDATE lab_borrows SET eqp_name=@eqp_name, eqp_size=@eqp_size WHERE eqp_id=@eqp_id ", con);
                    cmd.Parameters.AddWithValue("@eqp_id", txtEqpID.Text);
                    cmd.Parameters.AddWithValue("@eqp_name", txtEquipment.Text);
                    cmd.Parameters.AddWithValue("@eqp_size", cmbSize.Text);
                    cmd.ExecuteNonQuery();


                    con.Close();
                    MessageBox.Show("Equipment has been updated.");
                    //dashboard
                    string msg = "You updated your " + txtEquipment.Text + " with ID " + txtEqpID.Text;
                    dbForm.InsertRecentActivities(msg);
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
                    cmbGram.Enabled = false;
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
                    cmbGram.Enabled = false;
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
                    cmbGram.Enabled = false;
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
                    cmbGram.Enabled = false;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("Ceramic");
                    cmbSize.Items.Add("Glass");
                    cmbSize.Items.Add("OTHER");
                }
                else if (cmbCtg.SelectedItem.ToString() == "SUBSTANCES")
                {
                    cmbSize.Enabled = true;
                    cmbGram.Enabled = false;
                    txtQuantity.Clear();
                    cmbSize.Items.Clear();
                    cmbSize.Items.Add("OTHER");


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
                txtQuantity.Clear();
                cmbSize.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                txtQuantity.Clear();
                cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            isFilled();
        }


        //NO STRING ALLOWED QUANTITY
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //LIMIT 10 ONLEH
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            isFilledSubstances();

            if (int.TryParse(txtQuantity.Text, out int quantity))
            {
                if (!cbMass.Checked)
                {
                    if (quantity > 50)
                    {
                        txtQuantity.Text = "50";
                        txtQuantity.SelectionStart = txtQuantity.Text.Length; //makes the cursor to the right part
                    }
                    else if (quantity == 0)
                    {
                        btnSave.Enabled = false;
                    }
                }
            }
        }

        private void txtEquipment_TextChanged(object sender, EventArgs e)
        {
            isFilled();
        }


        //every textbox filled
        private bool isFilled()
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txtEquipment.Text)
                                && !string.IsNullOrEmpty(cmbCtg.Text)
                                && !string.IsNullOrEmpty(cmbSize.Text)
                                && !string.IsNullOrEmpty(txtQuantity.Text)
                                && !string.IsNullOrEmpty(cmbGram.Text);

            btnSave.Enabled = allTextIsFilled;
            return allTextIsFilled;
            //debug
            //MessageBox.Show($"Equipment: {!string.IsNullOrEmpty(txtEquipment.Text)}\n" +
            //                $"Category: {!string.IsNullOrEmpty(cmbCtg.Text)}\n" +
            //                $"Size: {!string.IsNullOrEmpty(cmbSize.Text)}\n" +
            //                $"Quantity: {!string.IsNullOrEmpty(txtQuantity.Text)}\n" +
            //                $"Button Enabled: {btnSave.Enabled}");
        }

        private void isFilledSubstances()
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txtEquipment.Text)
                                && !string.IsNullOrEmpty(cmbCtg.Text)
                                && !string.IsNullOrEmpty(txtQuantity.Text);
            btnSave.Enabled = allTextIsFilled;
        }

        private void cbMass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMass.Checked)
            {
                txtQuantity.Clear();
                cmbSize.ResetText();
                cmbSize.SelectedItem = null;
                cmbSize.Enabled = false;
                cmbGram.Enabled = true;
                cmbGram.SelectedIndex = 0;
            }
            else //cbMass unchecked - normal state, not mass qty
            {
                txtQuantity.Clear();
                cmbGram.SelectedItem = null;
                cmbGram.Enabled = false;
                cmbSize.Enabled = true;
            }
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            AddCategory addCateg = new AddCategory();
            //addCateg.btnAdd.Enabled = false;
            addCateg.ShowDialog();
        }

        private void cmbCategLoad() 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
                {
                    string selectQuery = "SELECT categ_name FROM lab_categ";
                    con.Open();
                    cmbCtg.Items.Clear();//clear to prevent loop

                    cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string categName = $"{dr["categ_name"]}";
                        cmbCtg.Items.Add(categName);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void cmbCtg_DropDown(object sender, EventArgs e)
        {
            cmbCategLoad();
        }
    }
}

﻿using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class ItemDetailsModule : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader dr;

        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        ItemDetails itemDetails = new ItemDetails();
        DashboardForm dbForm = new DashboardForm();

        public ItemDetailsModule()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void LoadCateg() 
        {
            using (MySqlConnection con = DbConnection.GetConnection())
            {
                try
                {
                    string query = "SELECT categ_name FROM lab_categ";
                    
                    cmd = new MySqlCommand(query, con);
                    con.Open();

                    cmbCateg.Items.Clear();//iwas loop

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string itemName = $"{dr["categ_name"]}";
                        cmbCateg.Items.Add(itemName);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occured!");
                }
                finally { con.Close(); dr.Close(); }
            }
        }


        public void LoadItemPicture(string itemName)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT img_eqp FROM lab_eqpdetails WHERE name_eqp = @eqpName", con);
                cmd.Parameters.AddWithValue("@eqpName", itemName);
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                if (imageData != null)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        itemPicture.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    itemPicture.Image = Properties.Resources.item_unavailable;
                    //itemPicture.Image = null;
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                con.Close();
            }
        }


        private void cmbCateg_DropDown(object sender, EventArgs e)
        {
            LoadCateg();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = DbConnection.GetConnection())
            {
                try
                {
                    if (string.IsNullOrEmpty(txt_itemName.Text) || string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(cmbCateg.Text))
                    {
                        MessageBox.Show("Please fill out all required fields before saving.");
                    }

                    else if (MessageBox.Show("Are you sure you want to save this Item Details?", "Saving Item Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string query = @"INSERT INTO lab_eqpdetails(name_eqp, desc_eqp, img_eqp, categ_eqp) 
                                            VALUES(@equipmentName, @equipmentDesc, @equipmentImage, @equipmentCateg)";
                        cmd = new MySqlCommand(query, con);
                        
                        cmd.Parameters.AddWithValue("@equipmentName", txt_itemName.Text);
                        cmd.Parameters.AddWithValue("@equipmentDesc", txt_Description.Text);
                        cmd.Parameters.AddWithValue("@equipmentImage", getPhoto());
                        cmd.Parameters.AddWithValue("@equipmentCateg", cmbCateg.Text);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item details has been saved.");

                        //dashboard
                        string itemName = txt_itemName.Text;
                        string msg = $"You added a new item details: {itemName}";
                        dbForm.InsertRecentActivities(msg);

                        //Clear();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_itemName.Text) || string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(cmbCateg.Text))
                {
                    MessageBox.Show("Please fill out all required fields before saving.");
                }

                else if (MessageBox.Show("Are you sure you want to update this data?", "Update Item Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = DbConnection.GetConnection())
                    {
                        
                        con.Open();

                        cmd = new MySqlCommand(@"UPDATE lab_eqpdetails 
                                                SET desc_eqp=@desc_eqp, img_eqp=@img_eqp,  categ_eqp=@categ_eqp 
                                                WHERE name_eqp=@name_eqp ", con);
                        cmd.Parameters.AddWithValue("@name_eqp", txt_itemName.Text);
                        cmd.Parameters.AddWithValue("@desc_eqp", txt_Description.Text);
                        cmd.Parameters.AddWithValue("@img_eqp", getPhoto());
                        cmd.Parameters.AddWithValue("@categ_eqp", cmbCateg.Text);



                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item has been updated.");

                        string itemName = txt_itemName.Text;
                        string msg = $"You updated the item details: {itemName}";
                        dbForm.InsertRecentActivities(msg);

                        //updates the datagridview
                        //ItemDetails itemDetailsForm = Application.OpenForms.OfType<ItemDetails>().FirstOrDefault();
                        //itemDetailsForm?.LoadDataDGV();

                        //ItemDetails itemDetails = new ItemDetails();
                        //itemDetails?.LoadDataDGV();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating: {ex.Message}");
            }
        }



        //BYTE TRANSFER
        private byte[] getPhoto()
        {
            try
            {
                if (itemPicture.Image != null)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        Bitmap bitmap = new Bitmap(itemPicture.Image);

                        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);//convert img to jpeg format from upload button

                        //dispose
                        bitmap.Dispose();

                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while converting image to byte array: {ex.Message}");
            }

            return new byte[0];

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    itemPicture.Image = new Bitmap(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make sure to upload correct format: .jpg, .jpeg, .png" + ex.Message);
            }
        }

        private void cmbCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = DbConnection.GetConnection())
                    {
                        con.Open();

                        // Add the DELETE statement to delete the selected item
                        cmd = new MySqlCommand(@"DELETE FROM lab_eqpdetails WHERE name_eqp=@name_eqp", con);
                        cmd.Parameters.AddWithValue("@name_eqp", txt_itemName.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item has been deleted.");

                        // Optionally, you can clear the form or perform other actions after deletion
                        // ClearForm();

                        // Close the form after deletion
                        this.Dispose();
                    }
                }
                string itemName = txt_itemName.Text;
                string msg = $"You deleted the item details: {itemName}";
                dbForm.InsertRecentActivities(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_itemName.Text) || string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(cmbCateg.Text))
            {
                MessageBox.Show("Please fill out all required fields before saving.");
            }
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            AddCategory addCateg = new AddCategory();
            //addCateg.btnAdd.Enabled = false;
            addCateg.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_Description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_itemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void itemPicture_Click(object sender, EventArgs e)
        {

        }
    }
}

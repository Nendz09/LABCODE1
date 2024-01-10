using DocumentFormat.OpenXml.Spreadsheet;
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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;
                                Integrated Security=True"))
            {
                try
                {
                    string query = "SELECT categ_name FROM lab_categ";
                    
                    cmd = new SqlCommand(query, con);
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

        private void cmbCateg_DropDown(object sender, EventArgs e)
        {
            LoadCateg();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                                        AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;
                                                        Integrated Security=True"))
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to save this Item Details?", "Saving Item Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string query = @"INSERT INTO lab_eqpDetails(name_eqp, desc_eqp, img_eqp, categ_eqp) 
                                            VALUES(@equipmentName, @equipmentDesc, @equipmentImage, @equipmentCateg)";
                        cmd = new SqlCommand(query, con);
                        
                        cmd.Parameters.AddWithValue("@equipmentName", txt_itemName.Text);
                        cmd.Parameters.AddWithValue("@equipmentDesc", txt_Description.Text);
                        cmd.Parameters.AddWithValue("@equipmentImage", getPhoto());
                        cmd.Parameters.AddWithValue("@equipmentCateg", cmbCateg.Text);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item details has been saved.");

                        //dashboard
                        //string msg = "You added a new student: " + txtFullName.Text + " - " + txtYearSec.Text + ".";
                        //dbForm.InsertRecentActivities(msg);

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








        //BYTE TRANSFER
        private byte[] getPhoto()
        {
            using (MemoryStream stream = new MemoryStream())//proper disposal using
            {
                itemPicture.Image.Save(stream, itemPicture.Image.RawFormat);
                return stream.ToArray();
            }
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

        
    }
}

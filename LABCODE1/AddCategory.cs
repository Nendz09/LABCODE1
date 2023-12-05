﻿using System;
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
    public partial class AddCategory : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        SqlDataReader dr;
        DashboardForm dbForm = new DashboardForm();
        public AddCategory()
        {
            InitializeComponent();
            LoadCateg();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = $@"INSERT INTO lab_categ (categ_id, categ_name)
                                    VALUES (@categ_id, @categ_name)";

                con.Open();
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@categ_id", txtCategID.Texts);
                cmd.Parameters.AddWithValue("@categ_name", txtCategName.Texts);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Added a new Category!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);


                string category = txtCategName.Texts;
                string categoryID = txtCategID.Texts;
                //dashboard
                string msg = $"You added {category} (ID: {categoryID}) as a new Category!";
                dbForm.InsertRecentActivities(msg);

                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred. Please remove your Duplicate ID", "REMOVE DUPLICATE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                con.Close(); 
            }

            
            LoadCateg();
        }


        //methods
        private void LoadCateg() 
        {
            try
            {
                int i = 0;
                dgvCateg.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM lab_categ", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ++i;
                    dgvCateg.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void Clear() 
        {
            txtCategID.Clear();
            txtCategName.Clear();
        }



        private bool IsFilled() 
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txtCategID.Texts)
                                && !string.IsNullOrEmpty(txtCategName.Texts);
            btnAdd.Enabled = allTextIsFilled;
            return allTextIsFilled;
        }

        private void txtCategID__TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
                {
                    con.Open();
                    //check if same ID exists
                    cmd = new SqlCommand("SELECT COUNT(*) FROM lab_categ WHERE categ_id = @categ_id", con);
                    cmd.Parameters.AddWithValue("@categ_id", txtCategID.Texts);
                    int categIdCount = (int)cmd.ExecuteScalar();

                    label_idExist.Visible = categIdCount > 0;
                    btnAdd.Enabled = categIdCount == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{ con.Close(); }
        }

        private void txtCategName__TextChanged(object sender, EventArgs e)
        {
            IsFilled();
        }
    }
}

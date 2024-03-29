﻿using MySql.Data.MySqlClient;
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
    public partial class ReturnModuleForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader dr;

        MySqlConnection con = DbConnection.GetConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;


        public ReturnModuleForm()
        {
            InitializeComponent();
            dgvBorrowedItems();
        }


        //TYPING STRING UNAVAILABLE
        private void txt_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txt_Barcode.Text, out int studentID))
            {
                dgvBorrowedItems();
                con.Open();
                cmd = new MySqlCommand("SELECT * FROM lab_students WHERE student_id = @studentID", con);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    label_studentSection.Text = dr["year_sec"].ToString();
                    label_studentName.Text = dr["full_name"].ToString();

                    txt_Barcode.Enabled = false;
                    //btnProceed.Enabled = true;
                    //clearStudentID.Enabled = true;
                    //txt_BarcodeItem.Enabled = true;
                    //txt_BarcodeItem.Focus();
                }
                else
                {
                    studentPicture.Image = Properties.Resources.user_ddefault;
                    label_studentName.Text = "Invalid Student ID or NOT a number";
                    label_studentSection.Text = "";
                }
                dr.Close();
            }
            con.Close();
        }

        //methods
        private void dgvBorrowedItems() 
        {
            try
            {
                if (int.TryParse(txt_Barcode.Text, out int studentID))
                {
                    string studID = txt_Barcode.Text;
                    LoadStudentPicture(studID);
                    int i = 0;
                    dgvReturn.Rows.Clear();
                    cmd = new MySqlCommand("SELECT date_borrow, date_return, eqp_id, eqp_name, eqp_size FROM lab_borrows WHERE student_id = @studentID", con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    

                    con.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ++i;
                        dgvReturn.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                    }
                    dr.Close();
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void LoadStudentPicture(string studentID)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student_pic FROM lab_students WHERE student_id = @StudentID", con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                if (imageData != null)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        studentPicture.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    studentPicture.Image = null;
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

        //events??
        private void dgvReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvReturn.Columns[e.ColumnIndex].Name;

                if (colName == "Return")
                {
                    ReturnRemarksForm returnRemarks = new ReturnRemarksForm();
                    returnRemarks.borrowDate.Text = dgvReturn.Rows[e.RowIndex].Cells[0].Value.ToString();
                    returnRemarks.txt_itemId.Text = dgvReturn.Rows[e.RowIndex].Cells[2].Value.ToString();
                    returnRemarks.txt_itemName.Text = dgvReturn.Rows[e.RowIndex].Cells[3].Value.ToString();
                    returnRemarks.txt_itemSize.Text = dgvReturn.Rows[e.RowIndex].Cells[4].Value.ToString();
                    returnRemarks.txt_studId.Text = txt_Barcode.Text;
                    returnRemarks.txt_studName.Text = label_studentName.Text;
                    returnRemarks.txt_studSec.Text = label_studentSection.Text;
                    returnRemarks.ShowDialog();
                    dgvBorrowedItems();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void clearStudentID_Click(object sender, EventArgs e)
        {
            txt_Barcode.Text = "";
            txt_Barcode.Enabled = true;
            txt_Barcode.Focus();
            dgvReturn.Rows.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LABCODE1
{
    public partial class StudentModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public StudentModuleForm()
        {
            InitializeComponent();
        }


        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //-----CHECK IF ITS NUMERIC VALUE-----//
        private bool IsNumeric(string input)
        {
            // int.TryParse to check if the input can be converted to an integer (out _ means discarding the result)
            if (int.TryParse(input, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //---------SAVE BTN--------//
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNumeric(txtStudID.Text))
                {
                    MessageBox.Show("Student ID must be numerical only");
                }
                else if (string.IsNullOrEmpty(txtStudID.Text) || string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtYearSec.Text))
                {
                    MessageBox.Show("Please fill out all required fields before saving.");
                }
                else 
                {
                    if (MessageBox.Show("Are you sure you want to save this Student data?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("INSERT INTO lab_students(student_id, full_name, year_sec, c_number) VALUES(@student_id, @full_name, @year_sec, @c_number)", con);
                        cmd.Parameters.AddWithValue("@student_id", txtStudID.Text);
                        cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@year_sec", txtYearSec.Text);
                        cmd.Parameters.AddWithValue("@c_number", txtPNo.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Student data has been saved.");
                        Clear();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //-------CLEAR TEXT------//
        public void Clear()
        {
            txtFullName.Clear();
            txtYearSec.Clear();
            txtPNo.Clear();
            if (txtStudID.Enabled) //----TO AVOID CLEARING THE STUDENT ID---//
            {
                txtStudID.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsNumeric(txtPNo.Text))
                {
                    MessageBox.Show("Phone Number must be numerical only");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to update this Student data?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        //update sa lab_students
                        cmd = new SqlCommand("UPDATE lab_students SET student_id=@student_id, full_name=@full_name, year_sec=@year_sec, c_number=@c_number WHERE student_id LIKE '" + txtStudID.Text + "' ", con);
                        cmd.Parameters.AddWithValue("@student_id", txtStudID.Text);
                        cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@year_sec", txtYearSec.Text);
                        cmd.Parameters.AddWithValue("@c_number", txtPNo.Text);
                        cmd.ExecuteNonQuery();

                        //update sa lab_borrows
                        cmd = new SqlCommand("UPDATE lab_borrows SET name=@full_name, year_sec=@year_sec WHERE student_id = @student_id", con);
                        cmd.Parameters.AddWithValue("@student_id", txtStudID.Text);
                        cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@year_sec", txtYearSec.Text);
                        cmd.ExecuteNonQuery();

                        
                        
                        con.Close();
                        MessageBox.Show("Student data has been updated.");
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //NO SAME STUDENT ID ALLOWED.//
        private void txtStudID_TextChanged(object sender, EventArgs e)
        {
           
            con.Open();
            // Check if a student with the same ID exists
            cmd = new SqlCommand("SELECT COUNT(*) FROM lab_students WHERE student_id = @student_id", con);
            cmd.Parameters.AddWithValue("@student_id", txtStudID.Text);
            int studentIdCount = (int)cmd.ExecuteScalar();

            label_StdExists.Visible = studentIdCount > 0;
            btnSave.Enabled = studentIdCount == 0;
            con.Close();
            

        }



        // NO STRINGS ALLOWED //
        private void txtPNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtStudID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limit the length of the input to 9 characters
            if (txtStudID.Text.Length == 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            //if the user copies a string and paste it with a string
            //avoid error in line 141
            //if (Clipboard.ContainsText())
            //{
            //    string clipboardText = Clipboard.GetText();
            //    if (clipboardText.Any(c => !char.IsDigit(c))) //lambda expression
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        //PHONE FORMAT
        private void txtPNo_TextChanged(object sender, EventArgs e)
        {
            string phoneFormat = txtPNo.Text;
            if (!Regex.IsMatch(phoneFormat, "^09[0-9]*$"))
            {
                label_PhoneFormat.Visible = true;
                //btnSave.Enabled = false;
            }
            else
            {
                label_PhoneFormat.Visible = false;
                //btnSave.Enabled = true;
            }
        }



        //filled txtbox
        //private void isFilled()
        //{
        //    bool allTextIsFilled = !string.IsNullOrEmpty(txtStudID.Text)
        //                        && !string.IsNullOrEmpty(txtFullName.Text)
        //                        && !string.IsNullOrEmpty(txtYearSec.Text);
        //    btnSave.Enabled = allTextIsFilled;
        //}
    }
}

using System;
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
    public partial class StudentModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

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
                else if (!IsNumeric(txtPNo.Text)) 
                {
                    MessageBox.Show("Phone Number must be numerical only");
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
                if (!IsNumeric(txtPNo.Text))
                {
                    MessageBox.Show("Phone Number must be numerical only");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to update this Student data?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("UPDATE lab_students SET student_id=@student_id, full_name=@full_name, year_sec=@year_sec, c_number=@c_number WHERE student_id LIKE '" + txtStudID.Text + "' ", con);
                        cmd.Parameters.AddWithValue("@student_id", txtStudID.Text);
                        cmd.Parameters.AddWithValue("@full_name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@year_sec", txtYearSec.Text);
                        cmd.Parameters.AddWithValue("@c_number", txtPNo.Text);
                        con.Open();
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
    }
}

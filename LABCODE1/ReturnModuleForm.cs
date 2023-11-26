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
    public partial class ReturnModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        


        public ReturnModuleForm()
        {
            InitializeComponent();
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
                cmd = new SqlCommand("SELECT * FROM lab_students WHERE student_id = @studentID", con);
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
                dr.Close();
            }
            else
            {
                label_studentName.Text = "Invalid Student ID or NOT a number";
                label_studentSection.Text = "";
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
                    int i = 0;
                    dgvReturn.Rows.Clear();
                    cmd = new SqlCommand("SELECT date_borrow, date_return, eqp_id, eqp_name, eqp_size FROM lab_borrows WHERE student_id = @studentID", con);
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


        //events??
        private void dgvReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvReturn.Columns[e.ColumnIndex].Name;

                if (colName == "Return")
                {
                    ReturnRemarksForm returnRemarks = new ReturnRemarksForm();
                    returnRemarks.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

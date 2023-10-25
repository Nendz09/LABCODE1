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
    public partial class StudentForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        //---LOAD STUDENTS INFO---//
        public void LoadStudents()
        {

            int i = 0;
            dgvStudents.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM lab_students", con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ++i;
                dgvStudents.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        //-----ADD STUDENT (STUDENT MODULE FORM)-------//
        private void btnAdd_Click(object sender, EventArgs e)
        {

            StudentModuleForm studentModule = new StudentModuleForm();
            studentModule.btnUpdate.Enabled = false;
            studentModule.labelAdd.Visible = true;
            studentModule.ShowDialog();
            LoadStudents();
        }


        //----EDIT AND DELETE BUTTON IN COLUMN ROW----///
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStudents.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                StudentModuleForm studentModule = new StudentModuleForm();
                studentModule.labelUpdate.Visible = true;
                studentModule.txtStudID.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                studentModule.txtFullName.Text = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                studentModule.txtYearSec.Text = dgvStudents.Rows[e.RowIndex].Cells[2].Value.ToString();
                studentModule.txtPNo.Text = dgvStudents.Rows[e.RowIndex].Cells[3].Value.ToString();


                studentModule.label_StdExists.Visible = false;
                studentModule.btnSave.Enabled = false;
                studentModule.btnUpdate.Enabled = true;
                studentModule.txtStudID.Enabled = false;

                studentModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Student Info?", "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM lab_students WHERE student_id LIKE'" + dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been deleted successfully!");
                }
            }
            LoadStudents();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            StudentScanModule studentBorrowModule = new StudentScanModule();
            studentBorrowModule.ShowDialog();
        }

        private void searchTextbox__TextChanged(object sender, EventArgs e)
        {
            string searchValue = searchTextbox.Texts;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadStudents(); // If search box is empty, reload all equipment
            }
            else
            {
                // Filter and load equipment that match the searchValue
                int i = 0;
                dgvStudents.Rows.Clear();

                cmd = new SqlCommand("SELECT * FROM lab_students WHERE student_id LIKE @searchValue OR full_name LIKE @searchValue OR year_sec LIKE @searchValue OR c_number LIKE @searchValue", con);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Use '%' for partial matches

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ++i;
                    dgvStudents.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                dr.Close();
                con.Close();
            }
        }
    }
}

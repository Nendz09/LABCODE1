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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        DashboardForm dbForm = new DashboardForm();

        private StringBuilder barcodeBuffer = new StringBuilder();
        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
            // Attach the KeyPress event handler
            this.KeyPress += StudentForm_KeyPress;
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
            else if (colName == "View")
            {
                StudentViewModule studentView = new StudentViewModule();

                studentView.txt_studentid.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                studentView.txt_name.Text = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                studentView.txt_section.Text = dgvStudents.Rows[e.RowIndex].Cells[2].Value.ToString();

                studentView.LoadStudentView();

                studentView.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Student Info?", "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM lab_students WHERE student_id = @StudentID", con);
                    cmd.Parameters.AddWithValue("@StudentID", dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //cmd = new SqlCommand("DELETE FROM lab_students WHERE student_id LIKE'" + dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                    string studID = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string studName = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //dashboard
                    string msg = "You deleted student info: " + studID + " - " + studName + ".";
                    dbForm.InsertRecentActivities(msg);

                    con.Close();
                    MessageBox.Show("Student info has been deleted successfully!");
                }
            }
            else if (colName == "col_studentid") 
            {
                MessageBox.Show("HELLO");
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
                LoadStudents();
            }
            else
            {
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnModuleForm returnModule = new ReturnModuleForm();
            returnModule.ShowDialog();
        }







        private void StudentForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if the pressed key is a valid character in your barcode
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == ' ')
            {
                // Append the character to a buffer until a delimiter is encountered
                if (e.KeyChar == '\r') // Assuming Enter key is used as a delimiter
                {
                    // Process the complete barcode data
                    string barcode = GetBarcodeFromBuffer();
                    ProcessBarcode(barcode);

                    // Clear the buffer for the next barcode
                    ClearBuffer();
                }
                else
                {
                    // Append the character to the buffer
                    AppendToBuffer(e.KeyChar);
                }

                // Consume the key event to prevent it from being handled elsewhere
                e.Handled = true;
            }
        }
        // Buffer to store the scanned characters until a delimiter is encountered

        

        private void AppendToBuffer(char character)
        {
            barcodeBuffer.Append(character);
        }

        private string GetBarcodeFromBuffer()
        {
            return barcodeBuffer.ToString();
        }

        private void ClearBuffer()
        {
            barcodeBuffer.Clear();
        }
        private void ProcessBarcode(string barcode)
        {
            // Here, you can implement the logic to handle the scanned barcode
            // For example, you can display a message, search for the student, or perform any other action.
            MessageBox.Show($"Scanned Barcode: {barcode}");
        }
    }
}

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

        //for clickable pages
        private int currentPage = 1;
        private int recordsPerPage = 15; //limit per page
        private int totalRecords;

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

            //int i = 0;
            //dgvStudents.Rows.Clear();
            //cmd = new SqlCommand("SELECT * FROM lab_students", con);
            //con.Open();
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ++i;
            //    dgvStudents.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            //}
            //dr.Close();
            //con.Close();



            //export excel
            //CLICKABLE PAGE
            cmd = new SqlCommand("SELECT COUNT(*) FROM lab_students", con);
            con.Open();
            totalRecords = (int)cmd.ExecuteScalar();
            con.Close();

            UpdatePageInfo();

            //Load data for the current page
            LoadData();
        }

        //PAGES
        private void LoadData()
        {
            dgvStudents.Rows.Clear();//clear current row para di pumatong

            int startIndex = (currentPage - 1) * recordsPerPage + 1;
            int endIndex = currentPage * recordsPerPage;


            string query = $@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY student_id) AS RowNum FROM lab_students) 
                              AS Temp WHERE RowNum BETWEEN {startIndex} AND {endIndex};";
            cmd = new SqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvStudents.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }

            dr.Close();
            con.Close();

            UpdatePageInfo();
        }



        private void UpdatePageInfo()
        {
            /*The Math.Ceiling method is used to round up the result to the nearest whole number. 
             * This ensures that even if there is a fraction of a page, it is counted as a whole page.*/
            int totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);
            labelPage.Text = $"Page {currentPage} of {totalPages}";
        }


        private void btnNext1_Click(object sender, EventArgs e)
        {
            /*The Math.Ceiling method is used to round up the result to the nearest whole number. 
             * This ensures that even if there is a fraction of a page, it is counted as a whole page.*/
            if (currentPage < (int)Math.Ceiling((double)totalRecords / recordsPerPage))
            {
                currentPage++;
                LoadData();
            }
        }

        private void btnPrev1_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
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
                string studID = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();

                StudentModuleForm studentModule = new StudentModuleForm();
                studentModule.labelUpdate.Visible = true;
                studentModule.txtStudID.Text = dgvStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
                studentModule.txtFullName.Text = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                studentModule.txtYearSec.Text = dgvStudents.Rows[e.RowIndex].Cells[2].Value.ToString();
                studentModule.txtPNo.Text = dgvStudents.Rows[e.RowIndex].Cells[3].Value.ToString();

                //LOAD PICTURE
                studentModule.LoadStudentPicture(studID);


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
                    MessageBox.Show("Student info has been deleted successfully!", "Deleting Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            studentBorrowModule.txt_Barcode.Focus();
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
        



        //EXPORTTT
        private void btnExport_Click(object sender, EventArgs e)
        {
            //need ng messagebox otherwise na eexport lang yung current page
            if (MessageBox.Show("Do you want to export to excel file?", "Exporting Record",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadAllDataDGV();
                ExportToExcel();

                //dashboard
                string msg = "You exported the student data in excel file.";
                dbForm.InsertRecentActivities(msg);
            }
        }

        private void LoadAllDataDGV()
        {
            dgvStudents.Rows.Clear();

            string query = "SELECT * FROM lab_students ORDER BY student_id;";
            cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvStudents.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }


        private void ExportToExcel()
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Workbook|*.xlsx";
                    saveDialog.ValidateNames = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("EquipmentData");
                            int column = 4;

                            //add headers
                            for (int i = 0; i < column; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvStudents.Columns[i].HeaderText;
                            }

                            //add data
                            for (int i = 0; i < dgvStudents.Rows.Count; i++)// this is row, so bale lahat from 0 to hanggang saan yung nasa data
                            {
                                for (int j = 0; j < column; j++)//j sa column cell na nasa row
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvStudents.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            workbook.SaveAs(saveDialog.FileName);
                        }
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

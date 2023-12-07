using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ClosedXML;
using ClosedXML.Excel;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using ToolTip = System.Windows.Forms.ToolTip;

namespace LABCODE1
{
    public partial class InventoryForm : Form
    {
        //string constring = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        DashboardForm dbForm = new DashboardForm();

        //for clickable pages
        private int currentPage = 1;
        private int recordsPerPage = 20; //limit per page
        private int totalRecords;

        public InventoryForm()
        {
            InitializeComponent();
            LoadEquipment();
            //LoadAllDataDGV();

            //LoadPageButtons();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
         
        //METHODS
        //---LOAD EQUIPMENT INVENTORY---//
        public void LoadEquipment()
        {
            //int i = 0;
            //dgvLab.Rows.Clear();
            //cmd = new SqlCommand("SELECT * FROM lab_eqpment", con);
            //con.Open();
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ++i;
            //    dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            //}
            //dr.Close();
            //con.Close();



            //CLICKABLE PAGE
            cmd = new SqlCommand("SELECT COUNT(*) FROM lab_eqpment", con);
            con.Open();
            totalRecords = (int)cmd.ExecuteScalar();
            con.Close();

            UpdatePageInfo();

            //Load data for the current page
            LoadData();
        }
        private void LoadData()
        {
            dgvLab.Rows.Clear();//clear current row para di pumatong

            int startIndex = (currentPage - 1) * recordsPerPage + 1;
            int endIndex = currentPage * recordsPerPage;

           
            string query = $@"SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY eqp_id) AS RowNum FROM lab_eqpment) 
                              AS Temp WHERE RowNum BETWEEN {startIndex} AND {endIndex};";
            cmd = new SqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            InventoryModuleForm inventoryModule = new InventoryModuleForm();
            /*inventoryModule.SaveClicked += InventoryModule_SaveClicked;*/ //subscribe to the event
            inventoryModule.txtEqpID.Enabled = false;
            //inventoryModule.btnSave.Enabled = true;
            inventoryModule.btnUpdate.Enabled = false;
            inventoryModule.labelAdd.Visible = true;
            inventoryModule.btnUpdatePanel.Visible = true;

            inventoryModule.ShowDialog();
            LoadEquipment();
        }

        //------ EDIT(UPDATE) AND DELETE BUTTON-----////
        private void dgvLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvLab.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //dgvLab.Rows[e.RowIndex].Cells[3].Value.ToString();
                InventoryModuleForm inventoryModule = new InventoryModuleForm();
                inventoryModule.labelUpdate.Visible = true;
                inventoryModule.txtEqpID.Text = dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();

                inventoryModule.cmbCtg.DropDownStyle = ComboBoxStyle.DropDown;
                inventoryModule.cmbCtg.Text = dgvLab.Rows[e.RowIndex].Cells[2].Value.ToString();

                inventoryModule.cmbSize.DropDownStyle = ComboBoxStyle.DropDown;
                inventoryModule.cmbSize.Text = dgvLab.Rows[e.RowIndex].Cells[3].Value.ToString();

                inventoryModule.txtRemarks.Text = dgvLab.Rows[e.RowIndex].Cells[5].Value.ToString();

                //quantity for substances
                inventoryModule.txtQuantity.Visible = false;
                inventoryModule.label_Quantity.Visible = false;
                inventoryModule.cmbGram.Visible = false;
                inventoryModule.cbMass.Visible = false;

                //dun sa status for updates
                inventoryModule.cmbStatus.Visible = false;
                inventoryModule.label_Status.Visible = false;

                //edit status
                //inventoryModule.cmbStatus.Visible = true;
                //inventoryModule.label_Status.Visible = true;

                //change cursor sa save button
                inventoryModule.btnSavePanel.Visible = true;

                inventoryModule.btnSave.Enabled = false;
                inventoryModule.btnUpdate.Enabled = true;
                inventoryModule.txtEqpID.Enabled = false;

                inventoryModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Equipment? Deleting this equipment might affect the records", "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    con.Open();
                    //cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id LIKE'" + dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id = @EquipmentID", con);
                    cmd.Parameters.AddWithValue("@EquipmentID", dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString());

                    //dashboard
                    string eqpName = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string eqpID = dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string msg = $"You have successfully removed the item named {eqpName} with the ID {eqpID}";
                    dbForm.InsertRecentActivities(msg);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Equipment has been deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Replacement")
            {
                string status = dgvLab.Rows[e.RowIndex].Cells["col_status"].Value.ToString();

                if (status != "Unavailable")
                {
                    MessageBox.Show("cannot be replaced");
                }
                else if (status == "Unavailable")
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = @EquipmentID", con);
                    cmd.Parameters.AddWithValue("@EquipmentID", dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string eqpID = dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string eqpName = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();

                    //dashboard
                    string msg = "The item " + eqpName + " with ID: " + eqpID + " has been replaced.";
                    dbForm.InsertRecentActivities(msg);

                    MessageBox.Show("Status updated to Available!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadEquipment();
        }

        //SEARCH
        private void userTextbox1__TextChanged(object sender, EventArgs e)
        {
            string searchValue = userTextbox1.Texts;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                LoadEquipment(); 
            }
            else
            {
                // Filter and load equipment that match the searchValue
                int i = 0;
                dgvLab.Rows.Clear();

                cmd = new SqlCommand($@"SELECT * FROM lab_eqpment WHERE eqp_id LIKE @searchValue 
                                    OR eqp_name LIKE @searchValue 
                                    OR eqp_categ LIKE @searchValue 
                                    OR eqp_size LIKE @searchValue 
                                    OR status LIKE @searchValue
                                    OR acq_remarks LIKE @searchValue", con);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Use '%' for partial matches

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ++i;
                    dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
                dr.Close();
                con.Close();
            }
        }

        private void dgvLab_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                string status = dgvLab.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (status == "Available")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status == "Borrowed")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (status == "Unavailable")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }

            //else if (e.ColumnIndex == dgvLab.Columns["Replacement"].Index && e.RowIndex >= 0)
            //{
            //    string status = dgvLab.Rows[e.RowIndex].Cells["col_status"].Value.ToString();

            //    if (status == "Unavailable")
            //    {
            //        e.Value = Properties.Resources.replacement_20pixels;
            //        //dgvLab.Rows[e.RowIndex].Cells["Replacement"].Visible = true;
            //    }
            //    else
            //    {
            //        // Set the value to null to hide the image
            //        e.Value = null;
            //        //dgvLab.Rows[e.RowIndex].Cells["Replacement"].Visible = false;
            //    }
            //}
        }


        private void checkIfUnavailable(int rowIndex, string status) 
        {
            //if (status == "Unavailable")
            //{
                
            //}
        }

        private void LoadAllDataDGV()
        {
            dgvLab.Rows.Clear();

            string query = "SELECT * FROM lab_eqpment ORDER BY eqp_id;";
            cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvLab.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
                        dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            //need ng messagebox otherwise na eexport lang yung current page
            if (MessageBox.Show("Do you want to export to excel file?", "Exporting Record", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                LoadAllDataDGV();
                ExportToExcel();

                //dashboard
                string msg = "You exported the laboratory equipments data in excel file.";
                dbForm.InsertRecentActivities(msg);
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
                            int column = 6;

                            //add headers
                            for (int i = 0; i < column; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvLab.Columns[i].HeaderText;
                            }

                            //add data
                            for (int i = 0; i < dgvLab.Rows.Count; i++)// this is row, so bale lahat from 0 to hanggang saan yung nasa data
                            {
                                for (int j = 0; j < column; j++)//j sa column cell na nasa row
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvLab.Rows[i].Cells[j].Value.ToString();
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

﻿using System;
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
using ZXing;
using System.IO;

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
        private int recordsPerPage = 15; //limit per page
        private int totalRecords;

        public InventoryForm()
        {
            InitializeComponent();
            LoadEquipment();

            //SetupPictureBox();
            //LoadAllDataDGV();


            //LoadPageButtons();transparent not feasible putanginaaaaa
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
                string itemId = dr[0].ToString();
                //Image barcodeImage = GenerateBarcode(itemId);

                byte[] barcodeImageBytes = (byte[])dr["eqp_barcode_img"];
                Image barcodeImage = ByteArrayToImage(barcodeImageBytes);

                dgvLab.Rows.Add(/*barcodeImage,*/ barcodeImage, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }

            dr.Close();
            con.Close();

            UpdatePageInfo();
        }
        

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        //BARCODE GENERATOR PLEASE (IMAGE)
        private Image GenerateBarcode(string itemId)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128;
            return barcodeWriter.Write(itemId);
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
                inventoryModule.txtEqpID.Text = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();
                inventoryModule.txtEquipment.Text = dgvLab.Rows[e.RowIndex].Cells[2].Value.ToString();

                inventoryModule.cmbCtg.DropDownStyle = ComboBoxStyle.DropDown;
                inventoryModule.cmbCtg.Text = dgvLab.Rows[e.RowIndex].Cells[3].Value.ToString();

                inventoryModule.cmbSize.DropDownStyle = ComboBoxStyle.DropDown;
                inventoryModule.cmbSize.Text = dgvLab.Rows[e.RowIndex].Cells[4].Value.ToString();

                inventoryModule.txtRemarks.Text = dgvLab.Rows[e.RowIndex].Cells[6].Value.ToString();

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
                if (MessageBox.Show(@"Are you sure you want to delete this Equipment? 
                            Deleting this equipment might affect the records", 
                            "Deleting Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    con.Open();
                    //cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id LIKE'" + dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cmd = new SqlCommand("DELETE FROM lab_eqpment WHERE eqp_id = @EquipmentID", con);
                    cmd.Parameters.AddWithValue("@EquipmentID", dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString());

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

                if (status == "Borrowed")
                {
                    string eqpID = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string eqpName = dgvLab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string nameBorrower, yearSec;
                    WhoBorrowed(eqpID, out nameBorrower, out yearSec);

                    MessageBox.Show($"The item {eqpName} is currently using by {nameBorrower} from {yearSec}. Cannot be replaced.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //con.Open();
                    //cmd = new SqlCommand("SELECT full_name FROM lab_students WHERE eqp_id = @EquipmentID", con);
                    //cmd.Parameters.AddWithValue("@EquipmentID", dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //cmd.ExecuteNonQuery();
                    //con.Close();


                    //if (MessageBox.Show("The student '' will replace this item. Proceed?", "Item Replacement",  MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) 
                    //{

                    //}
                    //MessageBox.Show("cannot be replaced");
                }
                else if (status == "Available") 
                {
                    MessageBox.Show("The item cannot be replaced");
                }
                else if (status == "Unavailable")
                {
                    string eqpID = dgvLab.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string eqpName = dgvLab.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string nameReplacer, yearSec;
                    WhoWillReplace(eqpID, out nameReplacer, out yearSec);

                    if (MessageBox.Show($@"The item {eqpName} will be replaced by {nameReplacer} from {yearSec}. Proceed?", 
                        "Item Replacement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    {
                        returnedItemReplacement(eqpID);
                        returnItem_EquipmentStatus(eqpID);

                        //dashboard
                        string msg = $"{nameReplacer} from {yearSec} replaced the item: {eqpName}.";
                        dbForm.InsertRecentActivities(msg);
                    }

                    //con.Open();
                    //cmd = new SqlCommand("UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = @EquipmentID", con);
                    //cmd.Parameters.AddWithValue("@EquipmentID", eqpID);
                    //cmd.ExecuteNonQuery();
                    //con.Close();


                    

                }
            }
            LoadEquipment();
        }
        


        //Replacement
        private void returnedItemReplacement(string eqpID) 
        {
            string new_date;
            new_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            try
            {
                con.Open();
                string updateQuery = $@"UPDATE lab_logs SET replacement = 'Replaced', 
                                                            actual_date_return = @newDate 
                                    WHERE eqp_id = @EquipmentID";
                cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@EquipmentID", eqpID);
                cmd.Parameters.AddWithValue("@newDate", new_date);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }
        //update equipments status for replacement
        public void returnItem_EquipmentStatus(string eqpID) 
        {
            try
            {
                string updateQuery = "UPDATE lab_eqpment SET status = 'Available' WHERE eqp_id = @EquipmentID";
                con.Open();
                cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@EquipmentID", eqpID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); };
        }


        //show sino nanghiram
        private void WhoBorrowed(string eqpID, out string nameBorrower, out string yearSec)
        {
            nameBorrower = "";
            yearSec = "";
            
            try
            {
                con.Open();
                string selectQuery = @"SELECT name, year_sec FROM lab_borrows WHERE eqp_id = @eqp_id";
                cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@eqp_id", eqpID);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nameBorrower = dr["name"].ToString();
                    yearSec = dr["year_sec"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally { con.Close(); }
        }

        //show sino mag rreplace
        private void WhoWillReplace(string eqpID, out string nameBorrower, out string yearSec)
        {
            nameBorrower = "";
            yearSec = "";

            try
            {
                con.Open();
                string selectQuery = @"SELECT name, year_sec FROM lab_logs WHERE eqp_id = @eqp_id";
                cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@eqp_id", eqpID);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nameBorrower = dr["name"].ToString();
                    yearSec = dr["year_sec"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally { con.Close(); }
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
                //filter and load equipment that match the searchValue
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

                    byte[] barcodeImageBytes = (byte[])dr["eqp_barcode_img"];
                    Image barcodeImage = ByteArrayToImage(barcodeImageBytes);
                    dgvLab.Rows.Add(barcodeImage, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
                dr.Close();
                con.Close();
            }
        }

        private void dgvLab_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex == 5 && e.RowIndex >= 0 && e.RowIndex < dgvLab.Rows.Count)
            {
                // Check if the row index is within the valid range
                DataGridViewRow row = dgvLab.Rows[e.RowIndex];

                if (row.Cells.Count > e.ColumnIndex && row.Cells[e.ColumnIndex].Value != null)
                {
                    string status = row.Cells[e.ColumnIndex].Value.ToString();

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
            }


            //if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            //{
            //    string status = dgvLab.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            //    if (status == "Available")
            //    {
            //        e.CellStyle.ForeColor = Color.Green;
            //        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            //    }
            //    else if (status == "Borrowed")
            //    {
            //        e.CellStyle.ForeColor = Color.DarkOrange;
            //        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            //    }
            //    else if (status == "Unavailable")
            //    {
            //        e.CellStyle.ForeColor = Color.Red;
            //        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
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

            string query = "SELECT eqp_id, eqp_name, eqp_categ, eqp_size, status, acq_remarks, eqp_barcode_img FROM lab_eqpment ORDER BY eqp_id;";
            cmd = new SqlCommand(query, con);


            try
            {
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    byte[] barcodeImageBytes = (byte[])dr["eqp_barcode_img"];
                    Image barcodeImage = ByteArrayToImage(barcodeImageBytes);

                    dgvLab.Rows.Add(barcodeImage, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
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




        //EXPORT
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
                            int column = 7;

                            //add headers
                            for (int i = 1; i < column; i++)
                            {
                                worksheet.Cell(1, i + 0).Value = dgvLab.Columns[i].HeaderText;
                            }

                            //add data
                            for (int i = 0; i < dgvLab.Rows.Count; i++)//this is row, so bale lahat from 0 to hanggang saan yung nasa data
                            {
                                for (int j = 1; j < column; j++)//j sa column cell na nasa row
                                {
                                    worksheet.Cell(i + 2, j + 0).Value = dgvLab.Rows[i].Cells[j].Value.ToString();
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

using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using System.Data.SqlClient;
using ZXing.PDF417.Internal;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Net.WebRequestMethods;
using System.IO;
using Irony.Parsing;

namespace LABCODE1
{
    public partial class StudentScanModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        BarcodeReader reader = new BarcodeReader();

        //DateTimePicker dtp = new DateTimePicker(); //current date??
        //DateTimePicker dtp = new DateTimePicker();

        //DateTimePicker dtp;
        //DateTimePicker atp;

        DashboardForm dbForm = new DashboardForm();

        Rectangle _Rectangle;
        /*backgroundworker - is a component in .NET that simplifies working with background threads
        in a Windows Forms application*/
        private BackgroundWorker videoCaptureWorker;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        public StudentScanModule()
        {
            InitializeComponent();
            this.ActiveControl = txt_Barcode; //first focus
            videoCaptureWorker = new BackgroundWorker();
            videoCaptureWorker.DoWork += VideoCaptureWorker_DoWork;
            videoCaptureWorker.RunWorkerCompleted += VideoCaptureWorker_RunWorkerCompleted;

            

            // Initialize DateTimePicker controls
            dtpDate = new DateTimePicker();
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.MinDate = DateTime.Now;
            dtpDate.CustomFormat = "yyyy-MM-dd";


            dtpTime = new DateTimePicker();
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.MinDate = DateTime.Now;
            dtpTime.CustomFormat = "HH:mm";
            dtpTime.ShowUpDown = true;

            dtpDate.TextChanged += new EventHandler(DateTimePickerChange);
            dtpDate.CloseUp += new EventHandler(DateTimePickerClose);

            dtpTime.TextChanged += new EventHandler(DateTimePickerChange);
            dtpTime.CloseUp += new EventHandler(DateTimePickerClose);



            //datetimepicker initializer
            //dgvItemBorrow.Controls.Add(dtp);
            //dtp.Visible = false;
            //dtp.Format = DateTimePickerFormat.Custom;
            //dtp.CustomFormat = "yyyy-MM-dd";
            //dtp.MinDate = DateTime.Now;

            //dtp.ShowUpDown = true;
            //dtp.CloseUp += DateTimePickerClose;
        }



        private void VideoCaptureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Stop the video capture device
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
            }
        }

        private void VideoCaptureWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                videoCaptureDevice = null; // Ensure that the device is disposed of.
            }
        }


        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void StudentScanModule_Load(object sender, EventArgs e)
        {

            //if (dgvItemBorrow.Columns["Duration"] is DataGridViewComboBoxColumn comboBoxColumn)
            //{
            //    comboBoxColumn.Items.AddRange("1 hr", "2 hrs");
            //}


            reader.Options = new ZXing.Common.DecodingOptions
            {
                PossibleFormats = new List<BarcodeFormat>
                { 
                    BarcodeFormat.CODABAR,  // STUDENT ID FORMAT
                    BarcodeFormat.CODE_128,  // code 128
                    BarcodeFormat.QR_CODE    // qrcode
                },
            };

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (filterInfoCollection.Count == 0)
            {
                MessageBox.Show("No video capture devices found.");
                return;
            }
            else
            {
                foreach (FilterInfo device in filterInfoCollection)
                {
                    cboCam.Items.Add(device.Name);
                }
                cboCam.SelectedIndex = 0;
            }

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //lalabas ko to
            //BarcodeReader reader = new BarcodeReader(); 

            //THIS ONE IS PARA MAANO FORMAT NG BARCODE VVVV----------
            var result = reader.Decode(bitmap);


        }


        private void StudentScanModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!videoCaptureWorker.IsBusy)
            {
                videoCaptureWorker.RunWorkerAsync();
            }
            //if (videoCaptureDevice != null)
            //{
            //    if (videoCaptureDevice.IsRunning) 
            //    {
            //        videoCaptureDevice.Stop();
            //    }
            //    //BEFORE
            //    //if (videoCaptureDevice.IsRunning)
            //    //    videoCaptureDevice.Stop();
            //}
        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {
            string stringStudentID = txt_Barcode.Text;
            LoadStudentPicture(stringStudentID);
            con.Open();
            if (int.TryParse(txt_Barcode.Text, out int studentID))
            {
                cmd = new SqlCommand("SELECT * FROM lab_students WHERE student_id = @studentID", con);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    label_studentSection.Text = dr["year_sec"].ToString();
                    label_studentName.Text = dr["full_name"].ToString();
                    label_studentID.Text = dr["student_id"].ToString();

                    LoadStudentPicture(stringStudentID);

                    txt_Barcode.Enabled = false;
                    btnProceed.Enabled = true;
                    clearStudentID.Enabled = true;

                    txt_BarcodeItem.Enabled = true;
                    txt_BarcodeItem.Focus();
                }
                else
                {
                    label_studentName.Text = "No student found";
                    label_studentSection.Text = "";
                    studentPicture.Image = Properties.Resources.user_ddefault; 
                }
                dr.Close();
            }
            else
            {
                studentPicture.Image = Properties.Resources.user_ddefault;
                label_studentName.Text = "Invalid Student ID \n or NOT a number";
                label_studentSection.Text = "";
                label_studentID.Text = "";
            }
            con.Close();
        }





        //TYPING STRING UNAVAILABLE
        private void txt_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txt_BarcodeItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '\r') //check if pressed
            {
                ProcessScannedData();
            }

            //try
            //{
            //    if (int.TryParse(cmbItem.Text, out int equipmentID))
            //    {
            //        con.Open();
            //        cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @equipmentID AND status = 'Available'", con);
            //        cmd.Parameters.AddWithValue("@equipmentID", equipmentID);

            //        dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            dgvItemBorrow.Rows.Add(dateLabel.Text, dateLabelDate.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            //        }



            //        //txt_Barcode.Enabled = true;
            //        //txt_Barcode.Focus();
            //    }
            //    //else
            //    //{
            //    //    MessageBox.Show("Invalid equipment ID");
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    dr.Close();
            //    con.Close();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            dateLabelDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); ;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //cmbPickCateg.SelectedIndex = -1;
            txt_Barcode.Clear();
            txt_Barcode.Enabled = true;
            txt_Barcode.Focus();
            txt_BarcodeItem.Enabled = false;
            btnProceed.Enabled = false;
            clearStudentID.Enabled = false;
            dgvItemBorrow.Rows.Clear();
            dtpDate.Visible = false;
            dtpTime.Visible = false;
            label_studentName.Text = "STUDENT NAME";
            label_studentSection.Text = "SECTION";
        }

        private void dgvItemBorrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dgvItemBorrow.Columns[e.ColumnIndex].Name;
                if (colName == "Delete")
                {
                    dgvItemBorrow.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (dgvItemBorrow.RowCount == 0)
            {
                btnProceed.Enabled = false;
            }


        }
        //methods
        

        private void dgvItemBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          



            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                dgvItemBorrow.Controls.Add(dtpDate);
                _Rectangle = dgvItemBorrow.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtpDate.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dtpDate.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dtpDate.Visible = true;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                dgvItemBorrow.Controls.Add(dtpTime);
                _Rectangle = dgvItemBorrow.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtpTime.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dtpTime.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dtpTime.Visible = true;
            }


        }

        

        private void DateTimePickerChange(object sender, EventArgs e)
        {
            //string newDateText = dtp.Text.ToString();

            //// Check if the value has actually changed
            //if (dtp.Tag == null || !newDateText.Equals(dtp.Tag.ToString()))
            //{
            //    dgvItemBorrow.CurrentCell.Value = newDateText;

            //    // Show the message only if the value has changed
            //    MessageBox.Show(string.Format("Date changed to {0}", newDateText));

            //    // Store the current value in the Tag property to compare with future changes
            //    dtp.Tag = newDateText;
            //}

            //dtp.Visible = false;


            if (sender == dtpDate)
            {
                dgvItemBorrow.CurrentCell.Value = dtpDate.Text;
            }
            else if (sender == dtpTime)
            {
                dgvItemBorrow.CurrentCell.Value = dtpTime.Text;
            }


            //WORKING
            //dgvItemBorrow.CurrentCell.Value = dtp.Text.ToString();
            //dgvItemBorrow.CurrentCell.Value = atp.Text.ToString();


            //MessageBox.Show(string.Format("Date changed to {0}", dtp.Text.ToString()));
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            //if (sender is DateTimePicker)
            //{
            //    DateTimePicker dateTimePicker = (DateTimePicker)sender;
            //    dateTimePicker.Value = DateTime.Now; //set the Value to the current date
            //    dateTimePicker.Visible = false;
            //}



            //if (sender is DateTimePicker)
            //{
            //    DateTimePicker dateTimePicker = (DateTimePicker)sender;

            //    // Get the current date from the DateTimePicker
            //    DateTime selectedDate = dateTimePicker.Value;


            //    dateTimePicker.Visible = false;
            //}
            if (sender == dtpDate)
            {
                dtpDate.Visible = false;
            }
            else if (sender == dtpTime)
            {
                dtpTime.Visible = false;
            }
        }


        private void dgvItemBorrow_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                // Hide the DateTimePicker control when leaving the cell
                dtpDate.Visible = false;
            }
            else if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                // Hide the DateTimePicker control when leaving the cell
                dtpTime.Visible = false;
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                //check empty cells
                foreach (DataGridViewRow row in dgvItemBorrow.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(row.Cells["col_dor"].Value)) || 
                        string.IsNullOrEmpty(Convert.ToString(row.Cells["col_duetime"].Value)))
                    {
                        MessageBox.Show("Please set a value for the 'Date of Return' or 'Due Time' before proceeding.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                con.Open();

                if (HasDuplicateItemIds())
                {
                    MessageBox.Show("Please remove the DUPLICATE item ID before proceeding. Thank you.", "Duplicate Item ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; //exit the method if duplicates are found
                }

                List<int> itemIds = dgv_GetSelectedItemIds(); //list item (int type)
                List<string> itemNames = dgv_ItemNames(); //list item names
                dgv_UpdateLabEqpmentStatus(itemIds);
                dgv_InsertIntoLabBorrows();

                //DASHBOARD
                string studentName = label_studentName.Text;
                string studentSec = label_studentSection.Text;
                string itemNamesList = string.Join(", ", itemNames);
                string msg = $"{studentName} from {studentSec} borrowed the items: {itemNamesList}.";
                dbForm.InsertRecentActivities(msg);

                //con.Close();
                MessageBox.Show("Borrowed Successfully!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                con.Close(); 
            }
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close(); // Ensure that the connection is closed even if an exception occurs
            //}
        }

        private List<string> dgv_ItemNames() //list ng mga item names
        {
            List<string> itemNames = new List<string>();

            for (int i = 0; i < dgvItemBorrow.Rows.Count; i++)
            {
                if (dgvItemBorrow.Rows[i].Cells["col_itemname"].Value != null)
                {
                    string itemName = dgvItemBorrow.Rows[i].Cells["col_itemname"].Value.ToString();
                    itemNames.Add(itemName);
                }
            }
            return itemNames;
        }

        private List<int> dgv_GetSelectedItemIds()
        {
            List<int> itemIds = new List<int>(); //list item int type


            for (int i = 0; i < dgvItemBorrow.Rows.Count; i++)
            {
                //col_itemid = dun sa dgv 
                int itemId;
                if (int.TryParse(dgvItemBorrow.Rows[i].Cells["col_itemid"].Value.ToString(), out itemId)) 
                {
                    itemIds.Add(itemId);
                }
            }

            return itemIds;
        }

        private void dgv_UpdateLabEqpmentStatus(List<int> itemIds)
        {
            //string.Join(separator, values)//
            string query = "UPDATE lab_eqpment SET status = 'Borrowed' WHERE eqp_id IN (" + string.Join(",", itemIds) + ")"; //concatenation - string.Join(",", itemIds)


            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private void dgv_InsertIntoLabBorrows()
        {
            for (int i = 0; i < dgvItemBorrow.RowCount; i++)
            {
                string concatenateReturnDateAndTime = (string.Concat(dgvItemBorrow.Rows[i].Cells["col_dor"].Value.ToString() + " " + dgvItemBorrow.Rows[i].Cells["col_duetime"].Value.ToString()));
                cmd = new SqlCommand(@"INSERT INTO lab_borrows(date_borrow, student_id, name, year_sec, eqp_id, eqp_name, date_return, eqp_size) 
                                    VALUES(@date_borrow, @student_id, @name, @year_sec, @eqp_id, @eqp_name, @date_return, @eqp_size)", con);
                cmd.Parameters.AddWithValue("@date_borrow", dgvItemBorrow.Rows[i].Cells["col_dob"].Value.ToString());
                cmd.Parameters.AddWithValue("@student_id", txt_Barcode.Text);
                cmd.Parameters.AddWithValue("@name", label_studentName.Text);
                cmd.Parameters.AddWithValue("@year_sec", label_studentSection.Text);
                cmd.Parameters.AddWithValue("@eqp_id", dgvItemBorrow.Rows[i].Cells["col_itemid"].Value.ToString());
                cmd.Parameters.AddWithValue("@eqp_name", dgvItemBorrow.Rows[i].Cells["col_itemname"].Value.ToString());
                cmd.Parameters.AddWithValue("@date_return", concatenateReturnDateAndTime);
                cmd.Parameters.AddWithValue("@eqp_size", dgvItemBorrow.Rows[i].Cells["col_size"].Value.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        //method

        //CMB ITEM - THIS IS YUNG MAY DROPDOWLIST
        //private void cmbItemLoad() 
        //{
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE status = 'Available' AND eqp_categ = '" + cmbPickCateg.Text + "' ", con);
        //        cmbItem.Items.Clear();

        //        SqlDataReader datareader = cmd.ExecuteReader();

        //        while (datareader.Read())
        //        {
        //            //cmbItem.Items.Add(datareader["eqp_name"].ToString());
        //            string itemName = $"{datareader["eqp_id"]} - {datareader["eqp_name"]} - {datareader["eqp_size"]}"; //concatenate

        //            cmbItem.Items.Add(itemName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading items: " + ex.Message);
        //    }
        //    finally { con.Close(); }

           
        //}
        //private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = true;
        //}
        //private void cmbItem_DropDown(object sender, EventArgs e)
        //{
        //    cmbItemLoad();
        //}

        

        

        //private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)//NO NEED BTN- REKTA INPUT SA DGV AFTER SELECTING INDEX
        //{
        //    //extract the equipment ID from the selected cmbItem text
        //    if (int.TryParse(cmbItem.Text.Split('-')[0].Trim(), out int equipmentID))
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @equipmentID AND status = 'Available'", con);
        //        cmd.Parameters.AddWithValue("@equipmentID", equipmentID);

        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            dgvItemBorrow.Rows.Add(dateLabel.Text, dateLabelDate.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
        //        }

        //        dr.Close();
        //        con.Close();

        //        //txt_Barcode.Enabled = true;
        //        //txt_Barcode.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid equipment ID");
        //    }
        //}
        //private void cmbPickCateg_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbPickCateg.SelectedItem != null)
        //    {
        //        cmbItem.Enabled = true;
        //        cmbItem.Text = "";
        //        txt_Barcode.Text = "";
        //        //cmbPickCateg.DropDownStyle = ComboBoxStyle.DropDownList;
        //    }
        //}

        

        private bool HasDuplicateItemIds()//this is a BOOLEAN
        {
            HashSet<int> HashItemId = new HashSet<int>(); //collection of unique elements, meaning it cannot contain duplicate items.

            for (int i = 0; i < dgvItemBorrow.Rows.Count; i++)
            {
                int itemId;
                if (int.TryParse(dgvItemBorrow.Rows[i].Cells["col_itemid"].Value.ToString(), out itemId))
                {
                    if (!HashItemId.Add(itemId))
                    {
                        //duplicate item ID found
                        return true;
                    }
                }
            }

            //no duplicate item IDs found
            return false;
        }


        private void clearStudentID_Click_1(object sender, EventArgs e)
        {
            txt_Barcode.Text = "";
            txt_Barcode.Enabled = true;
            txt_Barcode.Focus();
            txt_BarcodeItem.Enabled = false;
            btnProceed.Enabled = false;
        }



        //categ combo box
        //private void cmbCategLoad()
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
        //        {
        //            string selectQuery = "SELECT categ_name FROM lab_categ";
        //            con.Open();
        //            cmbPickCateg.Items.Clear();//clear to prevent loop

        //            cmd = new SqlCommand(selectQuery, con);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                string categName = $"{dr["categ_name"]}";
        //                cmbPickCateg.Items.Add(categName);
        //            }
        //            dr.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading items: " + ex.Message);
        //    }
        //}
        

        public void LoadStudentPicture(string studentID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT student_pic FROM lab_students WHERE student_id = @StudentID", con);
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

        private void txt_BarcodeItem_TextChanged(object sender, EventArgs e)
        {
            //if (txt_BarcodeItem.Text.EndsWith("\r\n")) // Check for the appropriate delimiter
            //{
            //    string scannedData = txt_BarcodeItem.Text.Trim();

            //    // Process the scanned data (e.g., query the database)
            //    ProcessScannedData(scannedData);

            //    // Clear the textbox for the next scan
            //    txt_BarcodeItem.Clear();
            //}


            //try
            //{
            //    if (int.TryParse(txt_BarcodeItem.Text, out int equipmentID))
            //    {
            //        con.Open();
            //        cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @equipmentID AND status = 'Available'", con);
            //        cmd.Parameters.AddWithValue("@equipmentID", equipmentID);

            //        dr = cmd.ExecuteReader();

            //        while (dr.Read())
            //        {
            //            dgvItemBorrow.Rows.Add(dateLabel.Text, dateLabelDate.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            //        }

            //        //txt_Barcode.Enabled = true;
            //        //txt_Barcode.Focus();
            //    }
            //    //else
            //    //{
            //    //    MessageBox.Show("Invalid equipment ID");
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    dr.Close();
            //    con.Close();
            //}
        }
        private void ProcessScannedData()
        {
            string scannedData = txt_BarcodeItem.Text.Trim();


            if (!string.IsNullOrEmpty(scannedData))
            {
                if (int.TryParse(scannedData, out int equipmentID))
                {
                    //if itemid exist in dgv
                    bool itemIdExist = dgvItemBorrow.Rows
                        .Cast<DataGridViewRow>()
                        .Any(row => row.Cells[3].Value != null && row.Cells[3].Value.ToString() == equipmentID.ToString());

                    if (!itemIdExist) 
                    {
                        try
                        {
                            con.Open();
                            cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @equipmentID AND status = 'Available'", con);
                            cmd.Parameters.AddWithValue("@equipmentID", equipmentID);

                            dr = cmd.ExecuteReader();

                            //dgvItemBorrow.Rows.Clear();

                            

                            while (dr.Read())
                            {

                                //DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                                //comboBoxCell.Items.AddRange(new string[] { "1 hr", "2 hrs" });

                                ////default
                                //comboBoxCell.Value = "1 hr";

                                dgvItemBorrow.Rows.Add(dateLabel.Text, dateLabelDate.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString()/*, comboBoxCell*/);
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            dr.Close();
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID does not exist", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //clear txt
                txt_BarcodeItem.Clear();
            }

            
        }


    }
}

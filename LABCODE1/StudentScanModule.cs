﻿using AForge.Video.DirectShow;
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
        DateTimePicker dtp = new DateTimePicker();


        DashboardForm dbForm = new DashboardForm();

        Rectangle _Rectangle;
        /*backgroundworker - is a component in .NET that simplifies working with background threads
        in a Windows Forms application*/
        private BackgroundWorker videoCaptureWorker;

        public StudentScanModule()
        {
            InitializeComponent();
            this.ActiveControl = cmbItem; //first focus
            videoCaptureWorker = new BackgroundWorker();
            videoCaptureWorker.DoWork += VideoCaptureWorker_DoWork;
            videoCaptureWorker.RunWorkerCompleted += VideoCaptureWorker_RunWorkerCompleted;

            //datetimepicker initializer
            dgvItemBorrow.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd";
            //dtp.ShowUpDown = true;
            dtp.MinDate = DateTime.Now;

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

                    txt_Barcode.Enabled = false;
                    btnProceed.Enabled = true;
                    clearStudentID.Enabled = true;
                    //txt_BarcodeItem.Enabled = true;
                    //txt_BarcodeItem.Focus();
                }
                dr.Close();
            }
            else
            {
                label_studentName.Text = "Invalid Student ID \n or NOT a number";
                label_studentSection.Text = "";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            cmbPickCateg.SelectedIndex = -1;
            txt_Barcode.Clear();
            cmbItem.Items.Clear();
            cmbItem.Enabled = false;
            txt_Barcode.Enabled = false;
            btnProceed.Enabled = false;
            clearStudentID.Enabled = false;
            dgvItemBorrow.Rows.Clear();
            dtp.Visible = false;
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
                dgvItemBorrow.Controls.Add(dtp);
                //set the location of the DateTimePicker to the clicked cell
                _Rectangle = dgvItemBorrow.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dtp.Visible = true;
                dtp.TextChanged += new EventHandler(DateTimePickerChange);
                dtp.CloseUp += new EventHandler(DateTimePickerClose);
            }
            else
            {
                dtp.Visible = false;
            }
        }
        //event handler for DateTimePicker's ValueChanged event.
        //private void dtp_ValueChanged(object sender, EventArgs e)
        //{
        //    //set the selected date in the DataGridView cell.
        //    dgvItemBorrow.CurrentCell.Value = dtp.Value.ToString("yyyy-MM-dd");
        //    dtp.Visible = false; // Hide the DateTimePicker control.
        //}

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



            //WORKING
            dgvItemBorrow.CurrentCell.Value = dtp.Text.ToString();


            //MessageBox.Show(string.Format("Date changed to {0}", dtp.Text.ToString()));
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            if (sender is DateTimePicker)
            {
                DateTimePicker dateTimePicker = (DateTimePicker)sender;
                dateTimePicker.Value = DateTime.Now; // Set the Value to the current date
                dateTimePicker.Visible = false;
            }

            //if (sender is DateTimePicker)
            //{
            //    DateTimePicker dateTimePicker = (DateTimePicker)sender;

            //    // Get the current date from the DateTimePicker
            //    DateTime selectedDate = dateTimePicker.Value;

            //    // Set the time to a specific value (e.g., 12:00 PM)
            //    DateTime selectedDateTimeWithTime = selectedDate.Date.Add(new TimeSpan(12, 0, 0)); // Adjust the time as needed

            //    // Update the Value property of the DateTimePicker
            //    dateTimePicker.Value = selectedDateTimeWithTime;

            //    dateTimePicker.Visible = false;
            //}
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                //check empty cells
                foreach (DataGridViewRow row in dgvItemBorrow.Rows)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(row.Cells["col_dor"].Value)))
                    {
                        MessageBox.Show("Please set a value for the 'Date of Return' before proceeding.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmd = new SqlCommand(@"INSERT INTO lab_borrows(date_borrow, student_id, name, year_sec, eqp_id, eqp_name, date_return, eqp_size) 
                                    VALUES(@date_borrow, @student_id, @name, @year_sec, @eqp_id, @eqp_name, @date_return, @eqp_size)", con);
                cmd.Parameters.AddWithValue("@date_borrow", dgvItemBorrow.Rows[i].Cells["col_dob"].Value.ToString());
                cmd.Parameters.AddWithValue("@student_id", txt_Barcode.Text);
                cmd.Parameters.AddWithValue("@name", label_studentName.Text);
                cmd.Parameters.AddWithValue("@year_sec", label_studentSection.Text);
                cmd.Parameters.AddWithValue("@eqp_id", dgvItemBorrow.Rows[i].Cells["col_itemid"].Value.ToString());
                cmd.Parameters.AddWithValue("@eqp_name", dgvItemBorrow.Rows[i].Cells["col_itemname"].Value.ToString());
                cmd.Parameters.AddWithValue("@date_return", dgvItemBorrow.Rows[i].Cells["col_dor"].Value.ToString());
                cmd.Parameters.AddWithValue("@eqp_size", dgvItemBorrow.Rows[i].Cells["col_size"].Value.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        //method

        //CMB ITEM 
        private void cmbItemLoad() 
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE status = 'Available' AND eqp_categ = '" + cmbPickCateg.Text + "' ", con);
                cmbItem.Items.Clear();

                SqlDataReader datareader = cmd.ExecuteReader();

                while (datareader.Read())
                {
                    //cmbItem.Items.Add(datareader["eqp_name"].ToString());
                    string itemName = $"{datareader["eqp_id"]} - {datareader["eqp_name"]} - {datareader["eqp_size"]}"; //concatenate

                    cmbItem.Items.Add(itemName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
            finally { con.Close(); }

           
        }
        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmbItem_DropDown(object sender, EventArgs e)
        {
            cmbItemLoad();
        }

        

        

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)//NO NEED BTN- REKTA INPUT SA DGV AFTER SELECTING INDEX
        {
            //extract the equipment ID from the selected cmbItem text
            if (int.TryParse(cmbItem.Text.Split('-')[0].Trim(), out int equipmentID))
            {
                con.Open();
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @equipmentID AND status = 'Available'", con);
                cmd.Parameters.AddWithValue("@equipmentID", equipmentID);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvItemBorrow.Rows.Add(dateLabel.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }

                dr.Close();
                con.Close();

                txt_Barcode.Enabled = true;
                txt_Barcode.Focus();
            }
            else
            {
                MessageBox.Show("Invalid equipment ID");
            }
        }
        private void cmbPickCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPickCateg.SelectedItem != null)
            {
                cmbItem.Enabled = true;
                cmbItem.Text = "";
                txt_Barcode.Text = "";
                //cmbPickCateg.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        

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
            btnProceed.Enabled = false;
        }



        //categ combo box
        private void cmbCategLoad()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
                {
                    string selectQuery = "SELECT categ_name FROM lab_categ";
                    con.Open();
                    cmbPickCateg.Items.Clear();//clear to prevent loop

                    cmd = new SqlCommand(selectQuery, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string categName = $"{dr["categ_name"]}";
                        cmbPickCateg.Items.Add(categName);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }
        private void cmbPickCateg_DropDown(object sender, EventArgs e)
        {
            cmbCategLoad();
        }
        private void cmbPickCateg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        
    }
}

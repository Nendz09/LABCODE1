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

namespace LABCODE1
{
    public partial class StudentScanModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        BarcodeReader reader = new BarcodeReader();

        //DateTimePicker dtp = new DateTimePicker();
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        /*backgroundworker - is a component in .NET that simplifies working with background threads
        in a Windows Forms application*/
        private BackgroundWorker videoCaptureWorker;

        public StudentScanModule()
        {
            InitializeComponent();
            this.ActiveControl = txt_Barcode; //focus
            videoCaptureWorker = new BackgroundWorker();
            videoCaptureWorker.DoWork += VideoCaptureWorker_DoWork;
            videoCaptureWorker.RunWorkerCompleted += VideoCaptureWorker_RunWorkerCompleted;

            //datetimepicker initializer
            dgvItemBorrow.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd";
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



            if (this.IsHandleCreated) // Check if the form's handle is created
            {
                this.BeginInvoke(new Action(() =>
                {
                    // Check if the focus is on txt_Barcode or txt_BarcodeItem
                    if (txt_Barcode.Focused)
                    {
                        if (result != null)
                        {
                            txt_Barcode.Text = result.ToString();
                        }
                    }
                    else if (txt_BarcodeItem.Focused)
                    {
                        if (result != null)
                        {
                            txt_BarcodeItem.Text = result.ToString();
                        }
                    }
                }));
            }


            //if (result != null)
            //{
            //    txt_Barcode.Invoke(new MethodInvoker(delegate ()
            //    {
            //        //result.Text siya before
            //        txt_Barcode.Text = result.ToString();
            //    }));
            //    //BarcodeFormat barcodeFormat = result.BarcodeFormat;
            //}
            //pictureBox.Image = bitmap;

            //this is pag inverted
            //reader.AutoRotate = true;
            //reader.Options.TryInverted = true;
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
                    txt_BarcodeItem.Enabled = true;
                    txt_BarcodeItem.Focus();
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
            dateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void txt_BarcodeItem_TextChanged(object sender, EventArgs e)
        {
            dgvItemOnHand();
            if (dgvItemBorrow.RowCount != 0)
            {
                btnProceed.Enabled = true;
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txt_Barcode.Clear();
            txt_BarcodeItem.Clear();
            txt_Barcode.Enabled = true;
            txt_BarcodeItem.Enabled = false;
            btnProceed.Enabled = false;
            dgvItemBorrow.Rows.Clear();
            txt_Barcode.Focus();
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


            //int rowIndex = dgvItemBorrow.CurrentCell.RowIndex;
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //{
            //    string colName = dgvItemBorrow.Columns[e.ColumnIndex].Name;
            //    if (colName == "Delete")
            //    {
            //        dgvItemBorrow.Rows.RemoveAt(rowIndex);
            //    }
            //}
        }


        

        //methods
        private void dgvItemOnHand() 
        {
            con.Close();
            int i = 0;
            
            if (int.TryParse(cmbItem.Text, out int labID)) 
            {
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @labID", con);
                cmd.Parameters.AddWithValue("@labID", labID);
                con.Open();
                dr = cmd.ExecuteReader();

                

                while (dr.Read())
                {
                    ++i;
                    dgvItemBorrow.Rows.Add(dateLabel.Text, "", dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();
            }
        }


        //private void dgvItemBorrowedUpdate() 
        //{
        //    try
        //    {
        //        con.Open();

        //        for (int i = 0; i < dgvItemBorrow.RowCount; i++)
        //        {
        //            cmd = new SqlCommand("UPDATE lab_eqpment SET status = 'Borrowed' WHERE eqp_id = '" + dgvItemBorrow.Rows[i].Cells["col_itemid"] + "' ", con);
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}





        //private void isFilled()
        //{
        //    bool allTextIsFilled = !string.IsNullOrEmpty(txt_Barcode.Text);
        //    txt_BarcodeItem.Enabled = allTextIsFilled;
        //}

        private void dgvItemBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                dgvItemBorrow.Controls.Add(dtp);
                dtp.Visible = true;
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                // Set the location of the DateTimePicker to the clicked cell
                _Rectangle = dgvItemBorrow.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dtp.TextChanged += new EventHandler(DateTimePickerChange);
                dtp.CloseUp += new EventHandler(DateTimePickerClose);
            }
            else
            {
                dtp.Visible = false;
            }
        }
        //event handler for DateTimePicker's ValueChanged event.
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            // Set the selected date in the DataGridView cell.
            dgvItemBorrow.CurrentCell.Value = dtp.Value.ToString("yyyy-MM-dd");
            dtp.Visible = false; // Hide the DateTimePicker control.
        }

        private void DateTimePickerChange(object sender, EventArgs e)
        {
            dgvItemBorrow.CurrentCell.Value = dtp.Text.ToString();
            //MessageBox.Show(string.Format("Date changed to {0}", dtp.Text.ToString()));
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
        
                con.Open();

                List<int> itemIds = dgv_GetSelectedItemIds(); //list item (int type)

                
                dgv_UpdateLabEqpmentStatus(itemIds);
                dgv_InsertIntoLabBorrows();

                con.Close();
               
                MessageBox.Show("Borrowed");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private List<int> dgv_GetSelectedItemIds()
        {
            List<int> itemIds = new List<int>();


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
                cmd = new SqlCommand("INSERT INTO lab_borrows(date_borrow, student_id, name, year_sec, eqp_id, eqp_name, date_return, eqp_size) VALUES(@date_borrow, @student_id, @name, @year_sec, @eqp_id, @eqp_name, @date_return, @eqp_size)", con);
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
        private void cmbItemLoad() 
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE status = 'Available' ", con);
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

        private void cmbItem_DropDown(object sender, EventArgs e)
        {
            cmbItemLoad();
        }

        private void cmbItem_TextChanged(object sender, EventArgs e)
        {
            //dgvItemOnHand();
            //if (dgvItemBorrow.RowCount != 0)
            //{
            //    btnProceed.Enabled = true;
            //}
            //else
            //{
            //    btnProceed.Enabled = false;
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvItemOnHand();
        }
    }
}

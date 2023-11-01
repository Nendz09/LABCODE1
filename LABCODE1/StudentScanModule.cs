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

namespace LABCODE1
{
    public partial class StudentScanModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        BarcodeReader reader = new BarcodeReader();
        

        public StudentScanModule()
        {
            InitializeComponent();
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (filterInfoCollection.Count == 0)
            //{
            //    MessageBox.Show("No video capture devices found.");
            //    return;
            //}

            //videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCam.SelectedIndex].MonikerString);
            //videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            //videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //lalabas ko to
            //BarcodeReader reader = new BarcodeReader(); 

            //THIS ONE IS PARA MAANO FORMAT NG BARCODE VVVV----------
  
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txt_Barcode.Invoke(new MethodInvoker(delegate ()
                {
                    //result.Text siya before
                    txt_Barcode.Text = result.ToString();
                }));
                //BarcodeFormat barcodeFormat = result.BarcodeFormat;
            }
            //pictureBox.Image = bitmap;

            //this is pag inverted
            //reader.AutoRotate = true;
            //reader.Options.TryInverted = true;
        }


        private void StudentScanModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                    videoCaptureDevice.Stop();
            }
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
                    isFilled();
                    label_studentSection.Text = dr["year_sec"].ToString();
                    label_studentName.Text = dr["full_name"].ToString();
                    txt_Barcode.Enabled = false;
                }
                //else
                //{
                //    dgvItemBorrow.Rows.Clear();
                //    label_studentSection.Text = "...";
                //    label_studentName.Text = "NO DATA FOUND";
                //}
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

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void txt_BarcodeItem_TextChanged(object sender, EventArgs e)
        {
            dgvBorrowed();
        }

        //methods
        private void dgvBorrowed() 
        {
            con.Close();
            int i = 0;
            
            if (int.TryParse(txt_BarcodeItem.Text, out int labID)) 
            {
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, eqp_size FROM lab_eqpment WHERE eqp_id = @labID", con);
                cmd.Parameters.AddWithValue("@labID", labID);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ++i;
                    dgvItemBorrow.Rows.Add(dateLabel.Text, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();
            }

            //cmd = new SqlCommand("SELECT * FROM lab_eqpment", con);
            //con.Open();
            //dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ++i;
            //    dgvItemBorrow.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            //}
            //dr.Close();
            //con.Close();
        }
        private void isFilled()
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txt_Barcode.Text);
            txt_BarcodeItem.Enabled = allTextIsFilled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Barcode.Clear();
            txt_BarcodeItem.Clear();
            txt_Barcode.Enabled = true;
            txt_BarcodeItem.Enabled = false;
            dgvItemBorrow.Rows.Clear();
        }
    }
}

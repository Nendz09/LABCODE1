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
                    label_studentSection.Text = dr["year_sec"].ToString();
                    label_studentName.Text = dr["full_name"].ToString();
                }
                else
                {
                    label_studentSection.Text = "...";
                    label_studentName.Text = "NO DATA FOUND";
                }
                dr.Close();
            }
            else
            {
                label_studentName.Text = "Invalid Student ID or NOT a number";
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
    }
}

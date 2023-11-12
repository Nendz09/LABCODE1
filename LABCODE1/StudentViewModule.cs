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
    public partial class StudentViewModule : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public StudentViewModule()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        //methods
        public void LoadStudentView()
        {
            con.Close();
            int i = 0;

            if (int.TryParse(txt_studentid.Text, out int studID))
            {
                cmd = new SqlCommand("SELECT eqp_id, eqp_name, date_borrow, date_return FROM lab_borrows WHERE student_id = @studID", con);
                cmd.Parameters.AddWithValue("@studID", studID);
                con.Open();
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    ++i;
                    dgvStudentView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();
            }
        }
    }
}

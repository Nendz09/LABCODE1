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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
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

    }
}

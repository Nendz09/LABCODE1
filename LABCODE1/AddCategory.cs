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
    public partial class AddCategory : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Admin\Documents\Inventory_Labcode.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        SqlDataReader dr;
        DashboardForm dbForm = new DashboardForm();
        public AddCategory()
        {
            InitializeComponent();
            LoadCateg();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool textWhiteSpace = string.IsNullOrWhiteSpace(txtCategName.Texts);

            if (textWhiteSpace)
            {
                MessageBox.Show("Unable to input that contains only whitespace", "No whitespace please", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string categName = txtCategName.Texts;
                string trimmedInput = categName.Trim();
                try
                {
                    string insertQuery = $@"INSERT INTO lab_categ (categ_name)
                                    VALUES (@categ_name)";

                    con.Open();
                    cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@categ_name", trimmedInput);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added a new Category!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //dashboard
                    string msg = $"You added {trimmedInput} as a new Category!";
                    dbForm.InsertRecentActivities(msg);

                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred. Please remove your Duplicate ID", "REMOVE DUPLICATE ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            LoadCateg();
        }


        //methods
        private void LoadCateg() 
        {
            try
            {
                int i = 0;
                dgvCateg.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM lab_categ", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ++i;
                    dgvCateg.Rows.Add(dr[1].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void Clear() 
        {
            txtCategName.Clear();
        }



        private bool IsFilled() 
        {
            bool allTextIsFilled = !string.IsNullOrEmpty(txtCategName.Texts);
            btnAdd.Enabled = allTextIsFilled;
            return allTextIsFilled;
        }

        

        private void txtCategName__TextChanged(object sender, EventArgs e)
        {
            IsFilled();
        }

        private void dgvCateg_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvCateg.ClearSelection();
        }

        private void dgvCateg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCateg.Columns[e.ColumnIndex].Name;
            if (colName == "Delete") 
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Deleting Category", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM lab_categ WHERE categ_name = @categName", con);
                    cmd.Parameters.AddWithValue("@categName", dgvCateg.Rows[e.RowIndex].Cells[0].Value.ToString());

                    //dashboard
                    string categName = dgvCateg.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string msg = $"You have successfully removed the category '{categName}'";
                    dbForm.InsertRecentActivities(msg);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                LoadCateg();
            }
        }
        
    }
}

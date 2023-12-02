using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO;

namespace LABCODE1
{
    public partial class BackUpForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");


        public BackUpForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = dlg.SelectedPath;
            }


            //saveFileDialog1.AddExtension = true;
            //saveFileDialog1.Filter = "Backup Files (*.bak)|*.bak";
            //saveFileDialog1.ShowDialog();
            //txtBackupPath.Text = saveFileDialog1.FileName;
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtBackupPath.Text == string.Empty)
            {
                MessageBox.Show("Select the location of your backup file");
                return;
            }

            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True"))
                {
                    connection.Open();

                    // Fetch the database name
                    string databaseName = connection.Database;

                    string backupPath = Path.Combine(txtBackupPath.Text, $"Inventory_Labcode-{date}.bak");

                    using (SqlCommand command = new SqlCommand($"BACKUP DATABASE [{databaseName}] TO DISK = '{backupPath}' WITH INIT", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Backup completed successfully.", "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        //----- RESTORATION NG DATABASE -----//


        private void btnBrowse_Recover_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL Server database backup files |*.bak";
            dlg.Title = "database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestorePath.Text = dlg.FileName;
            }

        }
        
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtRestorePath.Text == string.Empty)
            {
                MessageBox.Show("Please select the location of the backup file");
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True")) 
                {
                    connection.Open();

                    //fetch the database name
                    string databaseName = connection.Database;

                    //step 1: Set the database to single-user mode
                    string setSingleUserQuery = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand setSingleUserCmd = new SqlCommand(setSingleUserQuery, connection))
                    {
                        setSingleUserCmd.ExecuteNonQuery();
                    }

                    //step 2: Perform the restore operation
                    string restoreQuery = $"USE MASTER RESTORE DATABASE [{databaseName}] FROM DISK = '{txtRestorePath.Text}' WITH REPLACE;";
                    using (SqlCommand restoreCmd = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCmd.ExecuteNonQuery();
                    }

                    //step 3: Set the database back to multi-user mode
                    string setMultiUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER";
                    using (SqlCommand setMultiUserCmd = new SqlCommand(setMultiUserQuery, connection))
                    {
                        setMultiUserCmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Backup successfully restored");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

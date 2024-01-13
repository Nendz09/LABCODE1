using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


// ... (existing using statements)

namespace LABCODE1
{
    public partial class ItemDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

        private List<Item> itemList = new List<Item>();

        public ItemDetails()
        {
            InitializeComponent();
            //InitializeListView();
            //LoadData();
            LoadCategories();
            LoadDataDGV();

            dataGridView1.MouseWheel += dataGridView1_MouseWheel;
        }

        //private void InitializeListView()
        //{
        //    listViewItems.View = View.Details;

        //    listViewItems.Columns.Add("Image", 300);
        //    listViewItems.Columns.Add("Name", 300);
        //    listViewItems.Columns.Add("Category", 300);
        //    listViewItems.Columns.Add("Description", 450);

        //    listViewItems.Font = new Font("Arial", 12, FontStyle.Regular);



        //    //listViewItems.Columns["Name"].Width = 150;
        //    //listViewItems.Columns["Image"].Width = 150;
        //    //listViewItems.Columns["Category"].Width = 150;
        //    //listViewItems.Columns["Description"].Width = 200;
        //}

        //private void AutoResizeListViewColumns()
        //{
        //    // Auto-resize columns to fit content
        //    foreach (ColumnHeader column in listViewItems.Columns)
        //    {
        //        column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    }
        //}


        public void LoadDataDGV()
        {
            try
            {
                //dataGridView1.ClearSelection();
                dataGridView1.Rows.Clear();

                con.Open();
                string query = "SELECT name_eqp, img_eqp, categ_eqp, desc_eqp FROM lab_eqpDetails";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imageData = reader["img_eqp"] as byte[];

                            Item item = new Item
                            {
                                Name = reader["name_eqp"].ToString(),
                                Category = reader["categ_eqp"].ToString(),
                                Description = reader["desc_eqp"].ToString()
                            };

                            itemList.Add(item);
                            AddDataGridViewRow(item, imageData);
                        }
                    }
                }
                //AutoResizeListViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddDataGridViewRow(Item item, byte[] imageData)
        {
            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image img = Image.FromStream(ms);
                    row.Cells["image_col"].Value = img;
                }
            }

            row.Cells["name_col"].Value = item.Name;
            row.Cells["categ_col"].Value = item.Category;
            row.Cells["desc_col"].Value = item.Description;
        }



        //private void LoadData()
        //{
        //    try
        //    {
        //        itemList.Clear();
        //        listViewItems.Items.Clear();

        //        con.Open();
        //        string query = "SELECT name_eqp, img_eqp, categ_eqp, desc_eqp FROM lab_eqpDetails";

        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    byte[] imageData = reader["img_eqp"] as byte[];

        //                    Item item = new Item
        //                    {
        //                        Name = reader["name_eqp"].ToString(),
        //                        Category = reader["categ_eqp"].ToString(),
        //                        Description = reader["desc_eqp"].ToString()
        //                    };

        //                    itemList.Add(item);
        //                    AddListViewItem(item, imageData);
        //                }
        //            }
        //        }
        //        //AutoResizeListViewColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading data: " + ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void AddListViewItem(Item item, byte[] imageData)
        //{
        //    ListViewItem listViewItem = new ListViewItem();

        //    if (imageData != null && imageData.Length > 0)
        //    {
        //        using (MemoryStream ms = new MemoryStream(imageData))
        //        {
        //            Image img = Image.FromStream(ms);

        //            // Add the image to the ImageList and set the ImageKey
        //            string imageKey = AddImageToImageList(img);
        //            listViewItem.ImageKey = imageKey;
        //        }
        //    }
        //    else
        //    {
        //        listViewItem.ImageIndex = -1; // No image
        //    }
        //    listViewItem.SubItems.Add(item.Name);
        //    listViewItem.SubItems.Add(item.Category);
        //    listViewItem.SubItems.Add(item.Description);

        //    listViewItems.Items.Add(listViewItem);
        //}

        //private string AddImageToImageList(Image img)
        //{
        //    // Generate a unique key for the image
        //    string imageKey = Guid.NewGuid().ToString();

        //    // Add the image to the ImageList
        //    listViewItems.SmallImageList.Images.Add(imageKey, img);

        //    return imageKey;
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
            itemDetailsModule.btnUpdate.Enabled = false;
            itemDetailsModule.ShowDialog();
            //LoadData();
            LoadDataDGV();
        }

        


        private void LoadCategories() //combobox
        {
            try
            {
                con.Open();
                string query = "SELECT DISTINCT categ_eqp FROM lab_eqpDetails";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategories.Items.Add(reader["categ_eqp"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategories.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                dataGridView1.Rows.Clear();

                try
                {
                    con.Open();
                    string query = "SELECT name_eqp, img_eqp, categ_eqp, desc_eqp FROM lab_eqpDetails WHERE categ_eqp = @selectedCategory";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@selectedCategory", selectedCategory);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] imageData = reader["img_eqp"] as byte[];

                                Item item = new Item
                                {
                                    Name = reader["name_eqp"].ToString(),
                                    Category = reader["categ_eqp"].ToString(),
                                    Description = reader["desc_eqp"].ToString()
                                };
                                AddDataGridViewRow(item, imageData);
                            }
                        }
                    }
                    //AutoResizeListViewColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            if (cmbCategories.SelectedItem.ToString() == "All")
            {
                LoadDataDGV();
            }


        }


        //DATAGRIDVIEW

        private void dataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledMouseEventArgs = e as HandledMouseEventArgs;

            if (handledMouseEventArgs != null)
            {
                // Set Handled to true to prevent the default scroll behavior
                handledMouseEventArgs.Handled = true;

                // Your custom scrolling logic here
                int currentRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;

                if (e.Delta > 0)
                {
                    // Scrolling up
                    int newRow = Math.Max(0, currentRowIndex - 1);
                    dataGridView1.FirstDisplayedScrollingRowIndex = newRow;
                }
                else if (e.Delta < 0)
                {
                    // Scrolling down
                    int newRow = Math.Min(dataGridView1.RowCount - 1, currentRowIndex + 1);
                    dataGridView1.FirstDisplayedScrollingRowIndex = newRow;
                }
            }
        }



        private int previousScrollValue = 0;
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            //{
            //    int currentRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;

            //    if (e.NewValue > previousScrollValue)
            //    {
            //        // Scrolling down
            //        int newRow = Math.Min(dataGridView1.RowCount - 1, currentRowIndex + 1);
            //        dataGridView1.FirstDisplayedScrollingRowIndex = newRow;
            //    }
            //    else if (e.NewValue < previousScrollValue)
            //    {
            //        // Scrolling up
            //        int newRow = Math.Max(0, currentRowIndex - 1);
            //        dataGridView1.FirstDisplayedScrollingRowIndex = newRow;
            //    }

            //    previousScrollValue = e.NewValue;
            //}
        }


        //private void listViewItems_Click(object sender, EventArgs e)
        //{
        //    if (listViewItems.SelectedItems.Count > 0)
        //    {
        //        // Access the selected item
        //        ListViewItem selectedItem = listViewItems.SelectedItems[0];

        //        // Check if there is at least one subitem in the selected item
        //        if (selectedItem.SubItems.Count > 1)
        //        {
        //            // Access the text of the second subitem (index 1) in the selected item
        //            string itemName = selectedItem.SubItems[1].Text;
        //            string itemDesc = selectedItem.SubItems[3].Text;

        //            ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
        //            itemDetailsModule.btnSave.Enabled = false;

        //            itemDetailsModule.LoadItemPicture(itemName);

        //            itemDetailsModule.txt_Description.Text = itemDesc;
        //            itemDetailsModule.txt_itemName.Text = itemName;
        //            itemDetailsModule.cmbCateg.Text = itemName;

        //            itemDetailsModule.ShowDialog();
        //        }
        //    }

        //    //MessageBox.Show(itemName);
        //}



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Only the first column (image) is clickable
            {
                // Access the data in the clicked cell
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string itemName = selectedRow.Cells["name_col"].Value.ToString();
                string itemDesc = selectedRow.Cells["desc_col"].Value.ToString();

                // Your logic to open the details form
                ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
                itemDetailsModule.btnSave.Enabled = false;

                itemDetailsModule.LoadItemPicture(itemName);

                itemDetailsModule.txt_Description.Text = itemDesc;
                itemDetailsModule.txt_itemName.Text = itemName;
                itemDetailsModule.txt_itemName.Enabled = false;

                string categVal = selectedRow.Cells["categ_col"].Value.ToString();
                itemDetailsModule.cmbCateg.DropDownStyle = ComboBoxStyle.DropDown;
                itemDetailsModule.cmbCateg.Text = categVal;

                itemDetailsModule.ShowDialog();

                LoadDataDGV();
            }
            
            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            //{
            //    // Access the data in the clicked cell
            //    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            //    string itemName = selectedRow.Cells["name_col"].Value.ToString();
            //    string itemDesc = selectedRow.Cells["desc_col"].Value.ToString();

            //    // Your logic to open the details form
            //    ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
            //    itemDetailsModule.btnSave.Enabled = false;

            //    itemDetailsModule.LoadItemPicture(itemName);

            //    itemDetailsModule.txt_Description.Text = itemDesc;
            //    itemDetailsModule.txt_itemName.Text = itemName;
            //    itemDetailsModule.txt_itemName.Enabled = false;

            //    //itemDetailsModule.cmbCateg.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            //    string categVal = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    itemDetailsModule.cmbCateg.DropDownStyle = ComboBoxStyle.DropDown;
            //    itemDetailsModule.cmbCateg.Text = categVal;

            //    itemDetailsModule.ShowDialog();
            //}
            //LoadDataDGV();
        }

        //private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) //image hand cursor
        //    {
        //        DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

        //        if (cell is DataGridViewImageCell)
        //        {
        //            Cursor = Cursors.Hand;
        //        }
        //    }
        //}

        //private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    Cursor = Cursors.Default;
        //}

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewImageCell)
                {
                    Cursor = Cursors.Hand; // Change the cursor to Hand when over the image cell
                    return;
                }
            }

            Cursor = Cursors.Default; // Change the cursor back to the default when not over an image cell
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}





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
            InitializeListView();
            LoadData();
            LoadCategories();
        }

        private void InitializeListView()
        {
            listViewItems.View = View.Details;

            listViewItems.Columns.Add("Image", 300);
            listViewItems.Columns.Add("Name", 300);
            listViewItems.Columns.Add("Category", 300);
            listViewItems.Columns.Add("Description", 450);

            listViewItems.Font = new Font("Arial", 12, FontStyle.Regular);

            //listViewItems.Columns["Name"].Width = 150;
            //listViewItems.Columns["Image"].Width = 150;
            //listViewItems.Columns["Category"].Width = 150;
            //listViewItems.Columns["Description"].Width = 200;
        }

        //private void AutoResizeListViewColumns()
        //{
        //    // Auto-resize columns to fit content
        //    foreach (ColumnHeader column in listViewItems.Columns)
        //    {
        //        column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    }
        //}

        private void LoadData()
        {
            try
            {
                itemList.Clear();
                listViewItems.Items.Clear();

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
                            AddListViewItem(item, imageData);
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

        private void AddListViewItem(Item item, byte[] imageData)
        {
            ListViewItem listViewItem = new ListViewItem();

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image img = Image.FromStream(ms);

                    // Add the image to the ImageList and set the ImageKey
                    string imageKey = AddImageToImageList(img);
                    listViewItem.ImageKey = imageKey;
                }
            }
            else
            {
                listViewItem.ImageIndex = -1; // No image
            }
            listViewItem.SubItems.Add(item.Name);
            listViewItem.SubItems.Add(item.Category);
            listViewItem.SubItems.Add(item.Description);

            listViewItems.Items.Add(listViewItem);
        }

        private string AddImageToImageList(Image img)
        {
            // Generate a unique key for the image
            string imageKey = Guid.NewGuid().ToString();

            // Add the image to the ImageList
            listViewItems.SmallImageList.Images.Add(imageKey, img);

            return imageKey;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
            itemDetailsModule.btnUpdate.Enabled = false;
            itemDetailsModule.ShowDialog();
            LoadData();
        }

        private void listViewItems_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                // Access the selected item
                ListViewItem selectedItem = listViewItems.SelectedItems[0];

                // Check if there is at least one subitem in the selected item
                if (selectedItem.SubItems.Count > 1)
                {
                    // Access the text of the second subitem (index 1) in the selected item
                    string itemName = selectedItem.SubItems[1].Text;
                    string itemDesc = selectedItem.SubItems[3].Text;

                    ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
                    itemDetailsModule.btnSave.Enabled = false;

                    itemDetailsModule.LoadItemPicture(itemName);

                    itemDetailsModule.txt_Description.Text = itemDesc;
                    itemDetailsModule.txt_itemName.Text = itemName;
                    itemDetailsModule.cmbCateg.Text = itemName;   

                    itemDetailsModule.ShowDialog();
                }
            }

            //MessageBox.Show(itemName);
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
                // Clear existing items in the ListView
                listViewItems.Items.Clear();

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

                                AddListViewItem(item, imageData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading items: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            if (cmbCategories.SelectedItem.ToString() == "All")
            {
                LoadData();
            }


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



//namespace LABCODE1
//{
//    public partial class ItemDetails : Form
//    {
//        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;Integrated Security=True");

//        private List<Item> itemList = new List<Item>();

//        public ItemDetails()
//        {
//            InitializeComponent();
//            InitializeListView();
//            LoadData();
//        }

//        private void InitializeListView()
//        {
//            listViewItems.View = View.Details;

//            listViewItems.Columns.Add("Name", 150);
//            listViewItems.Columns.Add("Image", 150);
//            listViewItems.Columns.Add("Category", 150);
//            listViewItems.Columns.Add("Description", 200);
//        }

//        private void LoadData()
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection("your_connection_string"))
//                {
//                    con.Open();

//                    string query = "SELECT name_eqp, img_eqp, categ_eqp, desc_eqp FROM lab_eqpDetails";
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                byte[] imageData = reader["img_eqp"] as byte[];

//                                Item item = new Item
//                                {
//                                    Name = reader["name_eqp"].ToString(),
//                                    ImageBytes = imageData,
//                                    Category = reader["categ_eqp"].ToString(),
//                                    Description = reader["desc_eqp"].ToString()
//                                };

//                                itemList.Add(item);
//                                AddListViewItem(item);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading data: " + ex.Message);
//            }

//            //try
//            //{
//            //    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
//            //                                                AttachDbFilename=|DataDirectory|\Inventory_Labcode.mdf;
//            //                                                Integrated Security=True"))
//            //    {
//            //        con.Open();

//            //        string query = "SELECT name_eqp, img_eqp, categ_eqp, desc_eqp FROM lab_eqpDetails";
//            //        using (SqlCommand cmd = new SqlCommand(query, con))
//            //        {
//            //            using (SqlDataReader reader = cmd.ExecuteReader())
//            //            {
//            //                while (reader.Read())
//            //                {
//            //                    // Assuming the "Image" column contains the file path to the image
//            //                    string imagePath = reader["img_eqp"] == DBNull.Value ? string.Empty : reader["img_eqp"].ToString();

//            //                    Item item = new Item
//            //                    {
//            //                        Name = reader["name_eqp"].ToString(),
//            //                        ImagePath = imagePath,
//            //                        Category = reader["categ_eqp"].ToString(),
//            //                        Description = reader["desc_eqp"].ToString()
//            //                    };

//            //                    itemList.Add(item);
//            //                    AddListViewItem(item);
//            //                }
//            //            }
//            //        }
//            //    }
//            //}
//            //catch (Exception ex)
//            //{
//            //    MessageBox.Show("Error loading data: " + ex.Message);
//            //}
//        }


//        private void AddListViewItem(Item item)
//        {
//            ListViewItem listViewItem = new ListViewItem(item.Name);


//            if (item.ImageBytes != null && item.ImageBytes.Length > 0)
//            {
//                using (MemoryStream ms = new MemoryStream(item.ImageBytes))
//                {
//                    Image img = Image.FromStream(ms);
//                    listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, "", img));
//                }
//            }
//            else
//            {
//                listViewItem.SubItems.Add(string.Empty);
//            }


//            listViewItem.SubItems.Add(item.Category);
//            listViewItem.SubItems.Add(item.Description);

//            listViewItems.Items.Add(listViewItem);
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
//            itemDetailsModule.ShowDialog();
//        }


//    }

//    public class Item
//    {
//        public string Name { get; set; }
//        public byte[] ImageBytes { get; set; }
//        public string Category { get; set; }
//        public string Description { get; set; }
//    }
//}

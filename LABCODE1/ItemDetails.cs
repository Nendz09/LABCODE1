using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABCODE1
{
    public partial class ItemDetails : Form
    {
        private List<Item> itemList = new List<Item>();

        public ItemDetails()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            listViewItems.View = View.Details;

           
            listViewItems.Columns.Add("Name", 150);
            listViewItems.Columns.Add("Image", 150);
            listViewItems.Columns.Add("Category", 150);
            listViewItems.Columns.Add("Description", 200);

         
            itemList.Add(new Item { Name = "Item 1", ImagePath = "path_to_image1.jpg", Description = "Description 1" });
            itemList.Add(new Item { Name = "Item 2", ImagePath = "path_to_image2.jpg", Description = "Description 2" });

            foreach (var item in itemList)
            {
                AddListViewItem(item);
            }
        }

        private void AddListViewItem(Item item)
        {
            ListViewItem listViewItem = new ListViewItem(item.Name);
            listViewItem.SubItems.Add(item.ImagePath);
            listViewItem.SubItems.Add(item.Description);

            listViewItems.Items.Add(listViewItem);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemDetailsModule itemDetailsModule = new ItemDetailsModule();
            itemDetailsModule.ShowDialog();
        }


    }

    public class Item
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}

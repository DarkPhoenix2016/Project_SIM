using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project_SIM.Models.SimProduct;

namespace Project_SIM.Views.User
{
    public partial class InventoryList : MaterialForm
    {
        private int currentItem = 1;
        private SimProduct simProduct = new SimProduct();
        private double[] coloumRatios = { 0.05, 0.25, 0.40, 0.20,0.05 };

        public InventoryList()
        {
            InitializeComponent();
            FormatMaker.SetupListViewColumns(listViewProductList, coloumRatios);

        }

        private void LoadData()
        {
            listViewProductList.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data
            string searchWord = txtSearchWord.Text.Trim();

            if (string.IsNullOrEmpty(searchWord))
            {
                return;
            }

            List<SimProductData> productList = simProduct.GetProductsByProductCodeSearch(searchWord);

            if (productList != null && productList.Count > 0)
            {
                // Iterate over the list and process each SimProductData object
                foreach (SimProductData product in productList)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(product.ProductCode);
                    newItem.SubItems.Add(product.Name);
                    newItem.SubItems.Add(product.Price.ToString("0.00"));
                    newItem.SubItems.Add(product.Unit);
                    listViewProductList.Items.Add(newItem);
                    currentItem++;
                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
                
            }
        }

        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                listViewProductList.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadData();
            }
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                listViewProductList.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadData();
            }
        }

        private void listViewProductList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listViewProductList.SelectedItems.Count > 0 && !string.IsNullOrEmpty(listViewProductList.SelectedItems[0].SubItems[1].Text))
                {
                    Dashborad.SelectedItemFromInvetory = listViewProductList.SelectedItems[0].SubItems[1].Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                    FormatMaker.ShowErrorMessageBox("Please Select a Valid item");
                    listViewProductList.Focus();
                    listViewProductList.SelectedItems.Clear();  // Clear the selected items
                    listViewProductList.Select();
                }


            }
        }
    }
}

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
using Windows.UI.Xaml.Controls.Primitives;
using static Project_SIM.Models.SimProduct;

namespace Project_SIM.Views.StoreKeeper
{
    public partial class Products : MaterialForm
    {
        private double[] coloumRatios = { 0.05, 0.25, 0.30, 0.15, 0.15 };
        private int currentItem = 1;
        private SimProduct simProduct = new SimProduct();
        private List<SimProductData> productList;

        public Products()
        {
            InitializeComponent();
            FormatMaker.SetupListViewColumns(listViewProductList, coloumRatios);
            LoadData();
        }

        private void Products_Resize(object sender, EventArgs e)
        {
            FormatMaker.SetupListViewColumns(listViewProductList, coloumRatios);
        }

        private void LoadData()
        {
            listViewProductList.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data
            string searchWord = txtSearchWord.Text.Trim();

            if (string.IsNullOrEmpty(searchWord))
            {
                searchWord = "%";
            }

            productList = simProduct.GetProductsByProductCodeSearch(searchWord,true,true);

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

        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                listViewProductList.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
                LoadData();
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

        private void listViewProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void LoadProductData()
        {

            if (listViewProductList.SelectedItems.Count > 0)
            {
                int selectedIndex = listViewProductList.SelectedIndices[0];

                SimProductData selectedItem = productList[selectedIndex];

                txtProductCode.Text = selectedItem.ProductCode;
                txtProductName.Text = selectedItem.Name;
                txtProductCategory.Text = selectedItem.CatDiscription;
                txtProductUnitPrice.Text = selectedItem.Price.ToString("0.00");
                txtProductMasureUnit.Text = selectedItem.Unit;

            }
            else
            {
                txtProductCode.Text = string.Empty;
                txtProductName.Text = string.Empty;
                txtProductCategory.Text = string.Empty;
                txtProductUnitPrice.Text = string.Empty;
                txtProductMasureUnit.Text = string.Empty;
            }

        }
    }
}

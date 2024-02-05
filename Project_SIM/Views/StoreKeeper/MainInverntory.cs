using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Project_SIM.Models.SimProduct;


namespace Project_SIM.Views.StoreKeeper
{
    public partial class MainInventory : MaterialForm
    {
        private int currentItem = 1;
        private double[] coloumRatios = { 0.05, 0.15, 0.10, 0.20, 0.10,0.15,0.15 };

        private SimInventory InventoryClass;
        private SimProduct simProduct;

        private SubViews.AddToMainInventory AddToMainInventory;


        List<StoreStockedProducts> productList;

        public MainInventory()
        {
            InitializeComponent();
            FormatMaker.SetupListViewColumns(ListViewProductInventory, coloumRatios);
            txtSearchWord.Focus();

            simProduct = new SimProduct();
            InventoryClass = new SimInventory();
            productList = new List<StoreStockedProducts>();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Inventory_Resize(object sender, EventArgs e)
        {
            FormatMaker.SetupListViewColumns(ListViewProductInventory, coloumRatios);
        }

        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                ListViewProductInventory.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadData(txtSearchWord.Text);
            }
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                ListViewProductInventory.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadData(txtSearchWord.Text);
            }
        }

        private void ListViewProductInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItemData();
        }

        private void LoadData()
        {
            ListViewProductInventory.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data

            productList = InventoryClass.GetMainStockedProductsInverntory();

            if (productList != null && productList.Count > 0)
            {
                // Iterate over the list and process each SimProductData object
                foreach (StoreStockedProducts item in productList)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());

                    newItem.SubItems.Add(item.ProductCode);
                    newItem.SubItems.Add(item.Name);
                    newItem.SubItems.Add(item.Quantity.ToString());
                    newItem.SubItems.Add(item.ExpiryDate.ToShortDateString());
                    newItem.SubItems.Add(item.StockLocation);

                    ListViewProductInventory.Items.Add(newItem);
                    currentItem++;
                }
            }
        }

        private void LoadData(string productNameOrCode)
        {
            ListViewProductInventory.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data
            if (!(string.IsNullOrEmpty(productNameOrCode)||string.IsNullOrWhiteSpace(productNameOrCode)))
            {
                productList = InventoryClass.GetMainStockedProductsInverntory(productNameOrCode);

                if (productList != null && productList.Count > 0)
                {
                    // Iterate over the list and process each SimProductData object
                    foreach (StoreStockedProducts item in productList)
                    {
                        ListViewItem newItem = new ListViewItem(currentItem.ToString());

                        newItem.SubItems.Add(item.ProductCode);
                        newItem.SubItems.Add(item.Name);
                        newItem.SubItems.Add(item.Quantity.ToString());
                        newItem.SubItems.Add(item.ExpiryDate.ToShortDateString());
                        newItem.SubItems.Add(item.StockLocation);

                        ListViewProductInventory.Items.Add(newItem);
                        currentItem++;
                    }
                }
            }
            
        }

        private void LoadSelectedItemData()
        {
            if (ListViewProductInventory.SelectedItems.Count > 0 && !string.IsNullOrEmpty(ListViewProductInventory.SelectedItems[0].SubItems[1].Text))
            {
                int selectedIndex = int.Parse(ListViewProductInventory.SelectedItems[0].SubItems[0].Text);

                StoreStockedProducts selectedInventoryRecord = productList[selectedIndex-1];

                string productCode = ListViewProductInventory.SelectedItems[0].SubItems[2].Text;

                SimProductData selectedProductData = simProduct.GetProductByCodeOrBarcode(productCode);

                StoreStockProductSum selectedProductSums = InventoryClass.GetStoreStockProductSum(productCode);

                //Set Product Data
                TxtProductCode.Text = selectedProductData.ProductCode;
                TxtProductName.Text = selectedProductData.Name;
                TxtBarcode.Text = selectedProductData.Barcode;
                TxtUnitPrice.Text = selectedProductData.Price.ToString("0.00");
                TxtUnitOfMasure.Text = selectedProductData.Unit;

                //Set inventroy record data
                TxtQunatity.Text = selectedInventoryRecord.Quantity.ToString("0.000");
                TxtExpiryDate.Text = selectedInventoryRecord.ExpiryDate.ToString("dd-MM-yyyy");
                TxtRemark.Text = selectedInventoryRecord.Remark;
                TxtStockLocation.Text = selectedInventoryRecord.StockLocation;

                // Set Sums Data

                TxtTotalStock.Text = selectedProductSums.TotalQuantity.ToString("0.000");
                TxtTotalSale.Text = selectedProductSums.TotalSoldQuantity.ToString("0.000");
                TxtTotalRetuens.Text = selectedProductSums.TotalReturnedQuantity.ToString("0.000");
                TxtTotalCurrentStock.Text = selectedProductSums.Balance.ToString("0.000");

                lblUnit1.Text = TxtUnitOfMasure.Text = selectedProductData.Unit;
                lblUnit2.Text = TxtUnitOfMasure.Text = selectedProductData.Unit;
                lblUnit3.Text = TxtUnitOfMasure.Text = selectedProductData.Unit;
                lblUnit4.Text = TxtUnitOfMasure.Text = selectedProductData.Unit;



            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            AddToMainInventory = new SubViews.AddToMainInventory();
            AddToMainInventory.ShowDialog();
        }

    }
}

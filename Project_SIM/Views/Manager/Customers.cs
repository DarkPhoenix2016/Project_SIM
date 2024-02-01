using BrightIdeasSoftware;
using MaterialSkin.Controls;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Project_SIM.Views.Manager
{
    public partial class Customers : MaterialForm
    {

        SimCustomer cutomer;
        SimUser user;
        List<SimCustomer.Customer> customerList;
        public Customers()
        {
            InitializeComponent();
            cutomer = new SimCustomer();
            user = new SimUser();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            SimCustomer cutomer = new SimCustomer();
            customerList = cutomer.GetCoustomers();
            ShowData();
        }
        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            customerList = cutomer.GetCoustomers(txtSearchWord.Text.Trim());
            ShowData();
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            customerList = cutomer.GetCoustomers(txtSearchWord.Text.Trim());
            ShowData();
        }

        private void chckBoxShowGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBoxShowGroups.Checked == true)
            {
                objListCustomers.ShowGroups = true;
            }

            if (chckBoxShowGroups.Checked == false)
            {
                objListCustomers.ShowGroups = false;
            }
        }

        private void ShowData()
        {
            // Set aspect getters for each column to display the desired details
            no.AspectGetter = (s) => (s as SimCustomer.Customer)?.RecordId.ToString();
            username.AspectGetter = (s) => (s as SimCustomer.Customer)?.Username.ToString();
            fullName.AspectGetter = (s) => (s as SimCustomer.Customer)?.FullName;
            accountState.AspectGetter = (s) => (s as SimCustomer.Customer)?.State;

            // Button column set up for viewing the User
            SetupButtonColumn(view, "View/Update");

            // Button column set up for activating the User
            SetupButtonColumn(activate, "Activate");

            // Button column set up for deactivating the User
            SetupButtonColumn(deactivate, "Deactivate");

            // Clear existing items and set new objects to the ListView
            objListCustomers.Items.Clear();
            objListCustomers.SetObjects(customerList);
        }

        private void SetupButtonColumn(OLVColumn column,string buttonText)
        {
            column.IsButton = true;
            column.ButtonSizing = OLVColumn.ButtonSizingMode.FixedBounds;
            column.AspectGetter = (s) => buttonText;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            customerList = cutomer.GetCoustomers();
            ShowData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            RegCustomer regCustomer = new RegCustomer();
            DialogResult result = regCustomer.ShowDialog();

            if (result == DialogResult.Yes)
            {
                customerList = cutomer.GetCoustomers();
                ShowData();
            }

        }

        private void objListCustomers_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == view)
            {
                try
                {
                    int clickedRow = e.RowIndex;  // Get the row index of the clicked button

                    Console.WriteLine($"Index of the Clicked Row: {clickedRow}");

                    if (clickedRow >= 0 && clickedRow < customerList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimCustomer.Customer selectedCustomer = e.Model as SimCustomer.Customer;

                        if (selectedCustomer != null)
                        {
                            UpdateDetailsForm viewForm = new UpdateDetailsForm();
                            viewForm.setCustomerDetails(selectedCustomer);
                            viewForm.Show();
                            customerList = cutomer.GetCoustomers();
                            ShowData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (e.Column == activate)
            {
                try
                {
                    int clickedRow = e.RowIndex;  // Get the row index of the clicked button

                    Console.WriteLine($"Index of the Clicked Row: {clickedRow}");

                    if (clickedRow >= 0 && clickedRow < customerList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimCustomer.Customer selectedCustomer = e.Model as SimCustomer.Customer;

                        if (selectedCustomer != null && selectedCustomer.State != "Active")
                        {
                            bool result = user.SetState(selectedCustomer.UserID,true);
                            if (result)
                            {
                                MessageBox.Show("Customer Account State Updated As Active...!", "State Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                customerList = cutomer.GetCoustomers();
                                ShowData();
                            }
                            else
                            {
                                FormatMaker.ShowErrorMessageBox("Error While Updating State!");
                            }
                            
                        }
                        else {

                            FormatMaker.ShowErrorMessageBox("Selected Customer Alrady in Active State!");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (e.Column == deactivate)
            {
                try
                {
                    int clickedRow = e.RowIndex;  // Get the row index of the clicked button

                    Console.WriteLine($"Index of the Clicked Row: {clickedRow}");

                    if (clickedRow >= 0 && clickedRow < customerList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimCustomer.Customer selectedCustomer = e.Model as SimCustomer.Customer;

                        if (selectedCustomer != null && selectedCustomer.State != "Deactive")
                        {
                            bool result = user.SetState(selectedCustomer.UserID, false);
                            if (result)
                            {
                                MessageBox.Show("Customer Account State Updated As Deactive...!", "State Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                customerList = cutomer.GetCoustomers();
                                ShowData();
                            }
                            else
                            {
                                FormatMaker.ShowErrorMessageBox("Error While Updating State!");
                            }

                        }
                        else
                        {

                            FormatMaker.ShowErrorMessageBox("Selected Customer Alrady in Deactive State!");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

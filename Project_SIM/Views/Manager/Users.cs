using BrightIdeasSoftware;
using MaterialSkin.Controls;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
using Project_SIM.Views.User;
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
using static Project_SIM.Models.SimCustomer;
using static Project_SIM.Models.SimProduct;
using static Project_SIM.Models.SimUser;

namespace Project_SIM.Views.Manager
{
    public partial class Users : MaterialForm
    {

        SimUser user;
        List<UserData> UserList;
        public Users()
        {
            InitializeComponent();
            user = new SimUser();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            SimUser user = new SimUser();
            UserList = user.GetUsers();
            ShowData();
        }
        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            UserList = user.GetUsers(txtSearchWord.Text.Trim());
            ShowData();
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            UserList = user.GetUsers(txtSearchWord.Text.Trim());
            ShowData();
        }

        private void chckBoxShowGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBoxShowGroups.Checked == true)
            {
                objListUsers.ShowGroups = true;
            }

            if (chckBoxShowGroups.Checked == false)
            {
                objListUsers.ShowGroups = false;
            }
        }

        private void ShowData()
        {
            // Set aspect getters for each column to display the desired details
            no.AspectGetter = (s) => (s as UserData)?.RecordId.ToString();
            username.AspectGetter = (s) => (s as UserData)?.Username.ToString();
            fullName.AspectGetter = (s) => (s as UserData)?.FullName;
            accessLevel.AspectGetter = (s) => (s as UserData)?.AccessLevel.ToString();
            accountState.AspectGetter = (s) => (s as UserData)?.AccountState;

            // Button column set up for viewing the User
            SetupButtonColumn(view, "Show", "show", "View");

            // Button column set up for activating the User
            SetupButtonColumn(activate, "Activate", "activate-user", "Activate");

            // Button column set up for deactivating the User
            SetupButtonColumn(deactivate, "Deactivate", "deactivate-user", "Deactivate");

            // Clear existing items and set new objects to the ListView
            objListUsers.Items.Clear();
            objListUsers.SetObjects(UserList);
        }

        private void SetupButtonColumn(OLVColumn column, string name, string iconName, string buttonText)
        {
            column.IsButton = true;
            column.ButtonSizing = OLVColumn.ButtonSizingMode.FixedBounds;
            column.AspectGetter = (s) => buttonText;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UserList = user.GetUsers();
            ShowData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            RegUser regUser = new RegUser();
            DialogResult result = regUser.ShowDialog();

            if (result == DialogResult.Yes)
            {
                UserList = user.GetUsers();
                ShowData();
            }

        }

        private void objListUsers_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == view)
            {
                try
                {
                    int clickedRow = e.RowIndex;  // Get the row index of the clicked button

                    Console.WriteLine($"Index of the Clicked Row: {clickedRow}");

                    if (clickedRow >= 0 && clickedRow < UserList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimUser.UserData selectedUser = e.Model as SimUser.UserData;

                        if (selectedUser != null)
                        {
                            User.UpdateDetailsForm viewForm = new User.UpdateDetailsForm();
                            viewForm.setDetails(selectedUser);
                            viewForm.Show();
                            UserList = user.GetUsers();
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

                    if (clickedRow >= 0 && clickedRow < UserList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimUser.UserData selectedUser = e.Model as SimUser.UserData;

                        if (selectedUser != null && selectedUser.AccountState != "Active")
                        {
                            bool result = user.SetState(selectedUser.UserID, true);
                            if (result)
                            {
                                MessageBox.Show("User Account State Updated As Active...!", "State Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UserList = user.GetUsers();
                                ShowData();
                            }
                            else
                            {
                                FormatMaker.ShowErrorMessageBox("Error While Updating State!");
                            }

                        }
                        else
                        {

                            FormatMaker.ShowErrorMessageBox("Selected User Alrady in Active State!");
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

                    if (clickedRow >= 0 && clickedRow < UserList.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        SimUser.UserData selectedUser = e.Model as SimUser.UserData;

                        if (selectedUser != null && selectedUser.AccountState != "Deactive")
                        {
                            bool result = user.SetState(selectedUser.UserID, false);
                            if (result)
                            {
                                MessageBox.Show("User Account State Updated As Deactive...!", "State Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UserList = user.GetUsers();
                                ShowData();
                            }
                            else
                            {
                                FormatMaker.ShowErrorMessageBox("Error While Updating State!");
                            }

                        }
                        else
                        {

                            FormatMaker.ShowErrorMessageBox("Selected User Alrady in Deactive State!");
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

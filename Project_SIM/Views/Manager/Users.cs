using BrightIdeasSoftware;
using MaterialSkin.Controls;
using Project_SIM.Models;
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
        private void objListUsers_ButtonClick(object sender, CellClickEventArgs e)
        {

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
    }
}

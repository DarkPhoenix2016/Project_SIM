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

namespace Project_SIM.Views.StoreKeeper
{
    public partial class Profile : MaterialForm
    {
        private bool detailsEdit = false;
        private bool passwordReste = false;


        SimUser SimUser;
        private SimUser.UserData userData;
        private SimUser.UserData loggedUserData;
        private UserInfo currentUser;

        public Profile()
        {
            InitializeComponent();
            SimUser = new SimUser();
        }

        public void SetSession(string SessionID)
        {
            Console.WriteLine($"Session Set on Profile:{SessionID}");
            currentUser = SessionManager.GetUserInfo(SessionID);
            loggedUserData = SimUser.Select(currentUser.Username.ToString(), currentUser.Designation.ToString());
            setDetails(loggedUserData);

        }

        public void setDetails(SimUser.UserData User)
        {
            userData = User;

            txtName.Text = User.FullName;
            txtUsername.Text = User.Username;
            txtDesignation.Text = User.AccessLevel;

            EnableDetails(false);
            EnablePassword(false);

            EnableResetPassowrd(true);
            EnableEdit(true);
            EnableSave(false);

        }

        public void EnableSave(bool enable)
        {
            btnSave.Enabled = enable;
        }
        public void EnableResetPassowrd(bool enable)
        {
            btnEditPassowrd.Enabled = enable;
        }
        public void EnableEdit(bool enable)
        {
            btnEdit.Enabled = enable;
        }
        public void EnableDetails(bool enable)
        {
            txtName.Enabled = enable;
            txtUsername.Enabled = enable;
            txtDesignation.Enabled = false;

        }
        public void EnablePassword(bool enable)
        {
            txtOldPassword.Enabled = enable;
            txtNewPassword.Enabled = enable;
            txtConfirmPassword.Enabled = enable;
        }

        private void btnEditPassowrd_Click(object sender, EventArgs e)
        {
            EnablePassword(true);
            EnableSave(true);

            EnableResetPassowrd(false);
            EnableEdit(false);
            EnableDetails(false);

            passwordReste = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDetails(true);
            EnableSave(true);

            EnableResetPassowrd(false);
            EnableEdit(false);
            EnablePassword(false);

            detailsEdit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EnableResetPassowrd(false);
            EnableEdit(false);

            EnableDetails(false);
            EnableSave(false);
            EnableDetails(false);
            EnablePassword(false);

            if (detailsEdit)
            {
                if (UpdateDetails())
                {
                    MessageBox.Show("Details Updated...!", "Detail Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EnableResetPassowrd(true);
                    EnableEdit(true);
                    detailsEdit = false;
                }
                else
                {
                    detailsEdit = true;
                    EnableEdit(true);
                    EnableSave(true);

                }
            }

            if (passwordReste)
            {
                if (UpdatePassword())
                {
                    MessageBox.Show("Password Changed Succesfull.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    EnableResetPassowrd(true);
                    EnableEdit(true);
                    passwordReste = false;
                }
                else
                {
                    passwordReste = true;
                    EnablePassword(true);
                    EnableSave(true);

                }
            }
        }

        private bool UpdatePassword()
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string oldPassword = txtOldPassword.Text;

            string hashedPassword = currentUser.PasswordHash;

            if (newPassword != confirmPassword || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(oldPassword))
            {
                FormatMaker.ShowErrorMessageBox("Every Feild need to Be filled \nNew Passwords Must Match");
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, hashedPassword))
            {
                FormatMaker.ShowErrorMessageBox("Given Current Password is incorrect");
                return false;
            }

            SimUser user = new SimUser();
            bool updateResult = user.Update(userData.UserID, newPassword);
            return updateResult;
        }


        private bool UpdateDetails()
        {
            string newName = txtName.Text;
            string newUsername = txtUsername.Text;


            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUsername) || string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newUsername))
            {
                FormatMaker.ShowErrorMessageBox("Every Feild Must to Be filled");
                return false;
            }

            SimUser user = new SimUser();
            bool updateResult = user.Update(userData.UserID, newName, newUsername);
            return updateResult;
        }

    }
}
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

namespace Project_SIM.Views.User
{
    public partial class UpdateDetailsForm : MaterialForm
    {
        private bool detailsEdit = false;
        private bool passwordReste = false;

        SimUser SimUser;
        private SimUser.UserData userData;

        public UpdateDetailsForm()
        {
            InitializeComponent();
            SimUser = new SimUser();
            SetDesignations();
        }

        private void SetDesignations()
        {

            foreach (SimUser.Designation designation in SimUser.GetDesignations())
            {
                comBoxDesignations.Items.Add(designation.Title.ToString());
            }
        }
        public void setDetails(SimUser.UserData User)
        {
            userData = User;

            txtName.Text = User.FullName;
            txtUsername.Text = User.Username;
            comBoxDesignations.Text = User.AccessLevel;

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
            comBoxDesignations.Enabled = enable;
            
        }
        public void EnablePassword(bool enable)
        {
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
                    this.Close();
                }
                else
                {
                    detailsEdit = true;
                    EnableEdit(true);
                    EnableSave(true);

                }
            }

            if(passwordReste)
            {
                if (UpdatePassword())
                {
                    MessageBox.Show("Password Changed Succesfull.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

            if (newPassword != confirmPassword || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                FormatMaker.ShowErrorMessageBox("Every Feild need to Be filled \nNew Passwords Must Match");
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
            string newAccessLevel = comBoxDesignations.Text;


            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newAccessLevel) || string.IsNullOrEmpty(newUsername)|| string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newAccessLevel) || string.IsNullOrWhiteSpace(newUsername))
            {
                FormatMaker.ShowErrorMessageBox("Every Feild Must to Be filled");
                return false;
            }

            SimUser user = new SimUser();
            bool updateResult = user.Update(userData.UserID,newName,newUsername,newAccessLevel);
            return updateResult;
        }
    }
}

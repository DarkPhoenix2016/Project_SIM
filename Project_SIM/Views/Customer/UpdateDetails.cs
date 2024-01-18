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

namespace Project_SIM.Views.Customer
{
    public partial class UpdateDetails : MaterialForm
    {
        private bool detailsEdit = false;
        private bool passwordReste = false;

        private UserInfo currentUser;
        private SimCustomer.Customer customerData;
        private Dashborad dashborad;

        public UpdateDetails()
        {
            InitializeComponent();
        }
        public void SetCurrentUser(UserInfo CurrentUser)
        {
            currentUser = CurrentUser;
        }
        public void setCustomerDetails(SimCustomer.Customer CustomerData)
        {
            customerData = CustomerData;

            txtLoyaltyNumber.Text = customerData.LoyaltyNumber;
            txtName.Text = customerData.FullName;
            txtUsername.Text = customerData.Username;
            txtDateOfJoin.Text = customerData.DateOfJoin.ToShortDateString();

        }
        public void setDashborad(Dashborad Dashborad)
        {
            dashborad= Dashborad;
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
            txtDateOfJoin.Enabled = enable;
            txtUsername.Enabled = enable;
            txtLoyaltyNumber.Enabled = enable;
            
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
                if (UpdateCustomerDetails())
                {
                    MessageBox.Show("Data Updated.Logout and Login to Validate.", "Detail Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashborad.HandleLogout(true);
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
                    MessageBox.Show("Password Changed Succesfull.Logout and Login to Validate.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashborad.HandleLogout(true);
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

            if (newPassword != confirmPassword || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword)  || string.IsNullOrEmpty(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(oldPassword))
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

            bool updateResult = user.Update(customerData.UserID, newPassword);

            return updateResult;
        }

        private bool UpdateCustomerDetails()
        {
            string newName = txtName.Text;
            string newDateofJoin = Convert.ToDateTime(txtDateOfJoin.Text).ToString("yyyy-MM-dd");
            string newUsername = txtUsername.Text;
            string newLoyaltyNumber = txtLoyaltyNumber.Text;


            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newDateofJoin) || string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newLoyaltyNumber)  || string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newDateofJoin) || string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newLoyaltyNumber))
            {
                FormatMaker.ShowErrorMessageBox("Every Feild Must to Be filled");
                return false;
            }
            SimCustomer customer = new SimCustomer();

            bool updateResult = customer.Update(customerData.UserID,customerData.CustomerID,newName,newUsername,newLoyaltyNumber,newDateofJoin);

            return updateResult;
        }
    }
}

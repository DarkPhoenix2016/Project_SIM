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

namespace Project_SIM.Views
{
    public partial class ServerSettings : MaterialForm
    {
        public ServerSettings()
        {
            InitializeComponent();
            LoadServerDetails();

            btnSave.Enabled = false;
        }

        private void LoadServerDetails()
        {
            txtServername.Text  = Properties.Settings.Default.Server;
            txtUsername.Text = Properties.Settings.Default.Uid;
            txtPassword.Text = Properties.Settings.Default.Password;
            txtDatabaseName.Text = Properties.Settings.Default.Database;
        }
        private void EnableFeild(bool enable)
        {
            txtServername.Enabled = enable;
            txtUsername.Enabled = enable;
            txtPassword.Enabled = enable;
            txtDatabaseName.Enabled = enable;

            btnSave.Enabled = enable;
            btnEdit.Enabled = !enable;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFeild(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnectionClass.SetServerDetails(txtServername.Text, txtDatabaseName.Text, txtUsername.Text, txtPassword.Text);
            MessageBox.Show("Server Details Updated!","server Details",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            this.Close();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

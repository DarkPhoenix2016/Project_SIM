using MySql.Data.MySqlClient;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
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
    public partial class OpenScreen : Form
    {
        private LogingForm logingForm;
        private bool isClosing = false;

        public OpenScreen()
        {
            InitializeComponent();
            logingForm = new LogingForm();
        }

        public void SetFormVisibility(bool isVisible)
        {
            this.Visible = isVisible;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Set the flag to indicate that the form is being closed intentionally
            isClosing = true;
            this.Close();
        }

        private void OpenScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing)
            {
                // The X button was clicked, close the entire application
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;    
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            logingForm.SetPosition(btnManager.Text);
            this.WindowState = FormWindowState.Minimized;
            DialogResult dialogResult = logingForm.ShowDialog();
            logingForm.Focus();
            if(dialogResult == DialogResult.Cancel)
            {
                this.WindowState = FormWindowState.Normal;
            }
            if (dialogResult == DialogResult.OK)
            {
                string sessionID = logingForm.sessionID;
                string validatedDesignation = logingForm.validatedDesignation;
                if (!string.IsNullOrEmpty(sessionID) && validatedDesignation == btnManager.Text)
                {
                    Manager.Dashborad dashborad = new Manager.Dashborad();
                    dashborad.SetSession(sessionID);
                    dashborad.Show();
                    isClosing = false;
                    this.Close();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Unkown Error During Login");
                } 
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            logingForm.SetPosition(btnUser.Text);
            this.WindowState = FormWindowState.Minimized;
            DialogResult dialogResult = logingForm.ShowDialog();
            logingForm.Focus();
            if (dialogResult == DialogResult.Cancel)
            {
                this.WindowState = FormWindowState.Normal;
            }
            if (dialogResult == DialogResult.OK)
            {
                string sessionID = logingForm.sessionID;
                string validatedDesignation = logingForm.validatedDesignation;
                if (!string.IsNullOrEmpty(sessionID) && validatedDesignation == btnUser.Text)
                {
                    User.Dashborad dashborad = new User.Dashborad();
                    dashborad.SetSession(sessionID);
                    dashborad.Show();
                    isClosing = false;
                    this.Close();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Unkown Error During Login");
                }
            }
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            logingForm.SetPosition(btnCustomer.Text);
            this.WindowState = FormWindowState.Minimized;
            DialogResult dialogResult = logingForm.ShowDialog();
            logingForm.Focus();
            if (dialogResult == DialogResult.Cancel)
            {
                this.WindowState = FormWindowState.Normal;
            }
            if (dialogResult == DialogResult.OK)
            {
                string sessionID = logingForm.sessionID;
                string validatedDesignation = logingForm.validatedDesignation;

                if (!string.IsNullOrEmpty(sessionID) && validatedDesignation == btnCustomer.Text)
                {
                    Dashborad dashborad = new Dashborad();
                    dashborad.SetSession(sessionID);
                    dashborad.Show();
                    isClosing = false;
                    this.Close();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Unkown Error During Login");
                }
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            logingForm.SetPosition(btnInventory.Text);
            this.WindowState = FormWindowState.Minimized;
            DialogResult dialogResult = logingForm.ShowDialog();
            logingForm.Focus();
            if (dialogResult == DialogResult.Cancel)
            {
                this.WindowState = FormWindowState.Normal;
            }
            if (dialogResult == DialogResult.OK)
            {
                string sessionID = logingForm.sessionID;
                string validatedDesignation = logingForm.validatedDesignation;
                if (!string.IsNullOrEmpty(sessionID) && validatedDesignation == btnInventory.Text)
                {
                    StoreKeeper.Dashborad dashborad = new StoreKeeper.Dashborad();
                    dashborad.SetSession(sessionID);
                    dashborad.Show();
                    isClosing = false;
                    this.Close();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Unkown Error During Login");
                }
            }
        }

        private void btnServerSettings_Click(object sender, EventArgs e)
        {
            ServerSettings serverSettings = new ServerSettings();
            serverSettings.ShowDialog();
            ValidateConncetion();
        }

        private void ValidateConncetion()
        {
            string connectionString = SqlConnectionClass.GetConnectionString();

            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    sqlConnection.Close();

                    btnCustomer.Enabled = true;
                    btnInventory.Enabled = true;
                    btnManager.Enabled = true;
                    btnUser.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                FormatMaker.ShowErrorMessageBox($"Error On New Conncetion Details\nPlease Update Conncetion details to the Server\nError Message: {ex.Message}");
                btnCustomer.Enabled = false;
                btnInventory.Enabled = false;
                btnManager.Enabled = false;
                btnUser.Enabled = false;
                btnServerSettings.Focus();

            }
        }

        private void OpenScreen_Load(object sender, EventArgs e)
        {
            ValidateConncetion();
        }
    }

}

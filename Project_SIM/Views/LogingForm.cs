﻿using MaterialSkin.Controls;
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
    
    public partial class LogingForm : MaterialForm
    {
        public string sessionID { get; set; }
        public string validatedDesignation {  get; set; }
        public LogingForm()
        {
            InitializeComponent();

            this.Activate();
            this.Focus();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();  
            string designation = lblePosition.Text.Trim();  
            Login(username, password, designation);
        }

        public void SetPosition(string Designation)
        {
            lblePosition.Text = Designation;
        }

        public void Login(string username,string passwrod,string designation)
        {
            string result= Authenticator.StartSession(username, passwrod, designation);

            if (!string.IsNullOrEmpty(result))
            {
                sessionID = result;
                validatedDesignation = designation;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            txtPassword.Text = string.Empty; 
            txtUsername.Text = string.Empty;
            
        }

        private void LogingForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            txtUsername.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            txtPassword.Text = string.Empty;
            txtUsername.Text = string.Empty;
            this.Close();
        }
    }


}

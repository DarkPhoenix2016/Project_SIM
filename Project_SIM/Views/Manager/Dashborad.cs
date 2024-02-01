using MaterialSkin.Controls;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
using Project_SIM.Views.StoreKeeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SIM.Views.Manager
{
    public partial class Dashborad : MaterialForm
    {
        private string sessionID;
        private bool isClosing = false;


        private Home home;
        private Inventory inventory;
        private Products products;
        private BillsPage bills;
        private Reports reports;
        private Users users;
        private Customers customers;
        private Profile profile;

        public Dashborad()
        {
            sessionID = string.Empty;
            InitializeComponent();
        }

        public void SetSession(string session)
        {
            sessionID = session.Trim();
            Console.WriteLine("Session Id Set  in Dashborad As "+session);
        }


        //Dashboead Loading event
        private void Dashborad_Load(object sender, EventArgs e)
        {
            home = new Home();
            home.SetSession(sessionID);
            home.FormClosed += Home_Formclosed;
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();

            CloseForm(inventory);
            CloseForm(products);
            CloseForm(bills);
            CloseForm(reports);
            CloseForm(users);
            CloseForm(customers);
            CloseForm(profile);

        }


       
        //Menu Bar Buttons
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home();
                home.SetSession(sessionID);
                home.FormClosed += Home_Formclosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();


            }
            else
            {
                home.Activate();

                CloseForm(inventory);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(customers);
                CloseForm(profile);

            }
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            User.Dashborad dashborad = new User.Dashborad();
            dashborad.SetSession(sessionID);
            dashborad.Show();
            isClosing = true;
            this.Close();
        }
        
        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (inventory == null)
            {
                inventory = new Inventory();
                inventory.FormClosed += Inventory_Formclosed;
                inventory.MdiParent = this;
                inventory.Dock = DockStyle.Fill;
                inventory.Show();
            }
            else
            {
                inventory.Activate();

                CloseForm(home);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(customers);
                CloseForm(profile);

            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (products == null)
            {
                products = new Products();
                products.FormClosed += Products_Formclosed;
                products.MdiParent = this;
                products.Dock = DockStyle.Fill;
                products.Show();
            }
            else
            {
                products.Activate();

                CloseForm(home);
                CloseForm(inventory);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(customers);
                CloseForm(profile);


            }
        }
        
        private void btnBill_Click(object sender, EventArgs e)
        {
            if (bills == null)
            {
                bills = new BillsPage();
                bills.FormClosed += Bills_Formclosed;
                bills.MdiParent = this;
                bills.Dock = DockStyle.Fill;
                bills.Show();


            }
            else
            {
                bills.Activate();
                
                CloseForm(home);
                CloseForm(inventory);
                CloseForm(products);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(customers);
                CloseForm(profile);

            }
        }
       
        private void btnReports_Click(object sender, EventArgs e)
        {
            if (reports == null)
            {
                reports = new Reports();
                reports.FormClosed += Reports_Formclosed;
                reports.MdiParent = this;
                reports.Dock = DockStyle.Fill;
                reports.Show();


            }
            else
            {
                reports.Activate();

                CloseForm(home);
                CloseForm(inventory);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(users);
                CloseForm(customers);
                CloseForm(profile);


            }
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (users == null)
            {
                users = new Users();
                users.FormClosed += Users_Formclosed;
                users.MdiParent = this;
                users.Dock = DockStyle.Fill;
                users.Show();


            }
            else
            {
                users.Activate();

                CloseForm(home);
                CloseForm(inventory);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(customers);
                CloseForm(profile);

            }
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (customers == null)
            {
                customers = new Customers();
                customers.FormClosed += Customers_Formclosed;
                customers.MdiParent = this;
                customers.Dock = DockStyle.Fill;
                customers.Show();


            }
            else
            {
                customers.Activate();

                CloseForm(home);
                CloseForm(inventory);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(profile);

            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profile == null)
            {
                profile = new Profile();
                profile.SetSession(sessionID);
                profile.FormClosed += Profile_Formclosed;
                profile.MdiParent = this;
                profile.Dock = DockStyle.Fill;
                profile.Show();


            }
            else
            {
                profile.Activate();

                CloseForm(home);
                CloseForm(inventory);
                CloseForm(products);
                CloseForm(bills);
                CloseForm(reports);
                CloseForm(users);
                CloseForm(customers);

            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Call the common method to handle session ending and application closing
            HandleLogout();
        }


        //Form Close events

        private void CloseForm(Form form)
        {
            if (form != null)
            {
                form.Close();
            }
        }
        private void Home_Formclosed(object sender, FormClosedEventArgs e)
        {
            home = null;
        }
        private void Products_Formclosed(object sender, FormClosedEventArgs e)
        {
            products = null;
        }
        private void Inventory_Formclosed(object sender, FormClosedEventArgs e)
        {
            inventory = null;
        }
        private void Bills_Formclosed(object sender, FormClosedEventArgs e)
        {
            bills = null;
        }
        private void Reports_Formclosed(object sender, FormClosedEventArgs e)
        {
            reports = null;
        }
        private void Users_Formclosed(object sender, FormClosedEventArgs e)
        {
            users = null;
        }
        private void Customers_Formclosed(object sender, FormClosedEventArgs e)
        {
           customers = null;
        }
        private void Profile_Formclosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }
        private void Dashborad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                // Handle other closing scenarios, e.g., logout button
                DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // If the user confirms logout, close the dashboard form
                    isClosing = true;
                    e.Cancel = false;
                    // The X button was clicked, close the entire application
                    Application.Exit();
                }
                else
                {
                    // If the user cancels logout, prevent the dashboard form from closing
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }


        //Logout Logic
        public void HandleLogout(bool forced = false)
        {
            if (!forced)
            {
                // Prompt the user with a yes/no question
                DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirm log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    // If the user clicks "Yes," end the session
                    SessionManager.EndSession(sessionID);

                    // Close the current form (Dashboard) and open the login screen
                    OpenScreen openScreen = new OpenScreen();
                    openScreen.Show();
                    isClosing = true;
                    this.Close();
                }
            }
            if (forced)
            {
                // If the user clicks "Yes," end the session
                SessionManager.EndSession(sessionID);

                // Close the current form (Dashboard) and open the login screen
                OpenScreen openScreen = new OpenScreen();
                openScreen.Show();
                isClosing = true;
                this.Close();


            }

        }

       
    }

    }

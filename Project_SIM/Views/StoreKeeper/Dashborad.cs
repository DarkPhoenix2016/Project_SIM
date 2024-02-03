using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Windows.Forms;

namespace Project_SIM.Views.StoreKeeper
{
    public partial class Dashborad : MaterialForm
    {
        private string sessionID;
        private bool isClosing = false;


        private Home home;
        private Products products;
        private StockTransactions stockTransactions;
        private StoreInventory storeInventory;
        private MainInventory mainInventory;
        private Reports reports;
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

            CloseForm(products);
            CloseForm(stockTransactions);
            CloseForm(storeInventory);
            CloseForm(mainInventory);
            CloseForm(reports);
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

                CloseForm(products);
                CloseForm(stockTransactions);
                CloseForm(storeInventory);
                CloseForm(mainInventory);
                CloseForm(reports);
                CloseForm(profile);

            }
        }
        private void btnProducts_Click(object sender, EventArgs e)
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
                CloseForm(stockTransactions);
                CloseForm(storeInventory);
                CloseForm(mainInventory);
                CloseForm(reports);
                CloseForm(profile);


            }
        }
        private void btnStockTrans_Click(object sender, EventArgs e)
        {
            if (stockTransactions == null)
            {
                stockTransactions = new StockTransactions();
                stockTransactions.FormClosed += StockTransactions_Formclosed;
                stockTransactions.MdiParent = this;
                stockTransactions.Dock = DockStyle.Fill;
                stockTransactions.Show();
            }
            else
            {
                stockTransactions.Activate();

                CloseForm(home);
                CloseForm(products);
                CloseForm(storeInventory);
                CloseForm(mainInventory);
                CloseForm(reports);
                CloseForm(profile);


            }
        }
        private void btnStoreInventory_Click(object sender, EventArgs e)
        {
            if (storeInventory == null)
            {
                storeInventory = new StoreInventory();
                storeInventory.FormClosed += StoreInventory_Formclosed;
                storeInventory.MdiParent = this;
                storeInventory.Dock = DockStyle.Fill;
                storeInventory.Show();
            }
            else
            {
                storeInventory.Activate();

                CloseForm(home);
                CloseForm(products);
                CloseForm(stockTransactions);
                CloseForm(mainInventory);
                CloseForm(reports);
                CloseForm(profile);


            }
        }
        private void btnMasterInventory_Click(object sender, EventArgs e)
        {
            if (mainInventory == null)
            {
                mainInventory = new MainInventory();
                mainInventory.FormClosed += MainInventory_Formclosed;
                mainInventory.MdiParent = this;
                mainInventory.Dock = DockStyle.Fill;
                mainInventory.Show();
            }
            else
            {
                mainInventory.Activate();

                CloseForm(home);
                CloseForm(products);
                CloseForm(stockTransactions);
                CloseForm(storeInventory);
                CloseForm(reports);
                CloseForm(profile);


            }
        }
        private void btnReports_Click_1(object sender, EventArgs e)
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
                CloseForm(products);
                CloseForm(stockTransactions);
                CloseForm(storeInventory);
                CloseForm(mainInventory);
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
                CloseForm(products);
                CloseForm(stockTransactions);
                CloseForm(storeInventory);
                CloseForm(mainInventory);
                CloseForm(reports);
                

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

        private void Home_Formclosed(object sender, FormClosedEventArgs e)
        {
            home = null;
        }
        private void Products_Formclosed(object sender, FormClosedEventArgs e)
        {
            products = null;
        }
        private void StockTransactions_Formclosed(object sender, FormClosedEventArgs e)
        {
            stockTransactions = null;
        }
        private void StoreInventory_Formclosed(object sender, FormClosedEventArgs e)
        {
            storeInventory = null;
        }
        private void MainInventory_Formclosed(object sender, FormClosedEventArgs e)
        {
            mainInventory = null;
        }
        private void Reports_Formclosed(object sender, FormClosedEventArgs e)
        {
            reports = null;
        }
        
        private void Profile_Formclosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
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

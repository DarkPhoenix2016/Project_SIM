﻿using Microsoft.Reporting.WinForms;
using Project_SIM.Views.Customer;
using Project_SIM.Views.ReportView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SIM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Views.OpenScreen startScreen = new Views.OpenScreen();
            startScreen.Show();
            Application.Run(); ;
        }
    }
}

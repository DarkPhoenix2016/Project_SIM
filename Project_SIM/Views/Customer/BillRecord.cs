using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class BillRecord : MaterialForm
    {
        public string createdBillNumber { get; set; }
        public int createdtransactionID { get; set; }

        public BillRecord()
        {
            InitializeComponent();
            
        }
        private void BillRecord_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            
            SimStore simStore = new SimStore();
            SimBill simBill = new SimBill();

            var salesData = simBill.GetFullBill(createdBillNumber, Convert.ToInt32(createdtransactionID));

            List<StoreDetails> storeDetails = new List<StoreDetails>();
            StoreDetails storeData = simStore.GetFirstStore();
            storeDetails.Add(storeData);

            List<SalesTransaction> salesTransactions = new List<SalesTransaction>();
            SalesTransaction transactionRecord = salesData.Item1;
            salesTransactions.Add(transactionRecord);

            List<SalesTransactionDetails> transactionData = salesData.Item2;

            List<Payments> paymentData = salesData.Item3;
            
            List<LoyaltyTransaction> loyaltyTransactions = salesData.Item4;


            DataTable storeDatatable = FormatMaker.ConvertListToDataTable(storeDetails);
            DataTable transactionDatatable = FormatMaker.ConvertListToDataTable(salesTransactions);
            DataTable tranactionDetailsDatatable = FormatMaker.ConvertListToDataTable(transactionData);
            DataTable paymentDatatable = FormatMaker.ConvertListToDataTable(paymentData);
            DataTable loyaltyDatatable = FormatMaker.ConvertListToDataTable(loyaltyTransactions);

            var storeDataSource = new ReportDataSource("DataSetStoreDataSet", storeDatatable);
            var salesDataSource = new ReportDataSource("SaleTransaction", transactionDatatable);
            var salesDetailDataSource = new ReportDataSource("SaleTransactionDetails", tranactionDetailsDatatable);
            var paymentsDetailDataSource = new ReportDataSource("Payments", paymentDatatable);
            var loyaltyDataSource = new ReportDataSource("Loyalty", loyaltyDatatable);

            reportViewer1.LocalReport.DataSources.Add(storeDataSource);
            reportViewer1.LocalReport.DataSources.Add(salesDataSource);
            reportViewer1.LocalReport.DataSources.Add(salesDetailDataSource);
            reportViewer1.LocalReport.DataSources.Add(paymentsDetailDataSource);
            reportViewer1.LocalReport.DataSources.Add(loyaltyDataSource);

            reportViewer1.RefreshReport();
        }

        



    }
}

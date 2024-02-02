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

namespace Project_SIM.Views.ReportView
{
    public partial class BillTransactions : MaterialForm
    {
        private SimBill billClass;
        private SimStore simStore ;
        private List<PaymentMethod> paymentMethods;
        List<TransactionsReport> recordsList;

        public BillTransactions()
        {
            InitializeComponent();

            billClass = new SimBill();
            simStore = new SimStore();
            recordsList = new List<TransactionsReport>();
            paymentMethods = billClass.GetPaymentMethods();

        }

        private void BillRecord_Load(object sender, EventArgs e)
        {
            SetPaymentMethods();

            // Set the maximum dates for dateFrom and dateTo controls
            dateFrom.MaxDate = DateTime.Now.AddHours(1);
            dateTo.MaxDate = DateTime.Now.AddHours(1);

            // Set default values for dateFrom and dateTo controls
            dateFrom.Value = DateTime.Now.AddHours(-1);
            dateTo.Value = DateTime.Now.AddHours(-1);

            // Set default values for payment method type
            comBoxPayMethods.SelectedItem = "All Payment Method";

            LoadData();
        }


        private void LoadData()
        {
            string selectedType;

            Console.WriteLine(comBoxPayMethods.SelectedItem.ToString());

            if (string.IsNullOrEmpty(comBoxPayMethods.SelectedItem.ToString())|| comBoxPayMethods.SelectedItem.ToString() == "All Payment Method")
            {
                selectedType = "%";
            }
            else
            {
                selectedType = comBoxPayMethods.SelectedItem.ToString().Trim();
            }

            List<StoreDetails> storeDetails = new List<StoreDetails>();
            StoreDetails storeData = simStore.GetFirstStore();
            storeDetails.Add(storeData);
            
            recordsList = billClass.GetTransactionsReport(dateFrom.Value, dateTo.Value, selectedType);

            DataTable storeDatatable = FormatMaker.ConvertListToDataTable(storeDetails);
            DataTable recordDatatable = FormatMaker.ConvertListToDataTable(recordsList);

            var storeDataSource = new ReportDataSource("DataSetStoreDataSet", storeDatatable);
            var recordDataSource = new ReportDataSource("trasactionReport", recordDatatable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(storeDataSource);
            reportViewer1.LocalReport.DataSources.Add(recordDataSource);


            //Parameters

            if (selectedType == "%" )
            {
                selectedType = "All Payment Method";
            }

            ReportParameter[] rptParam = new ReportParameter[]
            {
                new ReportParameter("fromDate",dateFrom.Value.ToShortDateString()),
                new ReportParameter("toDate", dateTo.Value.ToShortDateString()),
                new ReportParameter("filterdPayMethod", selectedType)

            };
            reportViewer1.LocalReport.SetParameters(rptParam);


            reportViewer1.RefreshReport();

        }

        private void SetPaymentMethods()
        {
            comBoxPayMethods.Items.Add("All Payment Method");

            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                comBoxPayMethods.Items.Add(paymentMethod.Name.ToString());
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

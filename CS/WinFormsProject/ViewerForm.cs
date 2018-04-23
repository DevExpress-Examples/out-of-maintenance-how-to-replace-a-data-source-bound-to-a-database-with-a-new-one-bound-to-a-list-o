using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DashboardWin;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;

namespace WinFormsProject
{
    public partial class ViewerForm : DevExpress.XtraEditors.XtraForm
    {
        public ViewerForm()
        {
            InitializeComponent();
        }
        public ViewerForm(string fileName) : this()
        {
            dashboardViewer1.LoadDashboard(fileName);
        }

        string nwindFileName = @"../../../nwind.mdb";
        private void dashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DataAccess.ConfigureDataConnectionEventArgs e)
        {
            switch (e.ConnectionName)
            {
                case "nwindConnection":
                    Access97ConnectionParameters access = e.ConnectionParameters as Access97ConnectionParameters;
                    if (access != null)
                        access.FileName = nwindFileName;
                    break;
            }
        }

        private void dashboardViewer1_DashboardLoaded(object sender, EventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;
            UpdateDashboard(viewer.Dashboard);           
        }       

        private void UpdateDashboard(Dashboard dashboard)
        {
            dashboard.DataSources.Clear();
            DataSource invoiceDataSource = new DataSource("RuntimeInvoices");
            dashboard.DataSources.Add(invoiceDataSource);
            foreach (var item in dashboard.Items.Where(i => i as DataDashboardItem != null).Cast<DataDashboardItem>())
            {
                item.DataSource = invoiceDataSource;
            }
        }

        private void dashboardViewer1_DataLoading(object sender, DevExpress.DataAccess.DataLoadingEventArgs e)
        {
            if (e.DataSourceName == "RuntimeInvoices")
                e.Data = NwindDataAdapter.NwindHelper.GetInvoices(nwindFileName);                         
        }


     
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DashboardCommon;

namespace AspProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            switch (e.ConnectionName)
            {
                case "nwindConnection":
                    Access97ConnectionParameters access = e.ConnectionParameters as Access97ConnectionParameters;
                    if (access != null)
                        access.FileName = Server.MapPath( @"~/App_Data/nwind.mdb");
                    break;                
            }
        }

        protected void ASPxDashboardViewer1_DashboardLoaded(object sender, DevExpress.DashboardWeb.DashboardLoadedWebEventArgs e)
        {
            e.Dashboard.DataSources.Clear();
            DataSource invoiceDataSource = new DataSource("RuntimeInvoices");
            e.Dashboard.DataSources.Add( invoiceDataSource );
            foreach (var item in e.Dashboard.Items.Where( i  => i as DataDashboardItem != null).Cast<DataDashboardItem>())
            {
                item.DataSource = invoiceDataSource;
            }
        }

        protected void ASPxDashboardViewer1_DataLoading(object sender, DevExpress.DashboardWeb.DataLoadingWebEventArgs e)
        {
            if (e.DataSourceName == "RuntimeInvoices")
                e.Data = NwindDataAdapter.NwindHelper.GetInvoices(Server.MapPath("~/App_Data/nwind.mdb"));
        }
    }
}
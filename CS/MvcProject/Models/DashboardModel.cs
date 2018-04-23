using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DashboardWeb.Mvc;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DashboardCommon;

namespace MvcProject.Models
{
    static class DashboardViewerModels
    {
        
        public static DevExpress.DashboardWeb.Mvc.DashboardSourceModel Model
        {
            get
            {
                return new DashboardSourceModel()
                {
                    ConfigureDataConnection = (sender, e) => {
                        switch (e.ConnectionName)
                        {
                            case "nwindConnection":
                                Access97ConnectionParameters access = e.ConnectionParameters as Access97ConnectionParameters;
                                if (access != null)
                                    access.FileName = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/nwind.mdb");
                                break;                          
                        }
                    },
                    DashboardLoaded = (sender, e) => {
                        e.Dashboard.DataSources.Clear();
                        DataSource invoiceDataSource = new DataSource("RuntimeInvoices");
                        e.Dashboard.DataSources.Add(invoiceDataSource);
                        foreach (var item in e.Dashboard.Items.Where(i => i as DataDashboardItem != null).Cast<DataDashboardItem>())
                        {
                            item.DataSource = invoiceDataSource;
                        }
                    },
                    DataLoading = (sender, e) => {
                        if (e.DataSourceName == "RuntimeInvoices")
                            e.Data = NwindDataAdapter.NwindHelper.GetInvoices(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/nwind.mdb") );                         
                    },
                    DashboardSource = "Dashboards//Invoices.xml"
                };
            }
        }




    }
}

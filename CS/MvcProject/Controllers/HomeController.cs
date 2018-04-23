using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial()
        {
            return PartialView("_DashboardViewerPartial", DashboardViewerSettings.Model);
        }
        public FileStreamResult DashboardViewerPartialExport()
        {
            return DevExpress.DashboardWeb.Mvc.DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model);
        }
    }
    class DashboardViewerSettings
    {
        public static DevExpress.DashboardWeb.Mvc.DashboardSourceModel Model
        {
            get
            {
                return MvcProject.Models.DashboardViewerModels.Model;
            }
        }
    }

}
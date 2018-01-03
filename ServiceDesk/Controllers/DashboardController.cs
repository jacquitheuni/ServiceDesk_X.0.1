using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult Agent()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }
    }
}
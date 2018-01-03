using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class PurchaseController : Controller
    {
        ApplicationDbContext context;
        public PurchaseController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StockList()
        {

            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}
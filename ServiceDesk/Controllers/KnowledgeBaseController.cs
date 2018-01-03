using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        ApplicationDbContext context;

        public KnowledgeBaseController()
        {
            context = new ApplicationDbContext();
        }
        // GET: KnowledgeBase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WikiCreate()
        {
            return View();
        }
    }
}
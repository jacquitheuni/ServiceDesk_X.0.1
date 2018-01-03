using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceDesk.Models;

namespace ServiceDesk.Controllers
{
    public class AgentController : Controller
    {
        ApplicationDbContext context;
        public AgentController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }
    }
}
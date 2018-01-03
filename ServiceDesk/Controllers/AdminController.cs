using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;

        public AdminController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BusinessUnit()
        {
            return View();
        }

        public ActionResult BUEdit(string id)
        {
            return View("BusinessUnit");
        }

        public ActionResult BURemove(string id)
        {
            return View("BusinessUnit");
        }

        [HttpGet]
        public ActionResult BUCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BUCreate(BusinessUnitEditorModel model)
        {
            if (model != null)
            {
                //Build in duplicate check (Department Name)
                var department = new BusinessUnit() { Name = model.Name };
                context.BusinessUnit.Add(department);

                var BUid = context.BusinessUnit.Where(x => x.Name == model.Name).Select(x => x.BusinessUnitId).FirstOrDefault();

                var access = new BusinessUnitAccess() { BusinessUnitId = BUid, RoleId = model.RoleId  };
                context.BusinessUnitAccess.Add(access);

                var managers = new BusinessUnitManagement() { BusinessUnitId = BUid, TeamLeader = model.TeamLeader, GeneralManager = model.GeneralManager, HOD = model.HOD }; // 
                context.BusinessUnitManagement.Add(managers);

                context.SaveChanges();
                return View(ViewBag.message("Successfully Submitted Department :" + model.Name));

                //If duplicate send duplicate message back
            }
            else
            {
                return View(ViewBag.message("Unable to submit department, please review and ensure all data is filled in."));
            }
        }

    }
}
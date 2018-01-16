using Microsoft.AspNet.Identity.EntityFramework;
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

        public List<BusinessUnitEditorModel> GetDepartmentList()
        {
            var model = from bu in context.BusinessUnit
                        join bum in context.BusinessUnitManagement on bu.BusinessUnitId equals bum.BusinessUnitId
                        join bua in context.BusinessUnitAccess on bu.BusinessUnitId equals bua.BusinessUnitId
                        select new BusinessUnitEditorModel()
                        {
                            BusinessUnitId = bu.BusinessUnitId,
                            isActive = bu.isActive,
                            Name = bu.Name,
                            RoleId = bua.RoleId,
                            GeneralManager = bum.GeneralManager,
                            HOD = bum.HOD,
                            TeamLeader = bum.TeamLeader
                        };
            return model.Distinct().OrderBy(x => x.isActive).ThenBy(x => x.Name).ToList();
        }
        public ActionResult BusinessUnit()
        {
            return View(GetDepartmentList());
        }

        public ActionResult DepartmentEdit(string id)
        {
            return View("BusinessUnit");
        }

        public ActionResult DepartmentRemove(string id)
        {
            return View("BusinessUnit");
        }
        public IEnumerable<SelectListItem> GetRoleList()
        {
            return context.Group.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
        }
        [HttpGet]
        public ActionResult Departments()
        {
            var model = new BusinessUnitEditorModel() { RoleItems = GetRoleList() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Departments(BusinessUnitEditorModel model)
        {
            if (ModelState.IsValid)
            {
                //Build in duplicate check (Department Name)
                var department = new BusinessUnit() { Name = model.Name };
                context.BusinessUnit.Add(department);
                context.SaveChanges();

                var BUid = context.BusinessUnit.Where(x => x.Name == model.Name).Select(x => x.BusinessUnitId).FirstOrDefault();

                var access = new BusinessUnitAccess() { BusinessUnitId = BUid, RoleId = model.RoleId  };
                context.BusinessUnitAccess.Add(access);

                var managers = new BusinessUnitManagement() { BusinessUnitId = BUid, TeamLeader = model.TeamLeader, GeneralManager = model.GeneralManager, HOD = model.HOD }; // 
                context.BusinessUnitManagement.Add(managers);

                context.SaveChanges();
                //return View(ViewBag.message("Successfully Submitted Department :" + model.Name));
                var newmodel = new BusinessUnitEditorModel() { RoleItems = GetRoleList() };
                return View(newmodel);

                //If duplicate send duplicate message back
            }
            else
            {
                //return View(ViewBag.message("Unable to submit department, please review and ensure all data is filled in."));
                return View();
            }
        }

    }
}
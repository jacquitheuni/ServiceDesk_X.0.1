using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static ServiceDesk.Models.ApplicationDbContext;

namespace ServiceDesk.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize(Roles = "Admin, Agent, Manager")]
        [AllowAnonymous]
        // GET: Group
        public ActionResult Index()
        {
            return View(db.Group.ToList());
        }

        //[Authorize(Roles = "Admin, Agent, Manager")]
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }
        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Group.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Group.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Group.Find(id);
            var idManager = new IdentityManager();
            idManager.DeleteGroup(id);
            return RedirectToAction("Index");
        }


        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        public ActionResult GroupRoles(int id)
        {
            var group = db.Group.Find(id);
            var model = new SelectGroupRolesViewModel(group);
            return View(model);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin, Agent")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GroupRoles(SelectGroupRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idManager = new IdentityManager();
                var Db = new ApplicationDbContext();
                var group = Db.Group.Find(model.GroupId);
                idManager.ClearGroupRoles(model.GroupId);
                // Add each selected role to this group:
                foreach (var role in model.Roles)
                {
                    if (role.Selected)
                    {
                        idManager.AddRoleToGroup(group.Id, role.RoleName);
                    }
                }
                return RedirectToAction("index");
            }
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
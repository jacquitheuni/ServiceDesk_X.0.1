using ServiceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Controllers
{
    public class RequestController : Controller
    {
        ApplicationDbContext context;

        public RequestController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
        public ActionResult CallRequestCreate()
        {
            return View(new CallRequest());
        }
        [HttpPost]
        public ActionResult CallRequestCreate(Request request)
        {
            //context.Request.Add(request);
            //context.RequestLink.Add(new RequestLink() { Request = request, RequestID = request.RequestID });
            //context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View(new RequestViewModel());
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            context.Request.Add(request);
            context.RequestLink.Add(new RequestLink() { Request = request, RequestID = request.RequestID });
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ticket()
        {
            return View(new Request());
        }

        public ActionResult Details()
        {
            return View(new Request());
        }

        public ActionResult EmployeeSearch()
        {
            var employees = context.Employee.ToList();
            return View(employees);
        }

        public ActionResult EmployeeEdit()
        {
            return View(new EmployeeEditorViewModel() { });
        }

        public ActionResult EmployeeCreate()
        {
            return View(new EmployeeEditorViewModel() { });
        }
        [HttpPost]
        public ActionResult EmployeeCreate(EmployeeEditorViewModel model)
        {
            var request = new Request() { Subject = "New Employee - " + model.FirstName + model.Surname, Requester = model.EditedBy, Category = Categories.Employee, Subcategory = "Employee Creation", Status = Status.AwaitingApproval };
            context.Request.Add(request);


            var employee = new Employee()
            {
                EmployeeId = model.EmployeeId,
                FirstName = model.FirstName,
                PreferredName = model.PreferredName,
                Surname = model.Surname,
                Division = model.BusinessDivision,
                Department = model.Department,
                Gender = model.Gender,
                kingdomName = model.kingdomName,
                ReportingManager = model.ReportingManager,
                ShadowUser = model.ShadowUser,
                BusinessUnitId = model.BusinessUnitId
            };
            context.Employee.Add(employee);

            var employeerequest = new EmployeeRequest() { };
            context.EmployeeRequest.Add(employeerequest);

            context.SaveChanges();
            return View(new EmployeeEditorViewModel() { });
        }

        [HttpPost]
        public ActionResult EmployeeEdit(EmployeeEditorViewModel model)
        {
            var request = new Request() { Subject = "Employee Edit - " + model.FirstName + model.Surname, Requester = model.EditedBy, Category = Categories.Employee, Subcategory = "Employee Transfer", Status = Status.AwaitingApproval };
            context.Request.Add(request);


            var employee = new Employee() { EmployeeId = model.EmployeeId, FirstName = model.FirstName, PreferredName = model.PreferredName, Surname = model.Surname,
            Division = model.BusinessDivision, Department = model.Department, Gender = model.Gender, kingdomName = model.kingdomName, ReportingManager = model.ReportingManager,
            ShadowUser = model.ShadowUser, BusinessUnitId = model.BusinessUnitId};
            context.Employee.Add(employee);

            var employeerequest = new EmployeeRequest() { };
            context.EmployeeRequest.Add(employeerequest);

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
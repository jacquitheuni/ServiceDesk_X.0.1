using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Models
{
    public enum BusinessDivision
    {
        DirectPersonal, Brokers, BusinessInsurance, CommunityInsurance
    }


    public enum Gender
    {
        Male, Female
    }
    
    public class EmployeeEditorViewModel
        {
        public EmployeeEditorViewModel() { }

        public EmployeeEditorViewModel(Employee user, EmployeeRequest request)
        {
            this.FirstName = user.FirstName;
            this.PreferredName = user.PreferredName;
            this.Surname = user.Surname;
            this.BusinessDivision = user.Division;
            this.Department = user.Department;
            this.ReportingManager = user.ReportingManager;
            this.kingdomName = user.kingdomName;
            this.ShadowUser = user.ShadowUser;
            this.Gender = user.Gender;
            this.EffectiveDate = request.EffectiveDate;
            this.BusinessUnitId = user.BusinessUnitId;
        }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Division")]
        public BusinessDivision BusinessDivision { get; set; }
        public IEnumerable<SelectListItem> BusinessUnitOptions { get; set; }
        [Display(Name ="Department")]
        [Required]
        public int BusinessUnitId { get; set; }
        [Required]
        [Display(Name = "Reporting Manager")]
        public string ReportingManager { get; set; }
        [Required]
        [Display(Name = "kingdom name")]
        public string kingdomName { get; set; }
        [Required]
        [Display(Name = "Shadow user")]
        public string ShadowUser { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Required]
        [Display(Name ="Effective Date")]
        public DateTime EffectiveDate { get; set; }
        public string EditedBy { get; set; }
        [Display(Name ="Manager")]
        public bool isManager { get; set; }

        public virtual BusinessUnit Department { get; set; }
    }
public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }
        [Display(Name = "Division")]
        public BusinessDivision Division { get; set; }
        [Required]
        [Display(Name = "Business Unit")]
        public int BusinessUnitId { get; set; }
        [Required]
        [Display(Name = "Reporting Manager")]
        public string ReportingManager { get; set; }
        [Required]
        [Display(Name = "kingdom name")]
        public string kingdomName { get; set; }
        [Required]
        [Display(Name = "Shadow user")]
        public string ShadowUser { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Is Active?")]
        public bool isActive { get; set; }
        public bool isManager { get; set; }

        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
        public virtual BusinessUnit Department { get; set; }
    }

    public class EmployeeRequest
    {
        public int EmployeeRequestId { get; set; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
        public DateTime EffectiveDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}
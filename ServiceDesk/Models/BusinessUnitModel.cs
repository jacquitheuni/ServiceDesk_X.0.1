using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceDesk.Models
{
    public class BusinessUnitEditorModel
    {

        public int BusinessUnitId { get; set; }
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Display(Name = "Team Leader")]
        public string TeamLeader { get; set; }
        [Display(Name = "General Manager")]
        public string GeneralManager { get; set; }
        [Display(Name = "Head of Department")]
        public string HOD { get; set; }
        [Display(Name = "Default Access Role Group")]
        public string RoleId { get; set; }
        //private readonly List<IdentityRole> _roleOptions;
        public IEnumerable<SelectListItem> RoleItems { get; set; }
        public bool isActive { get; set; }

    }
    public class BusinessUnit
    {
        [Key]
        public int BusinessUnitId { get; set; }
        public string Name { get; set; }
        public bool isActive {get;set;}

        public virtual ICollection<BusinessUnitManagement> BusinessUnitManagements { get; set; }
        public virtual ICollection<BusinessUnitAccess> BusinessUnitAccess { get; set; }
    }

    public class BusinessUnitManagement
    {
        [Key]
         public int BusinessUnitManagementiD { get; set; }
         public int BusinessUnitId { get; set; }
         public string TeamLeader { get; set; }
         public string GeneralManager { get; set; }
         public string HOD { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }
    }

    public class BusinessUnitAccess
    {
        public int BusinessUnitAccessId { get; set; }
        public int BusinessUnitId { get; set; }
        public string RoleId { get; set; }

        //public virtual ICollection<ApplicationUserRole> UserRole { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
    }
}
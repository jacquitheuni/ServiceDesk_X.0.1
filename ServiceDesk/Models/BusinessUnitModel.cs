using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public int RoleId { get; set; }
        [Display(Name = "Default Access Role")]
        public string RoleName { get; set; }

        public IEnumerable<ApplicationUserRole> RoleOptions { get; set; }
    }
    public class BusinessUnit
    {
        [Key]
        public int BusinessUnitId { get; set; }
        public string Name { get; set; }
        //public BusinessUnitManagement Manager { get; set; }

        //public virtual Employee Employee { get; set; }
        //public virtual BusinessUnitManagement Management { get; set; }
        //public virtual BusinessUnitAccess Access { get; set; }
    }

    public class BusinessUnitManagement
    {
        [Key]
         public int BusinessUnitManagementiD { get; set; }
         public int BusinessUnitId { get; set; }
         public string TeamLeader { get; set; }
         public string GeneralManager { get; set; }
         public string HOD { get; set; }

        public virtual ICollection<BusinessUnit> BusinessUnit { get; set; }
    }

    public class BusinessUnitAccess
    {
        public int BusinessUnitAccessId { get; set; }
        public int BusinessUnitId { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRole { get; set; }
        public virtual ICollection<BusinessUnit> BusinessUnit { get; set; }
    }
}
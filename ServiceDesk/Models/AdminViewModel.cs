using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public enum Weekdays
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public class AdminViewModel
    {
    }

    public class AgentDepartment
    {
        [Key]
        public int AgentDepartmentId { get; set; }
        [Required]
        [Display(Name="Department Name")]
        public string Name { get; set; }
        [Display(Name="Active")]
        public bool Active { get; set; }
    }

    public class BusinessHours
    {
        [Key]
        public int BusinessHoursId { get; set; }
        [Required]
        public string AgentDepartmentId { get; set; }
        [Required]
        [Display(Name ="Day of week")]
        public Weekdays Day { get; set; }
        [Required]
        [Display(Name ="Start Time")]
        public string StartTime { get; set; }
        [Required]
        [Display(Name ="End Time")]
        public string EndTime { get; set; }
    }
    public class ServiceLevelAgreement
    {

    }
}
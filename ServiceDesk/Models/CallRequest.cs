using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public enum CallType
    {
        Sales, ClientCare, Claims, Retentions
    }

    public enum RiskType
    {
        Car, HouseholdContents, Building, Trailer, Caravan, PortablePossessions
    }

    public enum CallPart
    {
        Underwriting, RegularDriver, NCB, TrackingDevice
    }
    public class CallRequest
    {
        [Key]
        public int CallRequestId { get; set; }
        public int RequestId { get; set; }
        [Required]
        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name ="Contact Number 1")]
        public string ClientContact1 {get;set;}
        [Display(Name = "Contact Number 2")]
        public string ClientContact2 { get; set; }
        [Display(Name = "Contact Number 3")]
        public string ClientContact3 { get; set; }
        [Required]
        [Display(Name = "Consultant")]
        public string Consultant { get; set; }
        [Required]
        [Display(Name = "Call Date")]
        public string CallDate { get; set; }
        [Required]
        [Display(Name = "Call Type")]
        public CallType CallType { get; set; }
        [Display(Name ="Risk Type")]
        public RiskType RiskType { get; set; }
        [Display(Name ="Risk Description")]
        public string RiskDescription { get; set; }
        [Display(Name ="Part of Call")]
        public CallPart CallPart { get; set; }
        public string Description { get; set; }

        public virtual Request Request { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public enum Categories
    {
        Hardware, Network, General, Employee, Applications, Ratings
    }
    public enum Subcategories
    {
        CallRequest, Obelix, Desktop, NewUser, RemoveUser
    }
    public enum Status
    {
        Open, Escalated, Closed, Resolved, OnHold, Ordered, AwaitingApproval
    }
    public class RequestViewModel
    {
        [Key]
        [Display(Name="Ticket Number")]
        public int RequestID { get; set; }
        [Display(Name ="Status")]
        public Status Status { get; set; }
        [Required]
        [Display(Name ="Request Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name ="Category")]
        public Categories Category { get; set; }
        [Display(Name ="Sub-Category")]
        public string Subcategory { get; set; }
        [Display(Name ="Assigned To")]
        public string AssignedTo { get; set; }
        [Display(Name ="Requester")]
        public string Requester { get; set; }
        public int RequestLinkID { get; set; }
    }
}
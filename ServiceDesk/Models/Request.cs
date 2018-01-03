using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int RequestLinkID { get; set; }
        public Status Status { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Categories Category { get; set; }
        public string Subcategory { get; set; }
        public string AssignedTo { get; set; }
        public string Requester { get; set; }

        public bool Escalated { get; set; }

        public virtual ICollection<RequestLink> RequestLinks { get; set; }
        public virtual ICollection<Remarks> Remarks { get; set; }
        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
        public virtual ICollection<CallRequest> CallRequest { get; set; }
    }

    public class RequestLink
    {
        public int RequestLinkID { get; set; }
        public int RequestID { get; set; }
        public int LinkID { get; set; }

        public virtual Request Request { get; set; }
    }

    public class Remarks
    {
        [Key]
        public int RemarkId { get; set; }
        public int RequestId { get; set; }
        [Required]
        public string RemarkBy { get; set; }
        [Required]
        public DateTime RemarkDate { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual Request Request { get; set; }
    }
}
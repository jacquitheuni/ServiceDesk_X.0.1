using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public class WikiCategory
    {
        [Key]
        public int WikiCategoryId { get; set; }
        [Required]
        [Display(Name="Category")]
        public string Name { get; set; }
        public int WikiSubCategoryId { get; set; }

        public virtual ICollection<WikiDetail> Detail { get; set; }
    }
    public class WikiDetail
    {
        [Key]
        public int WikiDetailId { get; set; }
        [Required]
        public int WikiCategoryId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int WikiCategoryName { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }

        public virtual ICollection<WikiAttachment> Attachments { get; set; }
        public virtual WikiCategory Category { get; set; }
    }
    public class WikiAttachment
    {
        [Key]
        public int WikiAttachmentId { get; set; }
        public int WikiDetailId { get; set; }

        public virtual WikiDetail Detail { get; set; }
    }
}
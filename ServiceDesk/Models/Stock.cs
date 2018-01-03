using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceDesk.Models
{
    public enum StockType
    {
        Hardware, Software
    }
    public enum StockCategories
    {
        Desktop, Laptop, Terminal, Server, Keyboard, Mouse, Screen, Headset, Phone, Bags, Plugs
    }
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        [Display(Name ="Stock Type")]
        public StockType Type { get; set; }
        [Required]
        [Display(Name = "Category")]
        public StockCategories Category { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name ="Min. Threshold")]
        public int Threshold { get; set; }
    }
}
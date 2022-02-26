using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITRoot.ViewModels
{
    public class InvoiceViewModel
    {
        [Display(Name = "Invoice Id")]
        public int Id { get; set; }
 
        public string Product { get; set; }

        [Display(Name = "Total Items")]
        public int TotalItems { get; set; }

         [Display(Name = "Total Price")]
        public float TotalPrice { get; set; }
        
    }
}
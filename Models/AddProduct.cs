using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITRoot.Models;

namespace ITRoot.Models
{
    public class AddProduct
    {
            
            
        public string Product { get; set; }   
         public int? InvoiceId { get; set; }
    }
}
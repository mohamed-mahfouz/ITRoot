using System;
using System.Collections.Generic;

namespace ITRoot.Models
{
    public class InvoiceProduct 
    {
        public int InvoiceId { get; set; }
         public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }

       
    }
}
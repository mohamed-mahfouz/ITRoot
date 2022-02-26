using System;
using System.Collections.Generic;

namespace ITRoot.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public float Price { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public List<InvoiceProduct> InvoiceProducts { get; set; }
        
    }
}
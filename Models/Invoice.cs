using System;
using System.Collections.Generic;

namespace ITRoot.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}
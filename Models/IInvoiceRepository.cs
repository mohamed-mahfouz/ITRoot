using System;
using System.Collections.Generic;
using ITRoot.ViewModels;

namespace ITRoot.Models
{
    public interface IInvoiceRepository
    {
        void Add(AddProduct invoice);
        IEnumerable<InvoiceViewModel> GetAll();
        List<Product> GetProducts();
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using ITRoot.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ITRoot.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(AddProduct products)
        {
                
            var newInvoice = new Invoice();
            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();
            
            var invoiceProduct = new InvoiceProduct{ ProductId = 1,InvoiceId = _dbContext.Invoices.OrderByDescending( i =>i.Id).LastOrDefault().Id};
            _dbContext.InvoiceProduct.Add(invoiceProduct);
            _dbContext.SaveChanges();
        }

        public IEnumerable<InvoiceViewModel> GetAll()
        {
             var invoices = _dbContext.InvoiceProduct.Include(p=>p.product).ToList();
             var result = new List<InvoiceViewModel>();
              
             foreach(var invoice in invoices)
             {
                 
                  var invoiceViewModel =  new InvoiceViewModel
                     {
                        Id = invoice.InvoiceId,
                        Product = invoice.product.Name,
                        TotalItems = _dbContext.InvoiceProduct
                                      .Where(p =>p.InvoiceId == invoice.InvoiceId).GroupBy(p =>p.ProductId).Count(),

                        TotalPrice = _dbContext.InvoiceProduct
                                      .Where(p =>p.InvoiceId == invoice.InvoiceId).Sum(p =>p.product.Price)
                                    
                     };
              
                              
                    result.Add(invoiceViewModel);    
             }

    
          return result;
        }

        public List<Product> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }
    }
}
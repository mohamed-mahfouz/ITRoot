using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITRoot.Models;
using ITRoot.ViewModels;

namespace ITRoot.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(ApplicationDbContext dbContext, IInvoiceRepository invoiceRepository)
        {
            this._dbContext = dbContext;
            this._invoiceRepository = invoiceRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id){

            return View(new AddProduct());
        }

        [HttpPost]
        public IActionResult AddOrEdit(){
            
             return View();
        }

        //Json for datatables plugin
        [HttpPost]
         public IActionResult GetInvoices()
        {
            var invoices = _invoiceRepository.GetAll();
            var recordsTotal = invoices.Count();
            
            return Ok(new {data = invoices});
        }


        //for autocomplete
        
         public IActionResult GetProducts(string term)
        {
            var products = _invoiceRepository.GetProducts();
            
            var result = (from P in products 
                           where P.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase)
                           select new {value = P.Name} );

            return Json(result);
         
        }
        
    }
}

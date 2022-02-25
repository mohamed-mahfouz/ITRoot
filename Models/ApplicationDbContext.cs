using System;
using Microsoft.EntityFrameworkCore;

namespace ITRoot.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
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
        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasMany(p =>p.Invoices)
                                          .WithMany( i => i.Products)
                                          .UsingEntity<InvoiceProduct>(
                                                 j=>
                                                   j.HasOne(ip => ip.Invoice)
                                                    .WithMany(i =>i.InvoiceProducts)
                                                    .HasForeignKey(ip => ip.InvoiceId),
                                                 j=>
                                                    j.HasOne(ip => ip.product)
                                                    .WithMany(p=>p.InvoiceProducts)
                                                    .HasForeignKey(ip => ip.ProductId),
                                                    j=>j.HasKey( k => new {k.ProductId , k.InvoiceId})
                                          );


            modelBuilder.Entity<Product>().HasData(
                new Product{Id=1,Name="Pontiac",Price=48.59f},
                new Product{Id=2,Name="Buick",Price=60.04f},
                new Product{Id=3,Name="Nissan",Price=15.64f},
                new Product{Id=4,Name="Chrysler",Price=30.23f},
                new Product{Id=5,Name="Chevrolet",Price=21.66f},
                new Product{Id=6,Name="Volkswagen",Price=66.2f},
                new Product{Id=7,Name="Chevrolet",Price=24.99f},
                new Product{Id=8,Name="Mercury",Price=99.25f},
                new Product{Id=9,Name="Dodge",Price=13.13f},
                new Product{Id=10,Name="Mercedes-Benz",Price=88.23f},
                new Product{Id=11,Name="Mazda",Price=8.38f},
                new Product{Id=12,Name="Chevrolet",Price=24.68f},
                new Product{Id=13,Name="Acura",Price=10.19f},
                new Product{Id=14,Name="GMC",Price=89.59f},
                new Product{Id=15,Name="Ford",Price=90.14f},
                new Product{Id=16,Name="Cadillac",Price=35.4f},
                new Product{Id=17,Name="Ford",Price=50.96f},
                new Product{Id=18,Name="Audi",Price=95.74f}
            );
            base.OnModelCreating(modelBuilder);
        }
    } 
}
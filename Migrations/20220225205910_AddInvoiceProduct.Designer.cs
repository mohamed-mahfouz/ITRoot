// <auto-generated />
using ITRoot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ITRoot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220225205910_AddInvoiceProduct")]
    partial class AddInvoiceProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITRoot.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ITRoot.Models.InvoiceProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "InvoiceId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceProduct");
                });

            modelBuilder.Entity("ITRoot.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pontiac",
                            Price = 48.59f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Buick",
                            Price = 60.04f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nissan",
                            Price = 15.64f
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chrysler",
                            Price = 30.23f
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chevrolet",
                            Price = 21.66f
                        },
                        new
                        {
                            Id = 6,
                            Name = "Volkswagen",
                            Price = 66.2f
                        },
                        new
                        {
                            Id = 7,
                            Name = "Chevrolet",
                            Price = 24.99f
                        },
                        new
                        {
                            Id = 8,
                            Name = "Mercury",
                            Price = 99.25f
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dodge",
                            Price = 13.13f
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mercedes-Benz",
                            Price = 88.23f
                        },
                        new
                        {
                            Id = 11,
                            Name = "Mazda",
                            Price = 8.38f
                        },
                        new
                        {
                            Id = 12,
                            Name = "Chevrolet",
                            Price = 24.68f
                        },
                        new
                        {
                            Id = 13,
                            Name = "Acura",
                            Price = 10.19f
                        },
                        new
                        {
                            Id = 14,
                            Name = "GMC",
                            Price = 89.59f
                        },
                        new
                        {
                            Id = 15,
                            Name = "Ford",
                            Price = 90.14f
                        },
                        new
                        {
                            Id = 16,
                            Name = "Cadillac",
                            Price = 35.4f
                        },
                        new
                        {
                            Id = 17,
                            Name = "Ford",
                            Price = 50.96f
                        },
                        new
                        {
                            Id = 18,
                            Name = "Audi",
                            Price = 95.74f
                        });
                });

            modelBuilder.Entity("ITRoot.Models.InvoiceProduct", b =>
                {
                    b.HasOne("ITRoot.Models.Invoice", "Invoice")
                        .WithMany("InvoiceProducts")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITRoot.Models.Product", "product")
                        .WithMany("InvoiceProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("product");
                });

            modelBuilder.Entity("ITRoot.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceProducts");
                });

            modelBuilder.Entity("ITRoot.Models.Product", b =>
                {
                    b.Navigation("InvoiceProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

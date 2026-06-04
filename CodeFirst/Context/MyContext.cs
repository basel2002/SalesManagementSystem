using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Context
{
    public class MyContext : DbContext
    {

        public MyContext() : base() { }

        public MyContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=.;Initial Catalog=ClassicModels;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ================= PRODUCT =================
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Code);

                p.HasOne(p => p.ProductLine)
                 .WithMany(p => p.Products)
                 .HasForeignKey(p => p.ProductLineID)
                 .OnDelete(DeleteBehavior.NoAction);

                p.Property(p => p.Name).HasMaxLength(255);
                p.Property(p => p.Vendor).HasMaxLength(255);
                p.Property(p => p.PdtDescription).HasMaxLength(255);
                p.Property(p => p.MSRP).HasMaxLength(255);

                p.Property(p => p.Code).IsRequired();
                p.Property(p => p.ProductLineID).IsRequired();

                p.Property(p => p.BuyPrice)
                 .HasColumnType("decimal(19,0)");
            });


            // ================= PRODUCT LINE =================
            modelBuilder.Entity<ProductLine>(pl =>
            {
                pl.HasKey(pl => pl.ID);

                pl.Property(pl => pl.ID).IsRequired();
                pl.Property(p => p.DescinText).HasMaxLength(255);
                pl.Property(p => p.DescinHTML).HasMaxLength(255);
                pl.Property(p => p.Image).HasMaxLength(100);
            });


            // ================= ORDER_PRODUCT =================
            modelBuilder.Entity<Order_product>(op =>
            {
                op.HasKey(op => new { op.OrderID, op.ID, op.ProductCode });

                op.Property(op => op.PriceEach)
                  .HasColumnType("decimal(19,0)");

                op.HasOne(op => op.Product)
                  .WithMany(p => p.Order_Products)
                  .HasForeignKey(op => op.ProductCode)
                  .OnDelete(DeleteBehavior.NoAction);

                op.HasOne(op => op.Order)
                  .WithMany(o => o.Order_Products)
                  .HasForeignKey(op => op.OrderID)
                  .OnDelete(DeleteBehavior.NoAction);
            });


            // ================= ORDER =================
            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(o => o.ID);

                o.HasOne(o => o.Customer)
                 .WithMany(c => c.Orders)
                 .HasForeignKey(o => o.CustomerID)
                 .OnDelete(DeleteBehavior.NoAction);

                o.Property(o => o.Comments).HasMaxLength(255);
            });


            // ================= PAYMENT =================
            modelBuilder.Entity<Payment>(p =>
            {
                p.HasKey(p => p.CheckNum);

                p.Property(p => p.CheckNum)
                 .HasMaxLength(255)
                 .IsRequired();

                p.Property(p => p.Amount)
                 .HasColumnType("decimal(19,0)");

                p.HasOne(p => p.Customer)
                 .WithMany(c => c.Payments)
                 .HasForeignKey(p => p.CustomerID)
                 .OnDelete(DeleteBehavior.NoAction);
            });


            // ================= CUSTOMER =================
            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(c => c.ID);

                c.Property(c => c.CreditLimit)
                 .HasColumnType("decimal(19,0)");

                c.Property(c => c.Name).HasMaxLength(255);
                c.Property(c => c.LastName).HasMaxLength(255);
                c.Property(c => c.FirstName).HasMaxLength(255);
                c.Property(c => c.Phone).HasMaxLength(255);
                c.Property(c => c.Address1).HasMaxLength(255);
                c.Property(c => c.Address2).HasMaxLength(255);
                c.Property(c => c.City).HasMaxLength(255);
                c.Property(c => c.State).HasMaxLength(255);
                c.Property(c => c.Country).HasMaxLength(255);

                c.HasOne(c => c.Employee)
                 .WithMany(e => e.Customers)
                 .HasForeignKey(c => c.SalesRepEmployeeNum)
                 .OnDelete(DeleteBehavior.NoAction);
            });


            // ================= OFFICE =================
            modelBuilder.Entity<Office>(f =>
            {
                f.HasKey(f => f.Code);

                f.Property(f => f.City).HasMaxLength(255);
                f.Property(f => f.Phone).HasMaxLength(255);
                f.Property(f => f.Address1).HasMaxLength(255);
                f.Property(f => f.Address2).HasMaxLength(255);
                f.Property(f => f.State).HasMaxLength(255);
                f.Property(f => f.Country).HasMaxLength(255);
                f.Property(f => f.Territory).HasMaxLength(255);

                f.HasMany(f => f.Employees)
                 .WithOne(e => e.Office)
                 .HasForeignKey(e => e.OfficeCode)
                 .OnDelete(DeleteBehavior.NoAction);
            });


            // ================= EMPLOYEE =================
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.ID);

                e.Property(e => e.LastName).HasMaxLength(255);
                e.Property(e => e.FirstName).HasMaxLength(255);
                e.Property(e => e.Extension).HasMaxLength(255);
                e.Property(e => e.Email).HasMaxLength(255);
                e.Property(e => e.JobTitle).HasMaxLength(255);

                e.HasOne(e => e.Manager)
                 .WithMany(m => m.Employees)
                 .HasForeignKey(e => e.ReportsTo)
                 .OnDelete(DeleteBehavior.NoAction);
            });


            // ================= PRODUCTLINE SEED =================
            modelBuilder.Entity<ProductLine>().HasData(
                new ProductLine { ID = 1, DescinText = "Classic Cars", DescinHTML = "<p>Classic Cars</p>", Image = "classic.jpg" },
                new ProductLine { ID = 2, DescinText = "Motorcycles", DescinHTML = "<p>Motorcycles</p>", Image = "moto.jpg" },
                new ProductLine { ID = 3, DescinText = "Trucks and Buses", DescinHTML = "<p>Trucks and Buses</p>", Image = "trucks.jpg" },
                new ProductLine { ID = 4, DescinText = "Vintage Cars", DescinHTML = "<p>Vintage Cars</p>", Image = "vintage.jpg" },
                new ProductLine { ID = 5, DescinText = "Ships", DescinHTML = "<p>Ships</p>", Image = "ships.jpg" }
            );


            // ================= PRODUCT SEED =================
            modelBuilder.Entity<Product>().HasData(
                new Product { Code = 101, ProductLineID = 1, Name = "1969 Mustang", Scale = 18, Vendor = "Ford", PdtDescription = "Classic muscle car", QtyInStock = 50, BuyPrice = 150, MSRP = "200" },
                new Product { Code = 102, ProductLineID = 2, Name = "Harley Davidson", Scale = 12, Vendor = "Harley", PdtDescription = "Iconic motorcycle", QtyInStock = 30, BuyPrice = 200, MSRP = "280" },
                new Product { Code = 103, ProductLineID = 3, Name = "Mack Truck", Scale = 24, Vendor = "Mack", PdtDescription = "Heavy duty truck", QtyInStock = 20, BuyPrice = 300, MSRP = "400" },
                new Product { Code = 104, ProductLineID = 4, Name = "1932 Ford Model B", Scale = 18, Vendor = "Ford", PdtDescription = "Vintage classic car", QtyInStock = 15, BuyPrice = 250, MSRP = "350" },
                new Product { Code = 105, ProductLineID = 5, Name = "Titanic Ship", Scale = 50, Vendor = "WhiteStar", PdtDescription = "Famous ocean liner", QtyInStock = 10, BuyPrice = 500, MSRP = "700" }
            );


            // ================= OFFICE SEED =================
            modelBuilder.Entity<Office>().HasData(
                new Office { Code = 1, City = "New York", Phone = "212-555-0100", Address1 = "100 Broadway", State = "NY", Country = "USA", PostalCode = 10001 },
                new Office { Code = 2, City = "London", Phone = "020-555-0200", Address1 = "200 Oxford St", Country = "UK" },
                new Office { Code = 3, City = "Paris", Phone = "033-555-0300", Address1 = "300 Champs", Country = "France", PostalCode = 75001 },
                new Office { Code = 4, City = "Tokyo", Phone = "081-555-0400", Address1 = "400 Shibuya", Country = "Japan" },
                new Office { Code = 5, City = "Cairo", Phone = "020-555-0500", Address1 = "500 Tahrir Sq", Country = "Egypt", PostalCode = 11511 }
            );


            // ================= EMPLOYEE SEED =================
            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, OfficeCode = 1, ReportsTo = null, LastName = "Smith", FirstName = "John", Extension = "x101", Email = "john@cm.com", JobTitle = "CEO" },
                new Employee { ID = 2, OfficeCode = 1, ReportsTo = 1, LastName = "Johnson", FirstName = "Sara", Extension = "x102", Email = "sara@cm.com", JobTitle = "Sales Manager" },
                new Employee { ID = 3, OfficeCode = 2, ReportsTo = 1, LastName = "Brown", FirstName = "Mike", Extension = "x103", Email = "mike@cm.com", JobTitle = "Sales Rep" },
                new Employee { ID = 4, OfficeCode = 3, ReportsTo = 2, LastName = "Davis", FirstName = "Emily", Extension = "x104", Email = "emily@cm.com", JobTitle = "Sales Rep" },
                new Employee { ID = 5, OfficeCode = 4, ReportsTo = 2, LastName = "Wilson", FirstName = "James", Extension = "x105", Email = "james@cm.com", JobTitle = "Sales Rep" }
            );


            // ================= CUSTOMER SEED =================
            modelBuilder.Entity<Customer>().HasData(
                new Customer { ID = 1, SalesRepEmployeeNum = 3, Name = "Alpha Corp", LastName = "Alpha", FirstName = "Tom", Phone = "555-1001", Address1 = "10 Main St", City = "Boston", State = "MA", Country = "USA", PostalCode = 2101, CreditLimit = 50000 },
                new Customer { ID = 2, SalesRepEmployeeNum = 3, Name = "Beta LLC", LastName = "Beta", FirstName = "Anna", Phone = "555-1002", Address1 = "20 King St", City = "Chicago", State = "IL", Country = "USA", PostalCode = 60601, CreditLimit = 30000 },
                new Customer { ID = 3, SalesRepEmployeeNum = 4, Name = "Gamma GmbH", LastName = "Gamma", FirstName = "Hans", Phone = "555-1003", Address1 = "30 Karl St", City = "Berlin", Country = "Germany", CreditLimit = 75000 },
                new Customer { ID = 4, SalesRepEmployeeNum = 4, Name = "Delta SA", LastName = "Delta", FirstName = "Marie", Phone = "555-1004", Address1 = "40 Rue St", City = "Lyon", Country = "France", PostalCode = 69001, CreditLimit = 40000 },
                new Customer { ID = 5, SalesRepEmployeeNum = 5, Name = "Epsilon Co", LastName = "Epsilon", FirstName = "Yuki", Phone = "555-1005", Address1 = "50 Sakura St", City = "Osaka", Country = "Japan", CreditLimit = 60000 }
            );


            // ================= ORDER SEED =================
            modelBuilder.Entity<Order>().HasData(
                new Order { ID = 1, CustomerID = 1, OrderDate = new DateTime(2024, 1, 10), RequiredDate = new DateTime(2024, 1, 20), ShippedDate = new DateTime(2024, 1, 15), Status = 1, Comments = "First order" },
                new Order { ID = 2, CustomerID = 2, OrderDate = new DateTime(2024, 2, 5), RequiredDate = new DateTime(2024, 2, 15), ShippedDate = new DateTime(2024, 2, 10), Status = 1, Comments = "Urgent" },
                new Order { ID = 3, CustomerID = 3, OrderDate = new DateTime(2024, 3, 1), RequiredDate = new DateTime(2024, 3, 15), Status = 0, Comments = "Pending" },
                new Order { ID = 4, CustomerID = 4, OrderDate = new DateTime(2024, 4, 20), RequiredDate = new DateTime(2024, 5, 1), ShippedDate = new DateTime(2024, 4, 25), Status = 1, Comments = "Handle carefully" },
                new Order { ID = 5, CustomerID = 5, OrderDate = new DateTime(2024, 5, 15), RequiredDate = new DateTime(2024, 5, 25), Status = 0, Comments = "Awaiting stock" }
            );


            // ================= ORDER PRODUCT SEED =================
            modelBuilder.Entity<Order_product>().HasData(
                new Order_product { OrderID = 1, ProductCode = 101, Qty = 2, PriceEach = 150 },
                new Order_product { OrderID = 1, ProductCode = 102, Qty = 1, PriceEach = 200 },
                new Order_product { OrderID = 2, ProductCode = 103, Qty = 3, PriceEach = 300 },
                new Order_product { OrderID = 3, ProductCode = 104, Qty = 1, PriceEach = 250 },
                new Order_product { OrderID = 4, ProductCode = 105, Qty = 2, PriceEach = 500 }
            );


            // ================= PAYMENT SEED =================
            modelBuilder.Entity<Payment>().HasData(
                new Payment { CheckNum = "CHK001", CustomerID = 1, PaymentDate = new DateTime(2024, 1, 16), Amount = 300 },
                new Payment { CheckNum = "CHK002", CustomerID = 2, PaymentDate = new DateTime(2024, 2, 11), Amount = 900 },
                new Payment { CheckNum = "CHK003", CustomerID = 3, PaymentDate = new DateTime(2024, 3, 20), Amount = 250 },
                new Payment { CheckNum = "CHK004", CustomerID = 4, PaymentDate = new DateTime(2024, 4, 26), Amount = 1000 },
                new Payment { CheckNum = "CHK005", CustomerID = 5, PaymentDate = new DateTime(2024, 5, 20), Amount = 600 }
            );
        }


        // ================= TABLES =================
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_product> Orders_products { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductLine> ProductLines { get; set; }
    }
}
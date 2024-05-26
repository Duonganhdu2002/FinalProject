using System.Data.Entity;
using FinalProject.Models;
using System.Configuration;

namespace FinalProject
{
    internal class EFDbContext : DbContext

    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeID);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductID);

            base.OnModelCreating(modelBuilder);
        }

    }
}

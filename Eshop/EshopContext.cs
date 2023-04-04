using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DataLayer
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Manufacture> Manufacturers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Ëshop; Trusted_Connection = True; ");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            
            modelBuilder.Entity<OrderProduct>()
            .HasKey(b => new { b.OrderId, b.ProductId });


        }
    }
}
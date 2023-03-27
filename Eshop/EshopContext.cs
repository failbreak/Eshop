using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLayer
{
    public class EshopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Manufacture> Manufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //ManyToMany
            modelBuilder.Entity<OrderProduct>()
            .HasKey(b => new { b.OrderId, b.ProductId });


        }
    }
}
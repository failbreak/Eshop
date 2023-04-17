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
        public DbSet<Order> Orders { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //        .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Ëshop; Trusted_Connection = True; ");

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            
            modelBuilder.Entity<OrderProduct>()
            .HasKey(b => new { b.OrderId, b.ProductId });

            modelBuilder.Entity<Manufacture>().HasData(
                new Manufacture { Name = "HailStorm", ManufactureId = 1 },
                new Manufacture { Name = "Volvo", ManufactureId = 2 },
                new Manufacture { Name = "BigHard", ManufactureId = 3 },
                new Manufacture { Name = "NotActivision", ManufactureId = 4 },
                new Manufacture { Name = "Bluray Project Blue", ManufactureId = 5 },
                new Manufacture { Name = "Todd Howard", ManufactureId = 6 },
                new Manufacture { Name = "RecycleSoft", ManufactureId = 7 },
                new Manufacture { Name = "Popstar Games", ManufactureId = 8 },
                new Manufacture { Name = "EEEEEEEeee", ManufactureId = 9 }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Name = "First Person Shooter", CateGoryId = 1 },
                new Category { Name = "Action", CateGoryId = 2 },
                new Category { Name = "Strategy", CateGoryId = 3 },
                new Category { Name = "Adventure", CateGoryId = 4 },
                new Category { Name = "RolePlay", CateGoryId = 5 },
                new Category { Name = "SEX", CateGoryId = 6 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Name = "Grand Thug Auto 6: Watch Me NAE NAE", CategoryId = 5, ManufactureId = 8, Price = 69, ProductId = 1 },
                new Product { Name = "The elder scrolls 6: Shimmering Booty", CategoryId = 4, ManufactureId = 6, Price = 420, ProductId = 2 },
                new Product { Name = "Only Hands", CategoryId = 6, ManufactureId = 9, Price = 0, ProductId = 3 },
                new Product { Name = "Call Of Booty: Black Hens 1", CategoryId = 1, ManufactureId = 1, Price = 1000, ProductId = 4}
                );
            modelBuilder.Entity<ProductPicture>().HasData(
                new ProductPicture { ProductId = 1, ProductPictureId = 1, PictureUrl = "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg" },
                new ProductPicture { ProductId = 2, ProductPictureId = 2, PictureUrl = "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg" },
                new ProductPicture { ProductId = 3, ProductPictureId = 3, PictureUrl = "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg" },
                new ProductPicture { ProductId = 4, ProductPictureId = 4, PictureUrl = "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg" }
                );
        }
    }
}
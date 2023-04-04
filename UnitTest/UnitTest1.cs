using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore.InMemory;
using ServiceLayer.Service;

namespace UnitTest
{
    [TestClass]
    public class ProduktServiceTest
    {
        [TestMethod]
        public void AddProdukt()
        {
            var options = new DbContextOptionsBuilder<EshopContext>()
                .UseInMemoryDatabase(databaseName: "Wr_2_db")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EshopContext(options))
            {
                context.Products.Add(new Product { Name = "Ryge Stop kursus", Price = 420 });
                context.Products.Add(new Product { Name = "Stop being immature", Price = 69 });
                context.Products.Add(new Product {Name = "What is Leetspeak?", Price = 1337 });
                context.SaveChanges();
            }

            using (var context = new EshopContext(options))
            {
                var service = new ProductService(context);
                var result = service.GetProducts();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, result.Count());
            }
        }
    }
}
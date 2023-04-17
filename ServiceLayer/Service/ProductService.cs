using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly EshopContext _context;
        public ProductService(EshopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = _context.Products.AsNoTracking();
            return await products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            IQueryable queryable = _context.Products.Where(x => x.ProductId == id);
            Product ReturnValue = _context.Products.AsNoTracking().First();
            return ReturnValue;
        }

        public async Task AddProduct(Product product)
        {
            //specify there is a better way
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(Product product)
        {
            Product? chosenProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == product.ProductId);
            if (chosenProduct == null)
                return;
            chosenProduct = product;
            _context.Entry(chosenProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProduct(int productId)
        {
            Product? chosenProduct = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (chosenProduct == null)
                return;
            chosenProduct.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> Search(string search)
        {
            List<Product> ReturnValue = await _context.Products.Where(x => EF.Functions.Like(x.Name, $"{search}")).ToListAsync();
            return ReturnValue;
        }


    }
}

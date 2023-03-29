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
        
        public List<Product> GetProducts()
        {
            IQueryable query = _context.Products.Include(x=>x.Manufacture);

           return _context.Products.AsNoTracking().ToList();

        }

        public List<Product> GetProductById(int id)
        {
            IQueryable queryable = _context.Products.Where(x=>x.ProductId == id);
            return _context.Products.AsNoTracking().ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }


        public IQueryable<Product> SortFilterPage(FilterPageOptions options)
        {
            var ProductQuery = _context.Products
                .AsNoTracking()
                .OrderProductsBy(options.OrderOptions)
                .FilterProducts(options.FilterOptions, options.FilterValue);

            options.SetupRestOfProducts(ProductQuery);
            return ProductQuery.Page(options.PageNum - 1, options.PageSize);
        }

        public void EditProduct(Product product)
        {
            Product? chosenProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == product.ProductId);
            if (chosenProduct == null)
                return;
            chosenProduct = product;
            _context.Entry(chosenProduct).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveProduct(int productId)
        {
            Product? chosenProduct = _context.Products.FirstOrDefault(x => x.ProductId == productId);
                if (chosenProduct == null)
                return;
            chosenProduct.IsDeleted = true;
            _context.SaveChanges();
        }


    }
}

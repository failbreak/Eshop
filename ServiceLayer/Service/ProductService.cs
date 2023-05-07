using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Service.Dto;
using ServiceLayer.Service.DtoSorts;

namespace ServiceLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly EshopContext _context;
        public ProductService(EshopContext context)
        {
            _context = context;
        }
        public async Task<int> AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            // Check if a product with the same name already exists
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                throw new ArgumentException("No Products here that you were looking for", nameof(product));
            }

            // Add the new product to the context and save changes
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.ProductId;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var product = await _context.Products.AsNoTracking().Include(i => i.ProductPictures).Include(c => c.Category).Include(m => m.Manufacture).ToListAsync();
            return product;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categorys.ToListAsync();
        }

        public async Task<List<Manufacture>> GetManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortFilterPageAsync(SortFilterOptions options)
        {
            var productsQuery = _context.Products
                .AsNoTracking()
                .Include(i => i.ProductPictures)
                .OrderProductsBy(options.OrderByOptions)
                .FilterProductsBy(options.FilterBy, options.FilterValue);

            options.SetupProduct(productsQuery);

            var pagedProducts = await productsQuery.Page(options.PageNum - 1, options.PageSize).ToListAsync();

            return pagedProducts;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var VsStudioBullshit = await _context.Products.AsNoTracking().Include(p => p.ProductPictures).SingleOrDefaultAsync(p => p.ProductId == productId);
            return VsStudioBullshit;
        }
        public async Task<Product> Create(Product newProdukt)
        {
            Product product = new Product { Name = newProdukt.Name, Price = newProdukt.Price, CategoryId = newProdukt.CategoryId, ManufactureId = newProdukt.ManufactureId };
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return newProdukt;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            // Check if the product exists in the database
            var existingProduct = await _context.Products.FindAsync(product.ProductId);
            if (existingProduct == null)
            {
                return false;
            }

            // Update the existing product with the new values
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ManufactureId = product.ManufactureId;
            existingProduct.CategoryId = product.CategoryId;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Product> DeleteProduct(int productId)
        {
            Product product = _context.Products.Include(p => p.ProductPictures).Include(p => p.Manufacture).Include(p => p.Category).SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
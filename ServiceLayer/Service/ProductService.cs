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
        public IQueryable<Product> AddProduct()
        {
            var ProductsQuery = _context.Products.AsNoTracking();
            return ProductsQuery;
        }

        public async Task<Product> GetProducts()
        {
            var ProductsQuery = _context.Products.AsNoTracking().Include(i => i.ProductPictures).Include(c=>c.Category).Include(m=>m.Manufacture);
            return (Product)ProductsQuery;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categorys;
        }

        public IQueryable<Manufacture> GetManufactuers()
        {
            return _context.Manufacturers;
        }

        public IQueryable<Product> SortFilterPage(SortFilterOptions options)
        {
            var ProductsQuery = _context.Products
            .AsNoTracking()
            .Include(i => i.ProductPictures)
            .OrderProductsBy(options.OrderByOptions)
            .FilterProductsBy(options.FilterBy, options.FilterValue);
            options.SetupProduct(ProductsQuery);
            return ProductsQuery.Page(options.PageNum - 1, options.PageSize);
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product VsStudioBullshit = _context.Products.AsNoTracking().Include(p => p.ProductPictures).SingleOrDefault(p => p.ProductId == productId);
            return VsStudioBullshit;
        }
        public async Task<Product> Create(Product newProdukt)
        {
            Product product = new Product { Name = newProdukt.Name, Price = newProdukt.Price, CategoryId = newProdukt.CategoryId, ManufactureId = newProdukt.ManufactureId };
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return newProdukt;
        }

        public async Task<Product> Update(Product updateProduct)
        {
            Product product = new Product { ProductId = updateProduct.ProductId, Name = updateProduct.Name, Price = updateProduct.Price, CategoryId = updateProduct.CategoryId, ManufactureId = updateProduct.ManufactureId };
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
            return updateProduct;
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
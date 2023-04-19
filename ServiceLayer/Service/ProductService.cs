using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
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
        public IQueryable<ProductDto> AddProduct()
        {
            var ProductsQuery = _context.Products.AsNoTracking().MapProduct();
            return ProductsQuery;
        }

        public IQueryable<ProductDto> GetProducts()
        {
            var ProductsQuery = _context.Products.AsNoTracking().MapProduct();
            return ProductsQuery;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categorys;
        }

        public IQueryable<Manufacture> GetManufactuers()
        {
            return _context.Manufacturers;
        }

        public IQueryable<ProductDto> SortFilterPage(SortFilterOptions options)
        {
            var ProductsQuery = _context.Products
                .AsNoTracking()
                .MapProduct()
                .OrderProductsBy(options.OrderByOptions)
                .FilterProductsBy(options.FilterBy, options.FilterValue);

            options.SetupRestOfDto(ProductsQuery);
            return ProductsQuery.Page(options.PageNum - 1, options.PageSize);
        }

        public ProductDto GetProductById(int productId)
        {
            Product product = _context.Products.AsNoTracking().Include(p => p.ProductPictures).SingleOrDefault(p => p.ProductId == productId);
            return new ProductDto { ProductId = product.ProductId, Name = product.Name, Price = product.Price, pictures = product.ProductPictures };
        }

        public ProductDto Create(ProductDto newProdukt)
        {
            Product product = new Product { Name = newProdukt.Name, Price = newProdukt.Price, CategoryId = newProdukt.CategoryId, ManufactureId = newProdukt.ManufactureId };
            _context.Products.Add(product);
            _context.SaveChanges();
            return newProdukt;
        }

        public ProductDto Update(ProductDto updateProduct)
        {
            Product product = new Product { ProductId = updateProduct.ProductId, Name = updateProduct.Name, Price = updateProduct.Price, CategoryId = updateProduct.CategoryId, ManufactureId = updateProduct.ManufactureId };
            _context.Products.Update(product);

            _context.SaveChanges();
            return updateProduct;
        }

        public ProductDto Delete(int productId)
        {
            Product product = _context.Products.Include(p => p.ProductPictures).Include(p => p.Manufacture).Include(p => p.Category).SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            _context.SaveChanges();
            return new ProductDto { ProductId = product.ProductId, Name = product.Name, Price = product.Price, pictures = product.ProductPictures };
        }

    }
}

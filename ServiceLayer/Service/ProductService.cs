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
            var products = _context.Products.Include(x => x.ProductPictures).Include(x => x.Manufacture).AsNoTracking();
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
            List<Product> ReturnValue = await _context.Products.Where(x => EF.Functions.Like(x.Name, $"%{search}%")).ToListAsync();
            return ReturnValue;
        }

        public Page<Product> GetPaging(int page, int count, string? search = null, int? categoryId = null, int[]? manufacturerIds = null, OrderByEnum? orderBy = OrderByEnum.NameAsc)
        {
            IQueryable<Product> query = _context.Products.Include(x => x.Manufacture).Include(x => x.Category).Include(x => x.ProductPictures).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Manufacture.Name.ToLower().Contains(search.ToLower()));
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (manufacturerIds != null && manufacturerIds.Any())
            {
                query = query.Where(x => manufacturerIds.Contains(x.ManufactureId.Value));
            }

            switch (orderBy)
            {
                case OrderByEnum.NameAsc:
                    query = query.OrderBy(x => x.Name);
                    break;
                case OrderByEnum.NameDesc:
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case OrderByEnum.PriceAsc:
                    query = query.OrderBy(x => x.Price);
                    break;
                case OrderByEnum.PriceDesc:
                    query = query.OrderByDescending(x => x.Price);
                    break;
            }
            List<Product> products = query.Page(page, count).ToList();

            return new Page<Product>() { Items = products, Total = query.Count(), CurrentPage = page, PageSize = count };
        }
    }
}

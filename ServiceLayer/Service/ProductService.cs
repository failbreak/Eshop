using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            




    }
}

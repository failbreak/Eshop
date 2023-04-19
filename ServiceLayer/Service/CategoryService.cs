using DataLayer.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Service
{
    public class CategoryService : ICatagoryService
    {
        private readonly EshopContext _context;

        public CategoryService(EshopContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categorys.AsNoTracking().ToList();
        }

        public void AddCategory(string category)
        {
            _context.Categorys.Add(new Category { Name = category });
            _context.SaveChanges();
        }
    }
}

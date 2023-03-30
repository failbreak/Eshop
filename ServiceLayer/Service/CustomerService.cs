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
    public class CustomerService
    {
        private readonly EshopContext _context;
        public CustomerService(EshopContext context)
        {
            _context = context;
        }

        public List<Customer> GetProducts()
        {
            IQueryable query = _context.Customers;
            return _context.Customers.AsNoTracking().ToList();
        }

        public List<Customer> GetProductById(int CustomerId)
        {
            IQueryable queryable = _context.Customers.Where(x => x.CustomerId == CustomerId);
            return _context.Customers.AsNoTracking().ToList();
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

        }
        public void DeleteCustomer(int CustomerId)
        {
            Customer? chosenCustomer = _context.Customers.FirstOrDefault(x => x.CustomerId == CustomerId);
            if (chosenCustomer == null)
                return;
            chosenCustomer.IsDeleted = true;
            _context.SaveChanges();
        }
        public void EditCustomer(Customer Customer)
        {
            Customer? chosenCustomer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.CustomerId == Customer.CustomerId);
            if (chosenCustomer == null)
                return;
            chosenCustomer = Customer;
            _context.Entry(chosenCustomer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

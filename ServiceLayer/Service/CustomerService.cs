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
    public class CustomerService : ICustomerService
    {
        private readonly EshopContext _context;
        public CustomerService(EshopContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var query = _context.Customers.AsNoTracking();
            return await query.ToListAsync();
        }

        public List<Customer> GetProductById(int CustomerId)
        {
            IQueryable queryable = _context.Customers.Where(x => x.CustomerId == CustomerId);
            return _context.Customers.AsNoTracking().ToList();
        }

        public async Task CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

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

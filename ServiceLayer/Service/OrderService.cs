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
    public class OrderService : IOrderService
    {
        private readonly EshopContext _context;
        public OrderService(EshopContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Customer customer)
        {
            _context.Orders.Add(new Order{PurchaseDate = DateTime.Now, Customer = customer});

          await _context.SaveChangesAsync();
        }   
        public async Task UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
        public List<Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().ToList();
        }
    }
}

using DataLayer;
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
        

    }
}

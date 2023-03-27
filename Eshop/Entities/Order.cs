using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderProduct> Products { get; set; }

    }
}

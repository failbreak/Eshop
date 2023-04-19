using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Dto
{
    public class OrderDto
    {
        public List<ProductDto> Products { get; set; }

        public OrderDto()
        {
            Products = new List<ProductDto>();
        }
    }
}

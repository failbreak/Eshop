using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class Item
    {
        public Product Product { get; set; }
        public int Stack { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category
    {
        public int CateGoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
        
    }
}

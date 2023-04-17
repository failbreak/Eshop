using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Produkt Name")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }


        public bool IsDeleted { get; set; }



        public int? CategoryId { get; set; } 
        public Category Category { get; set; }  

        public int? ManufactureId { get; set; }  
        public Manufacture Manufacture { get; set; }  

        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<OrderProduct> Orders { get; set; } 

    }
}

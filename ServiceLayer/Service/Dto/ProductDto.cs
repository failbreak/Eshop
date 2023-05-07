using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public ICollection<ProductPicture> pictures { get; set; }

        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public int? ManufactureId { get; set; }
        public string Manufacture { get; set; }

        public int? Stack { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductPicture
    {
        public int ProductPictureId { get; set; }
        public string PictureUrl { get; set; }


        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}

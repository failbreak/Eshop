﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Manufacture
    {
        public int ManufactureId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } //Ref

    }
}

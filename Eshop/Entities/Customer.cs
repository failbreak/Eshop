﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Customer
    {
      
        public string email { get; set; }


        public int CustomerId { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Customer(string FirstName, string LastName, string Address, string email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.email = email;
        }  public Customer(int id, string FirstName, string LastName, string Address, string email)
        {
            this.CustomerId = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.email = email;

        }
    }
}

using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TEstOfProduct
{
    public class Extension
    {
        public static EshopContext CreateContext([CallerMemberName]string dbname = "")
        {
            DbContextOptionsBuilder<EshopContext> builder = new();
            builder.UseInMemoryDatabase(dbname);

            var context = new EshopContext(builder.Options);

            return context;

        }
    }
}

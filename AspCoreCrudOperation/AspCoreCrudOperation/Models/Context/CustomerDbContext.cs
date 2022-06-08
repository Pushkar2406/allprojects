using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspCoreCrudOperation.Models.Context
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions options) : base(options)
            {
            }

            DbSet<Customer> Customers { get; set; }
        }
    }
}

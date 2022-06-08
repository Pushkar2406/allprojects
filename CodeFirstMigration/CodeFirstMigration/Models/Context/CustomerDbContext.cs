using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigration.Models.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData( 
                new Customer() { CustomerId = 1, Name = "John", CustomerEmail = "john@gmail.com" },
                new Customer() { CustomerId = 2, Name = "Chris", CustomerEmail = "Chris@gmail.com" },
                new Customer() { CustomerId = 3, Name = "Mukesh", CustomerEmail = "Mukesh@gmail.com" });
        }
    }
}

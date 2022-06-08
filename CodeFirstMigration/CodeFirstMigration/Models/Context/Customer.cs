using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstMigration.Models.Context
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
     
        public string CustomerEmail { get; set; }
     
    }
}

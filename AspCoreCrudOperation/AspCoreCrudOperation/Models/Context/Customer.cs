using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreCrudOperation.Models.Context
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }
      
        public string CustomerEmail { get; set; }
        
    }
}

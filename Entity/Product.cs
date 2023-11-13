using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Active { get; set; }
    }
}

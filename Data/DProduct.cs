using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
    {
        public static string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=userTecsup;Password=12345678";
        public List<Product> Get()
        {
            return new List<Product>();
        }
    }
}

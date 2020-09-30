using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Iceland_Moss.Model
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public decimal Total
        {
            get
            {
                return Product.Price * Count;
            }
        }
    }
}

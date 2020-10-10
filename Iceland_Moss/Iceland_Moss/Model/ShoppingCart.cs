using Iceland_Moss.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Iceland_Moss.Model
{
    public class ShoppingCart : BindableBase, ICartItem
    {
        public Product Product { get; set; }

        private int count;
        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        public decimal Total
        {
            get
            {
                return Product.Price * Count;
            }
        }
    }
}

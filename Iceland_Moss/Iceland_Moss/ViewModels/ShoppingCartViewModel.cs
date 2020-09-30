using Iceland_Moss.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;

namespace Iceland_Moss.ViewModels
{
    public class ShoppingCartViewModel : BindableBase
    {
        public IList<ShoppingCart> Items { get; set; }

        public ShoppingCartViewModel()
        {
            Items = new ObservableCollection<ShoppingCart>();
        }


        private ShoppingCart FindItem(Product ItemsToFind)
        {
            foreach (var item in Items)
            {
                if (item.Product == ItemsToFind)
                    return item;
            }
            return null;
        }

        public void IncrementOrder(Product item)
        {
            //如果產品已經在購物車
            var foundItem = FindItem(item);
            //累加
            if (foundItem != null)
            {
                foundItem.Count++;
            }
            else
            {
                //如果沒有 建立一個新的
                var cartItem = new ShoppingCart()
                {
                    Product = item,
                    Count = 1
                };
                Items.Add(cartItem);
            }

        }
    }
}

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
        public IList<ICartItem> Items { get; set; }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }


        private int itemCount;
        public int ItemCount
        {
            get
            {
                return Items.OfType<ShoppingCart>().Count();
            }
            //set { SetProperty(ref itemCount, value); }
        }

        public ShoppingCartViewModel()
        {
            Items = new ObservableCollection<ICartItem>();
        }


        private ShoppingCart FindItem(Product ItemsToFind)
        {
            foreach (var item in Items)
            {
                //只有 Items 是 ShoppingCart才執行
                if (item is ShoppingCart productItem)
                {
                    if (productItem.Product == ItemsToFind)
                        return productItem;
                }
            }
            return null;
        }


        private void UpdateTotal()
        {

            decimal calculatedTotal = 0;

            foreach (var item in Items)
            {
                if (item is ShoppingCart productItem)
                {
                    calculatedTotal += productItem.Total;
                }
            }

            //計算運費
            var freight = GetFreightItem();
            freight.CalculateFreight(calculatedTotal);

            Total = calculatedTotal + freight.FreightCharge;

            //購物車數量在這裡做動態綁定
            OnPropertyChanged(nameof(ItemCount));
        }

        /// <summary>
        /// 增加訂單數量
        /// </summary>
        /// <param name="item"></param>
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
                //新增的項目Index 0在比較前面顯示
                Items.Insert(0, cartItem);
            }
            UpdateTotal();
        }

        public void RemoveItem(ShoppingCart item)
        {
            Items.Remove(item);
            UpdateTotal();
        }

        private Freight GetFreightItem()
        {
            foreach (var item in Items)
            {
                if (item is Freight freight)
                {
                    return freight;
                }
            }
            return null;

        }
    }
}

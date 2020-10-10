using Iceland_Moss.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Iceland_Moss.Converter
{
    public class ShoppingCartDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProductItem { get; set; }
        public DataTemplate FreightItem { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ShoppingCart)
                return ProductItem;
            else
                return FreightItem;
        }
    }
}

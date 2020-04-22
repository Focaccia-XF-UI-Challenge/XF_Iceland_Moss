using Iceland_Moss.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Iceland_Moss.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IList<Product> _products;
        public IList<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            Products = new ObservableCollection<Product>()
            {
                new Product()
                {
                     Name="Sky Blue",
                     HeroColor="#96C9F8",
                     ImageUrl="",
                     Price=12,
                     IsFeatured=false
                },
                new Product()
                {
                     Name="Lavander",
                     HeroColor="#D69EFC",
                     ImageUrl=" ",
                     Price=19,
                     IsFeatured=false
                },
                new Product()
                {
                     Name="Yellow Sun",
                     HeroColor="#FFCA81",
                     ImageUrl=" ",
                     Price=17,
                     IsFeatured=false
                },
                new Product()
                {
                     Name="Green Life ",
                     HeroColor="#74D69E",
                     ImageUrl=" ",
                     Price=14,
                     IsFeatured=false
                }

        };
        }
    }
}

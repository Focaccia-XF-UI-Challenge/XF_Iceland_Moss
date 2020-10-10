using Iceland_Moss.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        private Product _seletedProduct;
        public Product SeletedProduct
        {
            get { return _seletedProduct; }
            set { SetProperty(ref _seletedProduct, value); }
        }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";

            Products = new ObservableCollection<Product>()
            {
                new Product(){Sort=1,Name="Sky Blue",HeroColor="#96C9F8",ImageUrl="moss.png",Price=12,IsFeatured=false},
                new Product(){Sort=2,Name="Lavander",HeroColor="#D69EFC",ImageUrl="moss.png",Price=19,IsFeatured=true},
                new Product(){Sort=3,Name="Yellow Sun",HeroColor="#FFCA81",ImageUrl="moss.png",Price=17,IsFeatured=true},
                new Product(){Sort=4,Name="Green Life ",HeroColor="#74D69E",ImageUrl="moss.png",Price=14,IsFeatured=false},
                new Product(){Sort=5,Name="Red Life ",HeroColor="#DC3333",ImageUrl="moss.png",Price=12,IsFeatured=true},
                new Product(){Sort=6,Name="Orange Life ",HeroColor="#F4BA51",ImageUrl="moss.png",Price=10,IsFeatured=false},
                new Product(){Sort=7,Name="Pink Life ",HeroColor="#FCA4B4",ImageUrl="moss.png",Price=10,IsFeatured=false},
            };

            ShoppingCart = new ShoppingCartViewModel();
            ShoppingCart.Items.Add(new Freight() { FreightCharge = 15 });//如果沒有實作一個 ICartItem 型態是沒有辦法被塞進去的 (Part6 1:00:00 附近有實作)
            RemoveItemCommand = new Command<ShoppingCart>(d => RemoveItem(d));
        }

        private void RemoveItem(ShoppingCart d)
        {
            ShoppingCart.RemoveItem(d);
        }

        private DelegateCommand _navigationCommand;
        public DelegateCommand NavigationCommand =>
            _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExecuteNavigationCommand));

        async void ExecuteNavigationCommand()
        {
            await NavigationService.NavigateAsync("SecondPage");
        }


        public ICommand RemoveItemCommand { private set; get; }

    }
}

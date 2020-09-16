using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iceland_Moss.ViewModels
{
    public class ThridPageViewModel : ViewModelBase
    {
        public ThridPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Third Page";
        }
    }
}

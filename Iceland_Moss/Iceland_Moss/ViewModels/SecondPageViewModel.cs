using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iceland_Moss.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Second Page";
        }

        private DelegateCommand _navigationCommand;

        public DelegateCommand NavigationCommand =>
            _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExecuteNavigationCommand));

        async void ExecuteNavigationCommand()
        {
            await NavigationService.NavigateAsync("ThridPage");
        }
    }
}

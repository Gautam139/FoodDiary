using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //mandatory for navigation in prism start from here
        private DelegateCommand _navigationCommand_login;
        private DelegateCommand _navigationCommand_register;

        private readonly INavigationService _navigationService;

        public DelegateCommand NavigationCommand_login => _navigationCommand_login ?? (_navigationCommand_login = new DelegateCommand(ExecuteNavigationCommand));
        public DelegateCommand NavigationCommand_register => _navigationCommand_register ?? (_navigationCommand_register = new DelegateCommand(ExecuteNavigationCommand_register));

        private async void ExecuteNavigationCommand_register()
        {
            var param = new NavigationParameters();
            await _navigationService.NavigateAsync("SignUpPage", param);
        }

        //mandatory for navigation in prism end here


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
        }
        private async void ExecuteNavigationCommand()
        {
            var param = new NavigationParameters();
            param.Add("title","Hello from Main Page");
                                    
            await _navigationService.NavigateAsync("AboutPage",param);
        }
    }
}

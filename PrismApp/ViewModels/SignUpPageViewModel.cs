using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        //mandatory for navigation in prism start from here

        private async void Back_toLogin()
        {
            await _navigationService.NavigateAsync("/AboutPage");
        }

        private DelegateCommand _navigationCommand;
        private DelegateCommand _backToLogin;

        private readonly INavigationService _navigationService;

        public DelegateCommand backToLogin => _backToLogin ?? (_backToLogin = new DelegateCommand(Back_toLogin));
        public DelegateCommand Back_btn2 => _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExecuteNavigationCommand));


        public SignUpPageViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;

        }
        private async void ExecuteNavigationCommand()
        {
            await _navigationService.GoBackAsync();
        }
    }
}

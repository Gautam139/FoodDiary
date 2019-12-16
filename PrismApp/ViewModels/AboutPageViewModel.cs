using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrismApp.ViewModels
{
    public class AboutPageViewModel : BindableBase, INavigatedAware
    {
        private bool _dataLoading;
        
        public bool DataLoading
        {
            get { return _dataLoading; }
            set { SetProperty(ref _dataLoading, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //mandatory for navigation in prism start from here
        private DelegateCommand _navigationCommand;
        private DelegateCommand _registration_page;

        private readonly INavigationService _navigationService;

        public DelegateCommand Back_btn => _navigationCommand ?? (_navigationCommand = new DelegateCommand(ExecuteNavigationCommand));
        public DelegateCommand Registration_page => _registration_page ?? (_registration_page = new DelegateCommand(Registration_page_command));

        private async void Registration_page_command()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }

        public AboutPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DataLoading = true;
        }
        private async void ExecuteNavigationCommand()
        {
            await _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = "Loading...";
            await Task.Delay(2000);
            Title = parameters.GetValue<string>("title");
            DataLoading = false;
        }
    }
}

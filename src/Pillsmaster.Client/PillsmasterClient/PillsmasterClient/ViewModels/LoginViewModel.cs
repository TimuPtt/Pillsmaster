using PillsmasterClient.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Services;
using Xamarin.Forms;

namespace PillsmasterClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            _authenticationService = DependencyService.Get<IAuthenticationService>();
        }

        private async void OnLoginClicked(object obj)
        {
            IsBusy = true;

            var token = await _authenticationService.Login(email, password);

            if (token != null)
            {
                //await Shell.Current.DisplayAlert("Authorized", Application.Current.Properties["oauth_token"].ToString(), "Ok");

                IsBusy = false;

                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                return;
            }
            await Shell.Current.DisplayAlert("Ошибка", "Авторизация провалена! Проверьте правильность сочетания e-mail/пароль", "Oк");

            Email = string.Empty;
            Password = string.Empty;

            IsBusy = false;
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}

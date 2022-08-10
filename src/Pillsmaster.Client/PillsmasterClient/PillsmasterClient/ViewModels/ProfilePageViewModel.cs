using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using PillsmasterClient.Views;
using Xamarin.Forms;

namespace PillsmasterClient.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public IAsyncCommand LogOutAsyncCommand { get; }
        public ProfilePageViewModel()
        {
            LogOutAsyncCommand = new AsyncCommand(OnLogOutClicked);
        }

        private async Task OnLogOutClicked()
        {
            Application.Current.Properties["oauth_token"] = null;
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
        }
    }
}

using System.Threading.Tasks;

using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.UserMedicineModels;
using PillsmasterClient.Views;
using PillsmasterClient.Views.AddMedicineSequence;
using Xamarin.Forms;

namespace PillsmasterClient.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        private readonly IPlanInfService _planInfService;

        public ObservableRangeCollection<PlanInf> PlanInfs { get; set; }
        public IAsyncCommand LogoutCommand { get; }
        public IAsyncCommand RefreshCommand { get; }
        public IAsyncCommand AddCommand { get; }
        public IAsyncCommand<PlanInf> RemoveCommand { get; }

        public MainPageViewModel()
        {
            PlanInfs = new ObservableRangeCollection<PlanInf>();
            LogoutCommand = new AsyncCommand(OnLogoutClicked);
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(OnAddClicked);

            _planInfService = DependencyService.Get<IPlanInfService>();

            Refresh();
        }

        private async Task OnLogoutClicked()
        {
            Application.Current.Properties["oauth_token"] = null;
            await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            //BUG: fix logout (auth token dosent reset)
        }

        private async Task Refresh()
        {
            IsBusy = true;

            //await Task.Delay(500);

            PlanInfs.Clear();

            var planInfs = await _planInfService.GetPlanInfAsync();

            if (planInfs != null)
            {
                PlanInfs.AddRange(planInfs);

                IsBusy = false;

                return;
            }

            await Shell.Current.DisplayAlert("Нет лекарств", "Начните следить за приемом лекарств нажав кнопку Добавить",
                "Ок").ConfigureAwait(false);
            IsBusy = false;
        }

        public async Task OnItemTapped(object obj, ItemTappedEventArgs e)
        {
            var userMedicine = e.Item as UserMedicine;
            await Shell.Current.DisplayAlert("Tapped", userMedicine.TradeName, "Ok");
        }

        public async Task OnAddClicked()
        {
            await Shell.Current.GoToAsync($"{nameof(AddMedicinePage)}");
        }

        public async Task OnDeleteClicked()
        {

        }
    }
}

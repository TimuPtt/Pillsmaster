using Newtonsoft.Json;

using PillsmasterClient.Models.PlanModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillsmasterClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Routing.RegisterRoute(nameof(PlanPage), typeof(PlanPage));
            var userMedicine = e.Item as PlanInf;
            var json = JsonConvert.SerializeObject(userMedicine);
            await Shell.Current.GoToAsync($"{nameof(PlanPage)}?Content={json}");
        }
    }
}
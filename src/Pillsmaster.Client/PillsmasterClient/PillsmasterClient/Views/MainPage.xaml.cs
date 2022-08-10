using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PillsmasterClient.Models.UserMedicineModels;
using PillsmasterClient.ViewModels;
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
            var userMedicine = e.Item as UserMedicine;
            var json = JsonConvert.SerializeObject(userMedicine);
            await Shell.Current.GoToAsync($"{nameof(PlanPage)}?Content={json}");
        }
    }
}
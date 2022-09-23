using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Services;
using Refit;
using Xamarin.Forms;

namespace PillsmasterClient
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<IAuthenticationService, AuthenticationService>();
            DependencyService.Register<INotificationService, NotificationService>();
            DependencyService.Register<IPlanService, PlanService>();
            DependencyService.Register<ITakeService, TakeService>();
            DependencyService.Register<IPlanInfService, PlanInfService>();
            DependencyService.Register<IMedicineService, MedicineService>();
            DependencyService.Register<IUserMedicineService, UserMedicineService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            if (Current.Properties.ContainsKey("oauth_token") &&  Current.Properties["oauth_token"] != null)
            {
                Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

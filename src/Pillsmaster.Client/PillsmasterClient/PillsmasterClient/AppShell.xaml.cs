using PillsmasterClient.ViewModels;
using PillsmasterClient.Views;
using System;
using System.Collections.Generic;
using PillsmasterClient.Views.AddMedicineSequence;
using Xamarin.Forms;

namespace PillsmasterClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(AddMedicinePage), typeof(AddMedicinePage));
            Routing.RegisterRoute(nameof(AddMedicationDayPage), typeof(AddMedicationDayPage));
            Routing.RegisterRoute(nameof(AddPlanPage), typeof(AddPlanPage));
        }
    }
}

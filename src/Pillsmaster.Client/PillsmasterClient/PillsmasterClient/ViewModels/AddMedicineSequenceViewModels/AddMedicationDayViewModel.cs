using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.MedicineModels;
using PillsmasterClient.Models.TakeModels;
using PillsmasterClient.Views.AddMedicineSequence;
using Xamarin.Forms;

namespace PillsmasterClient.ViewModels.AddMedicineSequenceViewModels
{
    [QueryProperty(nameof(UserMedicineRequest), nameof(UserMedicineRequest))]
    public class AddMedicationDayViewModel : BaseViewModel
    {
        public IAsyncCommand GoNextAsyncCommand { get; }
        public string UserMedicineRequest { get; set; }

        private List<TakeViewModel> takeTimes;

        public List<TakeViewModel> TakeTimes
        {
            get => takeTimes;
            set => SetProperty(ref takeTimes, value);
        }

        private int takesPerDay;
        public int TakesPerDay
        {
            get => takesPerDay;
            set
            {
                SetProperty(ref takesPerDay, value);
                if (value > 0)
                {
                    var defaultTakeTimes = new List<TakeViewModel>();
                    for (var i = 0; i < value; i++)
                    {
                        defaultTakeTimes.Add(new TakeViewModel()
                        {
                            TakeTime = new TimeSpan(0,0,0)
                        });
                    }
                    TakeTimes = defaultTakeTimes;
                }
            } 
        }

        private double countPerTake;
        public double CountPerTake
        {
            get => countPerTake;
            set => SetProperty(ref countPerTake, value);
        }

        public AddMedicationDayViewModel()
        {
            GoNextAsyncCommand = new AsyncCommand(GoNextClicked);
        }

        public async Task GoNextClicked()
        {
            var takeRequests = new List<TakeRequest>();

            foreach (var takeTime in TakeTimes)
            {
                takeRequests.Add(new TakeRequest()
                {
                    TakeTime = new DateTime(1, 1, 1, takeTime.TakeTime.Hours, takeTime.TakeTime.Minutes, 0)
                });
            }

            var medicationDayRequest = new MedicationDayRequest()
            {
                CountPerTake = CountPerTake,
                TakesPerDay = TakesPerDay
            };

            var takeRequestsJson = JsonConvert.SerializeObject(takeRequests);
            var medicationDayRequestJson = JsonConvert.SerializeObject(medicationDayRequest);

            await Shell.Current.GoToAsync(
                $"{nameof(AddPlanPage)}?TakesRequestJson={takeRequestsJson}&UserMedicineRequestJson={UserMedicineRequest}&MedicationDayRequestJson={medicationDayRequestJson}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.MedicineModels;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.TakeModels;
using PillsmasterClient.Models.UserMedicineModels;
using PillsmasterClient.Views;
using Xamarin.Forms;

namespace PillsmasterClient.ViewModels.AddMedicineSequenceViewModels
{
    [QueryProperty(nameof(UserMedicineRequestJson), nameof(UserMedicineRequestJson)), QueryProperty(nameof(TakesRequestJson), nameof(TakesRequestJson)), QueryProperty(nameof(MedicationDayRequestJson), nameof(MedicationDayRequestJson))]
   // [QueryProperty(nameof(TakesRequestJson), nameof(TakesRequestJson))]
   // [QueryProperty(nameof(MedicationDayRequestJson), nameof(MedicationDayRequestJson))]
    public class AddPlanViewModel : BaseViewModel
   {
        private readonly IPlanService _planService;
        private readonly IUserMedicineService _userMedicineService;
        private readonly INotificationService _notificationService;

        public IAsyncCommand DoneAsyncCommand { get; }

        public string UserMedicineRequestJson { get; set; }
        public string TakesRequestJson { get; set; }
        public string MedicationDayRequestJson { get; set; }

        public MedicationDayRequest MedicationDayRequest { get; set; }
        private List<TakeRequest> TakesRequest { get; set; }
        public UserMedecineRequest UserMedicineRequest { get; set; }

        private int medicineCount;

        public int MedicineCount
        {
            get => medicineCount;
            set => SetProperty(ref medicineCount, value);
        }

        private int duration;

        public int Duration
        {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        public bool IsEnoughToFinish { get; set; } = true;

        private string foodStatus;

        public string FoodStatus
        {
            get => foodStatus;
            set => SetProperty(ref foodStatus, value);
        }

        public bool IsFoodDependent { get; set; } = false;

        public int PlanStatusId { get; set; } = 1;

        public int TakesCount { get; set; } = 1;


        public AddPlanViewModel()
        {
            DoneAsyncCommand = new AsyncCommand(OnDoneClicked);
            _planService = DependencyService.Get<IPlanService>();
            _userMedicineService = DependencyService.Get<IUserMedicineService>();
            _notificationService = DependencyService.Get<INotificationService>();
        }

        public async Task OnDoneClicked()
        {
            UserMedicineRequest = JsonConvert.DeserializeObject<UserMedecineRequest>(UserMedicineRequestJson);
            MedicationDayRequest = JsonConvert.DeserializeObject<MedicationDayRequest>(MedicationDayRequestJson);
            TakesRequest = JsonConvert.DeserializeObject<List<TakeRequest>>(TakesRequestJson);

            var planRequest = new PlanRequest()
            {
                MedicineCount = MedicineCount, 
                Duration = Duration,
                FoodStatusId = 1,
                IsEnoughToFinish = IsEnoughToFinish,
                IsFoodDependent = IsFoodDependent,
                MedicationDay = MedicationDayRequest,
                NextTakeTime = CalculateNextTakeDateTime(),
                PlanStatusId = 1,
                StartDate = DateTime.Now,
                Takes = TakesRequest
            };

            _notificationService.SetNextNotification(UserMedicineRequest.TradeName, planRequest.MedicationDay.CountPerTake, planRequest.NextTakeTime);

            var userMedicine = await _userMedicineService.PostUserMedicine(UserMedicineRequest);

            planRequest.UserMedicineId = userMedicine.Id;

            var plan = await _planService.PostPlanAsync(planRequest);

            await Shell.Current.DisplayAlert("Успешно!", $"Лекарство {UserMedicineRequest.TradeName} добавлено",
                "На главную");

            await Shell.Current.GoToAsync($"///{nameof(MainPage)}")
                .ConfigureAwait(false);
        }

        private DateTime CalculateNextTakeDateTime()
        {
            var startDate = DateTime.Now;
            var minTakeTime = TakesRequest.Select(x => x.TakeTime).Min().TimeOfDay;
            if (startDate.TimeOfDay < minTakeTime)
            {
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, minTakeTime.Hours,
                    minTakeTime.Minutes, 0);
                return startDate;
            }

            return DateTime.MinValue;
        }
    }
}

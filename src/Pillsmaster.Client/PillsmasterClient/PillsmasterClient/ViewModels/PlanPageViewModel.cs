using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

using Newtonsoft.Json;
using PillsmasterClient.Common.Exceptions;
using PillsmasterClient.Common.Interfaces.Services;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.TakeModels;
using PillsmasterClient.Models.UserMedicineModels;

using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace PillsmasterClient.ViewModels
{
    [QueryProperty(nameof(Content), nameof(Content))]
    public class PlanPageViewModel : BaseViewModel
    {
        private readonly IPlanService _planService;
        private readonly INotificationService _notificationService;
        private readonly ITakeService _takeService;
        
        private string content = "";

        public IAsyncCommand RefreshCommand { get; }
        public ICommand NotifyCommand { get; }
        public ICommand TakePillCommand { get; }

        public string Content
        {
            get => content;
            set
            {
                content = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
                PlanInf = JsonConvert.DeserializeObject<PlanInf>(content);
                Title = PlanInf?.TradeName;
            }
        }

        private PlanInf planInf;
        public PlanInf PlanInf
        {
            get => planInf;
            set => SetProperty(ref planInf, value);
        }

        private Plan plan;

        public Plan Plan
        {
            get => plan;
            set => SetProperty(ref plan, value);
        }

        public PlanPageViewModel()
        {
            _planService = DependencyService.Get<IPlanService>();
            _notificationService = DependencyService.Get<INotificationService>();
            _takeService = DependencyService.Get<ITakeService>();
            Plan = new Plan();
            RefreshCommand = new AsyncCommand(Refresh);
            NotifyCommand = new Command(SetNotification);
            TakePillCommand = new Command(TakePill);
            Task.Run(async () => { await Refresh(); });
        }

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);

            var plan = new Plan(); 

            plan = await _planService.GetPlanAsync(PlanInf.Id);

            if (plan != null)
            {
                Plan = plan;
                IsBusy = false;
                return;
            }

            await Shell.Current.DisplayAlert("Ошибка", "Не удалось заграузить план", "Ок");
            IsBusy = false;
        }


        public void TakePill()
        {
            try
            {
                _takeService.TakePill(Plan);
                OnPropertyChanged("Plan");

                UpdatePlan();
                SetNotification();
            }
            catch (NotEnoughMedicineException ex)
            {
                Shell.Current.DisplayAlert("Не достаточно лекарства",
                    "У Вас недостаточно лекарства для осуществления приема", "Ок");
            }
            catch (EarlyTakeException ex)
            {
                if (Shell.Current.DisplayAlert("Слишком рано для приема",
                        $"Следующий прием в {Plan.NextTakeTime}, принять сейчас?", "Принять", "Нет").Result)
                {
                    _takeService.ForceTakePill(Plan);
                    OnPropertyChanged("Plan");

                    UpdatePlan();
                    SetNotification();
                }
            }

        }

        private void UpdatePlan()
        {
            var takeRequests = new List<TakeRequest>();

            foreach (var take in plan.Takes)
            {
                takeRequests.Add(new TakeRequest()
                {
                    TakeTime = take.TakeTime
                });
            }

            var planRequest = new UpdatePlanAtTakeRequest()
            {
                Id = plan.Id,
                MedicineCount = plan.MedicineCount,
                NextTakeTime = plan.NextTakeTime,
            };

            _planService.UpdatePlanAtTakeAsync(planRequest);
        }

        private void SetNotification()
        {
            _notificationService.SetNextNotification(PlanInf.TradeName, Plan.MedicationDay.CountPerTake, Plan.NextTakeTime);
        }
    }
}

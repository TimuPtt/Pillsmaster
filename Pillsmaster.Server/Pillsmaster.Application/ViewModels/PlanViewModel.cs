using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class PlanViewModel
    {
        public int MedicineCount { get; set; }

        public int Duration { get; set; }

        public bool IsEnoughToFinish { get; set; }

        public string? FoodStatus { get; set; }

        public bool IsFoodDependent { get; set; }

        public string? PlanStatus { get; set; }

        public MedicationDayViewModel MedicationDayVm { get; set; }

        public DateTime? LastTakeTime { get; set; }

        public List<TakeViewModel> Takes { get; set; }
    }
}

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

        public int TakesCount { get; set; }

        public MedicationDayViewModel MedicationDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? NextTakeTime { get; set; }

        public List<TakeViewModel> Takes { get; set; }
    }
}

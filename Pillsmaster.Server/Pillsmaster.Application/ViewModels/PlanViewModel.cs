using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class PlanViewModel
    {
        public Guid UserId { get; set; }

        public int MedicineCount { get; set; }

        public int Duration { get; set; }

        public bool IsEnoughToFinish { get; set; }

        public string? FoodStatus { get; set; }

        public bool IsFoodDependent { get; set; }

        public string? PlanStatus { get; set; }

        public Guid MedicationDayId { get; set; }

        public DateTime? LastTakeTime { get; set; }

        public Queue<Take> Takes { get; set; }
    }
}

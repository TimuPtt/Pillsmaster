using System.ComponentModel.DataAnnotations;

namespace Pillsmaster.Domain.Models
{
    public class Plan
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int MedicineCount { get; set; }

        public int Duration { get; set; }

        public bool IsEnoughToFinish { get; set; }

        public string? FoodStatus { get; set; }

        public bool IsFoodDependent { get; set; }

        public string? PlanStatus { get; set; }

        public int TakesCount { get; set; }

        public Guid MedicationDayId { get; set; }

        public MedicationDay MedicationDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? NextTakeTime { get; set; }

        public List<Take>? Takes { get; set; } 
    }
}

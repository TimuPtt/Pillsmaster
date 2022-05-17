
namespace Pillsmaster.Domain.Models
{
    public class Plan
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int MedicineCount { get; set; }

        public int Duration { get; set; }

        public bool IsEnoughToFinish { get; set; }

        public string FoodStatus { get; set; }

        public string PlanStatus { get; set; }

        public Guid MedicationDayId { get; set; }

        public MedicationDay MedicationDay { get; set; }

        public Guid TakeId { get; set; }

        public ICollection<Take> Takes { get; set; } 
    }
}

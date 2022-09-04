
namespace Pillsmaster.Domain.Models
{
    public class Plan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserMedicineId { get; set; }
        public Guid MedicationDayId { get; set; }
        public int MedicineCount { get; set; }
        public int Duration { get; set; }
        public bool IsEnoughToFinish { get; set; }
        public int FoodStatusId { get; set; }
        public FoodStatus? FoodStatus { get; set; }
        public bool IsFoodDependent { get; set; }
        public int PlanStatusId { get; set; }
        public PlanStatus? PlanStatus { get; set; }
        public int TakesCount { get; set; }
        public UserMedicine? UserMedicine { get; set; }
        public MedicationDay? MedicationDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? NextTakeTime { get; set; }
        public List<Take>? Takes { get; set; }
    }
}

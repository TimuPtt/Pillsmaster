using System;
using System.Collections.Generic;
using System.Text;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.TakeModels;

namespace PillsmasterClient.Models.PlanModels
{
    public class PlanRequest
    {
        public Guid UserMedicineId { get; set; }
        public int MedicineCount { get; set; }
        public int Duration { get; set; }
        public bool IsEnoughToFinish { get; set; }
        public int FoodStatusId { get; set; }
        public bool IsFoodDependent { get; set; }
        public int PlanStatusId { get; set; }
        public MedicationDayRequest MedicationDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextTakeTime { get; set; }
        public List<TakeRequest> Takes { get; set; }
    }
}

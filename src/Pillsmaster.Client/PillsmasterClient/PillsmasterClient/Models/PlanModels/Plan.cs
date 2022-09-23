using System;
using System.Collections.Generic;
using System.Text;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.TakeModels;
using PillsmasterClient.Models.UserMedicineModels;
using PillsmasterClient.ViewModels.AddMedicineSequenceViewModels;

namespace PillsmasterClient.Models.PlanModels
{
    public class Plan
    {
        public Guid Id { get; set; }
        public int MedicineCount { get; set; }
        public int Duration { get; set; }
        public bool IsEnoughToFinish { get; set; }
        public string FoodStatus { get; set; }
        public bool IsFoodDependent { get; set; }
        public string PlanStatus { get; set; }
        public int TakesCount { get; set; }
        public MedicationDay MedicationDay { get; set; }
        public UserMedicine UserMedicine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextTakeTime { get; set; }
        public List<Take> Takes { get; set; }
    }
}

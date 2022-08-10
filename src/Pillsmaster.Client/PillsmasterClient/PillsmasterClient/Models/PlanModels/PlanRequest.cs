using System;
using System.Collections.Generic;
using System.Text;
using PillsmasterClient.Models.MedicationDayModels;
using PillsmasterClient.Models.TakeModels;

namespace PillsmasterClient.Models.PlanModels
{
    public class PlanRequest
    {
        public int MedicineCount { get; set; }

        public int Duration { get; set; }

        public bool IsEnoughToFinish { get; set; }

        public string FoodStatus { get; set; }

        public bool IsFoodDependent { get; set; }

        public string PlanStatus { get; set; }

        public int TakesCount { get; set; }

        public MedicationDayRequest MedicationDay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime NextTakeTime { get; set; }

        public List<TakeRequest> Takes { get; set; }
    }
}

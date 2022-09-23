using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.PlanModels
{
    public class UpdatePlanAtTakeRequest
    {
        public Guid Id { get; set; }
        public int MedicineCount { get; set; }
        public DateTime NextTakeTime { get; set; }
    }
}

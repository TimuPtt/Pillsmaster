using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.PlanModels
{
    public class PlanInf
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public int ActiveIngredientCount { get; set; }
        public int PharmaTypeId { get; set; }
        public string PharmaType { get; set; }
        public int TakesPerDay { get; set; }
        public string Image { get; set; } = String.Empty;
        public DateTime NextTakeTime { get; set; }
    }
}

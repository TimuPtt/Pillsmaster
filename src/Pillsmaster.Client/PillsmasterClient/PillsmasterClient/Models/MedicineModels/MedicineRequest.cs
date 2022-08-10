using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.MedicineModels
{
    public class MedicineRequest
    {
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }
    }
}

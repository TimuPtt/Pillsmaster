using System;
using Newtonsoft.Json;

namespace PillsmasterClient.Models.MedicineModels
{
    public class Medicine
    {
        public Guid MedicineId { get; set; }

        public string TradeName { get; set; }

        public string InternationalName { get; set; } = string.Empty;

        public string PharmaType { get; set; } = string.Empty;

        public int ActiveIngredientCount { get; set; }

        public string Image { get; set; } = string.Empty;
    }
}

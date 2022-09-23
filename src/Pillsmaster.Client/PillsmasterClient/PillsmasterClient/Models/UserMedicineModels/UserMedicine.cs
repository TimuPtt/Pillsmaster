using System;
using Newtonsoft.Json;
using PillsmasterClient.Models.MedicineModels;

namespace PillsmasterClient.Models.UserMedicineModels
{
    public class UserMedicine
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public int PharmaTypeId { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }
    }
}

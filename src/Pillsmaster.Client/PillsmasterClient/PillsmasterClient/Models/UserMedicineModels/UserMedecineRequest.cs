using System;
using System.Security.Cryptography.X509Certificates;
using PillsmasterClient.Models.MedicineModels;

namespace PillsmasterClient.Models.UserMedicineModels
{
    public class UserMedecineRequest
    {
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public int PharmaTypeId { get; set; }
        public int ActiveIngredientCount { get; set; }
    }
}

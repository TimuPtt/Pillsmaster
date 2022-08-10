using System;

using PillsmasterClient.Models.MedicineModels;

namespace PillsmasterClient.Models.UserMedicineModels
{
    public class UserMedecineRequest
    {
        public Guid UserPlanId { get; set; }

        public Guid MedicineId { get; set; }
    }
}

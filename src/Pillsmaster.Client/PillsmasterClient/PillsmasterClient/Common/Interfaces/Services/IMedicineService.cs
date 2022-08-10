using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PillsmasterClient.Models.MedicineModels;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IMedicineService
    {
        Task<Guid> PostMedicineAsync(MedicineRequest medicineRequest);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PillsmasterClient.Models.PlanModels;
using PillsmasterClient.Models.UserMedicineModels;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IPlanInfService
    {
        Task<List<PlanInf>> GetPlanInfAsync();
    }
}
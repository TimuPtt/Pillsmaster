using System;
using System.Threading.Tasks;
using PillsmasterClient.Models.PlanModels;

namespace PillsmasterClient.Common.Interfaces.Services
{
    public interface IPlanService
    {
        Task<Plan> GetPlanAsync(Guid planId);
        Task<Plan> UpdatePlanAsync(PlanRequest request);
        Task<Plan> UpdatePlanAtTakeAsync(UpdatePlanAtTakeRequest request);
        Task DeletePlanAsync(Guid planId);
        Task<Plan> PostPlanAsync(PlanRequest request); 
    }
}
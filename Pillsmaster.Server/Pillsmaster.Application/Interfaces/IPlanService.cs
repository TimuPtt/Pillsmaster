using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    public interface IPlanService
    {
        Task<Plan> CreatePlan(Guid userId, PlanViewModel planVm, CancellationToken cancellationToken);
        Task<Plan> ReadPlan(Guid planId, CancellationToken cancellationToken);
        Task<Plan> UpdatePlan(Guid planId, PlanViewModel planVm, CancellationToken cancellationToken);
        Task DeletePlan(Guid planId, CancellationToken cancellationToken);
    }
}

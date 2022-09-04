using System.Data.Common;
using MediatR;
using Pillsmaster.Application.ViewModels;

namespace Pillsmaster.Application.Plans.Queries.GetPlan;

public class GetPlanQuery : IRequest<PlanViewModel>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
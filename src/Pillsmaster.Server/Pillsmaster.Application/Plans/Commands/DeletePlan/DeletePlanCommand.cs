using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.DeletePlan;

public class DeletePlanCommand : IRequest<Plan>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
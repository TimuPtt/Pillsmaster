using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.UpdatePlanAtTake;

public class UpdatePlanAtTakeCommand : IRequest<Plan>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int MedicineCount { get; set; }
    public DateTime NextTakeTime { get; set; }
}
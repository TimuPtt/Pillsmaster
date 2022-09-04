using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommand : IRequest<Plan>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int MedicineCount { get; set; }
    public int Duration { get; set; }
    public bool IsEnoughToFinish { get; set; }
    public int FoodStatusId { get; set; }
    public bool IsFoodDependent { get; set; }
    public int PlanStatusId { get; set; }
    public int CountPerTake { get; set; }
    public int TakesPerDay { get; set; }
    public int TakesCount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? NextTakeTime { get; set; }
}
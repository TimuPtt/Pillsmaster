using MediatR;
using Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommand : IRequest<Plan>
{
    public Guid UserMedicineId { get; set; }
    public Guid UserId { get; set; }
    public int MedicineCount { get; set; }
    public int Duration { get; set; }
    public bool IsEnoughToFinish { get; set; }
    public int FoodStatusId { get; set; }
    public bool IsFoodDependent { get; set; }
    public int PlanStatusId { get; set; }
    public MedicationDayDto? MedicationDay { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? NextTakeTime { get; set; }
    public List<TakeDto>? Takes { get; set; }
}
using MediatR;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommandHandler : BaseCommandHandler,
    IRequestHandler<CreatePlanCommand, Plan>
{
    public CreatePlanCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<Plan> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = new Plan()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            MedicineCount = request.MedicineCount,
            Duration = request.Duration,
            IsEnoughToFinish = request.IsEnoughToFinish,
            FoodStatusId = request.FoodStatusId,
            IsFoodDependent = request.IsFoodDependent,
            PlanStatusId = request.PlanStatusId,
            UserMedicineId = request.UserMedicineId,
            MedicationDay = new MedicationDay()
            {
                Id = Guid.NewGuid(),
                CountPerTake = request.MedicationDay!.CountPerTake,
                TakesPerDay = request.MedicationDay!.TakesPerDay
            },
            StartDate = request.StartDate,
            NextTakeTime = request.NextTakeTime,
            TakesCount = CalculateTakes(request.Duration, request.MedicationDay.TakesPerDay),
        };

        plan.Takes = new List<Take>();

        foreach (var takeDto in request.Takes)
        {
            plan.Takes.Add(
                new Take()
                {
                    Id = Guid.NewGuid(),
                    PlanId = plan.Id,
                    TakeTime = takeDto.TakeTime
                });
        }

        await _dbContext.Plans.AddAsync(plan, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return plan;
    }
    
    private int CalculateTakes(int duration, int takesPerDay)
    {
        return takesPerDay * duration;
    }
}
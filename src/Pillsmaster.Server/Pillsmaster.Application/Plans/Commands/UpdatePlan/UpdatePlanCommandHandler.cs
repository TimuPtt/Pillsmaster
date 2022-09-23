using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommandHandler : BaseCommandHandler,
    IRequestHandler<UpdatePlanCommand, Plan>
{
    public UpdatePlanCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<Plan> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plans
            .Include(plan => plan.MedicationDay)
            .Include(plan => plan.Takes)
            .FirstOrDefaultAsync(plan => plan.Id == request.Id, cancellationToken)!;

        if (entity is null || request.UserId != entity.UserId)
            throw new NotFoundException(typeof(Plan), request.Id);

        entity.MedicineCount = request.MedicineCount;
        entity.Duration = request.Duration;
        entity.IsEnoughToFinish = request.IsEnoughToFinish;
        entity.FoodStatusId = request.FoodStatusId;
        entity.PlanStatusId = request.PlanStatusId;
        entity.MedicationDay!.TakesPerDay = request.TakesPerDay;
        entity.MedicationDay!.CountPerTake = request.CountPerTake;
        entity.StartDate = request.StartDate;
        entity.TakesCount = request.TakesCount;
        entity.NextTakeTime = request.NextTakeTime;

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return entity;
    }
}
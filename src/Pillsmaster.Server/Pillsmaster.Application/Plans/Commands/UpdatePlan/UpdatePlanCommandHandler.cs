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
        var entitie = await _dbContext.Plans
            .Include(plan => plan.MedicationDay)
            .Include(plan => plan.Takes)
            .FirstOrDefaultAsync(plan => plan.Id == request.Id, cancellationToken)!;

        if (entitie is null || request.UserId != entitie.UserId)
            throw new NotFoundException(typeof(Plan), request.Id);

        entitie.MedicineCount = request.MedicineCount;
        entitie.Duration = request.Duration;
        entitie.IsEnoughToFinish = request.IsEnoughToFinish;
        entitie.FoodStatusId = request.FoodStatusId;
        entitie.PlanStatusId = request.PlanStatusId;
        entitie.MedicationDay!.TakesPerDay = request.TakesPerDay;
        entitie.MedicationDay!.CountPerTake = request.CountPerTake;
        entitie.StartDate = request.StartDate;
        entitie.TakesCount = request.TakesCount;
        entitie.NextTakeTime = request.NextTakeTime;

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return entitie;
    }
}
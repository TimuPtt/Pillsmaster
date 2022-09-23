using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.UpdatePlanAtTake;

public class UpdatePlanAtTakeCommandHandler : BaseCommandHandler,
    IRequestHandler<UpdatePlanAtTakeCommand, Plan>
{
    public UpdatePlanAtTakeCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<Plan> Handle(UpdatePlanAtTakeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plans
            .FirstOrDefaultAsync(plan => plan.Id == request.Id, cancellationToken);

        if (entity is null || request.UserId != entity.UserId)
            throw new NotFoundException(typeof(Plan), request.Id);

        entity.MedicineCount = request.MedicineCount;
        entity.NextTakeTime = request.NextTakeTime;

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return entity;
    }
}
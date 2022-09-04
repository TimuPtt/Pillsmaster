using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Commands.DeletePlan;

public class DeletePlanCommandHandler : BaseCommandHandler,
    IRequestHandler<DeletePlanCommand, Plan>
{
    public DeletePlanCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<Plan> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        var entitie = await _dbContext.Plans
            .Include(plan => plan.MedicationDay)
            .Include(plan => plan.Takes)
            .FirstOrDefaultAsync(plan => plan.Id == request.Id);

        if (entitie is null || entitie.UserId != request.UserId)
            throw new NotFoundException(typeof(Plan), request.Id);

        _dbContext.Plans.Remove(entitie);

        return entitie;
    }
}
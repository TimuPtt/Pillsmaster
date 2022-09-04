using AutoMapper;
using MediatR;

using Microsoft.EntityFrameworkCore;

using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Queries.GetPlan;

public class GetPlanQueryHandler : BaseQueryHandler,
    IRequestHandler<GetPlanQuery, PlanViewModel>
{
    public GetPlanQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<PlanViewModel> Handle(GetPlanQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Plans
            .Include(plan => plan.MedicationDay)
            .Include(plan => plan.UserMedicine)
            .Include(plan => plan.Takes)
            .Include(plan => plan.FoodStatus)
            .Include(plan => plan.PlanStatus)
            .FirstOrDefaultAsync(plan =>
                plan.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId)
            throw new NotFoundException(typeof(Plan), request.Id);

        return _mapper.Map<PlanViewModel>(entity);
    }
}
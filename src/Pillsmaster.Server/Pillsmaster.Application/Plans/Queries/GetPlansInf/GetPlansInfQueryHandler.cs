using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Plans.Queries.GetPlansInf;

public class GetPlansInfQueryHandler : BaseQueryHandler,
    IRequestHandler<GetPlansInfQuery, IEnumerable<PlanInfoViewModel>>
{
    public GetPlansInfQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper) 
        : base(dbContext, mapper) { }

    public async Task<IEnumerable<PlanInfoViewModel>> Handle(GetPlansInfQuery request, 
        CancellationToken cancellationToken)
    {
        var entities = await _dbContext.Plans
            .Where(plan => plan.UserId == request.UserId)
            .Include(plan => plan.UserMedicine)
            .Include(plan => plan.MedicationDay)
            .Include(plan => plan.UserMedicine.PharmaType)
            .ToListAsync(cancellationToken);

        if (!entities.Any())
            throw new NotFoundException(typeof(Plan), request.UserId);

        var planInfos = _mapper.Map<List<Plan>, List<PlanInfoViewModel>>(entities);

        return planInfos;
    }
}
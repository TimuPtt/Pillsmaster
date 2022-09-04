using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.Medicines.Queries.GetMedicine;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Queries.GetUserMedicines;

public class GetUserMedicinesQueryHandler : BaseQueryHandler,
    IRequestHandler<GetUserMedicineQuery, IEnumerable<UserMedicineViewModel>>
{
    public GetUserMedicinesQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<IEnumerable<UserMedicineViewModel>> Handle(GetUserMedicineQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.UserMedicines
            .Where(userMedicine => userMedicine.UserId == request.UserId)
            .Include(userMedicine => userMedicine.PharmaType)
            .ToListAsync(cancellationToken);

        if (!entities.Any())
            throw new NotFoundException(typeof(UserMedicine), request.UserId);

        var userMedicines = _mapper.Map<List<UserMedicine>, List<UserMedicineViewModel>>(entities);

        return userMedicines;
    }
}
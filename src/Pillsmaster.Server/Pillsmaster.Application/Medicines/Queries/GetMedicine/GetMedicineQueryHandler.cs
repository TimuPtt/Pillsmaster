using AutoMapper;
using MediatR;

using Microsoft.EntityFrameworkCore;

using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Medicines.Queries.GetMedicine;

public class GetMedicineQueryHandler : BaseQueryHandler,
    IRequestHandler<GetMedicineQuery, MedicineViewModel>
{
    public GetMedicineQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<MedicineViewModel> Handle(GetMedicineQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Medicines
            .FirstOrDefaultAsync(medicine =>
                medicine.TradeName == request.TradeName, cancellationToken);

        if (entity == null)
            throw new NotFoundException(typeof(Medicine), request.TradeName);

        return _mapper.Map<MedicineViewModel>(entity);
    }
}
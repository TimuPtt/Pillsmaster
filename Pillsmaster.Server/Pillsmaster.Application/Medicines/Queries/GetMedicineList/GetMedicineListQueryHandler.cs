using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Interfaces;

namespace Pillsmaster.Application.Medicines.Queries.GetMedicineList
{
    internal class GetMedicineListQueryHandler
        : IRequestHandler<GetMedicineListQuery, MedicineListVm>
    {
        private readonly IPillsmasterDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMedicineListQueryHandler(IPillsmasterDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MedicineListVm> Handle(GetMedicineListQuery request,
            CancellationToken cancellationToken)
        {
            var medicinesQuery = await _dbContext.Medicines
                .Where(medicine => medicine.TradeName == request.TradeName)
                .ProjectTo<MedicineLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MedicineListVm { Medicines = medicinesQuery };
        }
    }
}

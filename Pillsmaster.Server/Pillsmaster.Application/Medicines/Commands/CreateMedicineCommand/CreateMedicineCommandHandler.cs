using MediatR;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Medicines.Commands.CreateMedicineCommand
{
    internal class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommand, Guid>
    {
        private readonly IPillsmasterDbContext _dbContext;

        public CreateMedicineCommandHandler(IPillsmasterDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateMedicineCommand request,
            CancellationToken cancellationToken)
        {
            var medicine = new Medicine
            {   
                MedicineId = Guid.NewGuid(),
                TradeName = request.TradeName,
                InternationalName = request.InternationalName,
                PharmaType = request.PharmaType,
                ActiveIngredientCount = request.ActiveIngredientCount
            };

            await _dbContext.Medicines.AddAsync(medicine, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return medicine.MedicineId;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Medicines.Commands.UpdateMedicineCommand
{
    internal class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommand>
    {
        private readonly IPillsmasterDbContext _dbContext;

        public UpdateMedicineCommandHandler(IPillsmasterDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateMedicineCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Medicines.FirstOrDefaultAsync(medicine =>
                    medicine.MedicineId == request.MedicineId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Medicine), request.MedicineId);
            }

            entity.TradeName = request.TradeName;
            entity.InternationalName = request.InternationalName;
            entity.ActiveIngredientCount = request.ActiveIngredientCount;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

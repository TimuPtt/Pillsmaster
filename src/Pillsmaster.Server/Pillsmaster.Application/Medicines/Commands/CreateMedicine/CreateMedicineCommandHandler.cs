using MediatR;
using Pillsmaster.Application.Commands.Medicines.CreateMedicine;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateMedicineCommand, Medicine>
{
    public CreateMedicineCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }
    
    public async Task<Medicine> Handle(CreateMedicineCommand request,
        CancellationToken cancellationToken)
    {
        var medicine = new Medicine()
        {
            Id = Guid.NewGuid(),
            TradeName = request.TradeName,
            InternationalName = request.InternationalName,
            PharmaTypeId = request.PharmaTypeId,
            ActiveIngredientCount = request.ActiveIngredientCount
        };
        
        await _dbContext.Medicines.AddAsync(medicine, cancellationToken); 
        await _dbContext.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return medicine;
    }
}
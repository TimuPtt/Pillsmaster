using MediatR;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;

public class CreateUserMedicineCommandHandler : BaseCommandHandler, 
    IRequestHandler<CreateUserMedicineCommand, UserMedicine>
{
    public CreateUserMedicineCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<UserMedicine> Handle(CreateUserMedicineCommand request, 
        CancellationToken cancellationToken)
    {
        var userMedicine = new UserMedicine()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            TradeName = request.TradeName,
            InternationalName = request.InternationalName,
            PharmaTypeId = request.PharmaTypeId,
            ActiveIngredientCount = request.ActiveIngredientCount
        };

        await _dbContext.UserMedicines.AddAsync(userMedicine, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(false);

        return userMedicine;
    }
}
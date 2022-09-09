using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;

public class UpdateUserMedicineCommandHandler : BaseCommandHandler,
    IRequestHandler<UpdateUserMedicineCommand, UserMedicine>
{
    public UpdateUserMedicineCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<UserMedicine> Handle(UpdateUserMedicineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.UserMedicines.FirstOrDefaultAsync(userMedicine =>
            userMedicine.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(typeof(UserMedicine), request.Id);
        }

        entity.InternationalName = request.InternationalName;
        entity.TradeName = request.TradeName;
        entity.PharmaTypeId = request.PharmaTypeId;
        entity.ActiveIngredientCount = request.ActiveIngredientCount;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
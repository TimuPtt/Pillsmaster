using MediatR;
using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Common;
using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Commands.DeleteUserMedicine;

public class DeleteUserMedicineCommandHandler : BaseCommandHandler, 
    IRequestHandler<DeleteUserMedicineCommand, UserMedicine>
{
    public DeleteUserMedicineCommandHandler(IPillsmasterDbContext dbContext) : base(dbContext) { }

    public async Task<UserMedicine> Handle(DeleteUserMedicineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.UserMedicines.FirstOrDefaultAsync(userMedicine =>
            userMedicine.Id == request.Id, cancellationToken);

        if (entity is null || entity.UserId != request.UserId)
            throw new NotFoundException(typeof(UserMedicine), request.Id);

        _dbContext.UserMedicines.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        return entity;
    }
}
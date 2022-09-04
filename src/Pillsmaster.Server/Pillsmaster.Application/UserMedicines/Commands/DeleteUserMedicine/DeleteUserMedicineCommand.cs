using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Commands.DeleteUserMedicine;

public class DeleteUserMedicineCommand : IRequest<UserMedicine>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
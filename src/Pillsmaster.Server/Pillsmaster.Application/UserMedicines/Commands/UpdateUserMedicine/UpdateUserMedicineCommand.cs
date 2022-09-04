using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;

public class UpdateUserMedicineCommand : IRequest<UserMedicine>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int PharmaTypeId { get; set; }
    public int ActiveIngredientCount { get; set; }
}
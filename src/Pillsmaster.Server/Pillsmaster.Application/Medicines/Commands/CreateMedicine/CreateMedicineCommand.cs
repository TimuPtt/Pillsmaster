using MediatR;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Commands.Medicines.CreateMedicine;

public class CreateMedicineCommand : IRequest<Medicine>
{
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int PharmaTypeId { get; set; }
    public int ActiveIngredientCount { get; set; }
}
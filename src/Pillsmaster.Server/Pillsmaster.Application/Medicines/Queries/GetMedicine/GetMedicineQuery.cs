using MediatR;
using Pillsmaster.Application.ViewModels;

namespace Pillsmaster.Application.Medicines.Queries.GetMedicine;

public class GetMedicineQuery : IRequest<MedicineViewModel>
{
    public string TradeName { get; set; }
}
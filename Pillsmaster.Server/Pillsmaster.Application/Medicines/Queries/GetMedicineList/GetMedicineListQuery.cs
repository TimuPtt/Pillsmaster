using MediatR;

namespace Pillsmaster.Application.Medicines.Queries.GetMedicineList
{
    internal class GetMedicineListQuery : IRequest<MedicineListVm>
    {
        public string TradeName { get; set; }
    }
}

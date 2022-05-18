using MediatR;

namespace Pillsmaster.Application.Medicines.Commands.UpdateMedicineCommand
{
    internal class UpdateMedicineCommand : IRequest
    {
        public Guid MedicineId { get; set; }

        public string TradeName { get; set; }

        public string InternationalName { get; set; }

        public int ActiveIngredientCount { get; set; }
    }
}

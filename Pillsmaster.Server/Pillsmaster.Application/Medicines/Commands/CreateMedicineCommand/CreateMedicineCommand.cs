using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Pillsmaster.Application.Medicines.Commands.CreateMedicineCommand
{
    internal class CreateMedicineCommand : IRequest<Guid>
    {
        public Guid MedicineId { get; set; }

        public string TradeName { get; set; }

        public string InternationalName { get; set; }

        public string PharmaType { get; set; }

        public int ActiveIngredientCount { get; set; }
    }
}

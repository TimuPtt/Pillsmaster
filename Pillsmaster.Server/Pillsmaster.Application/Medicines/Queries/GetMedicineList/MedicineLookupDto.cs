using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Medicines.Queries.GetMedicineList
{
    internal class MedicineLookupDto : IMapWith<Medicine>
    {
        public Guid MedicineId { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Medicine, MedicineLookupDto>();
        }
    }
}

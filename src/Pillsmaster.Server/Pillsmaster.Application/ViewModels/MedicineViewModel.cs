using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class MedicineViewModel : IMapWith<Medicine>
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Medicine, MedicineViewModel>()
                .ForMember(medicineVm => medicineVm.PharmaType,
                opt => 
                    opt.MapFrom(medicnie => medicnie.PharmaType.Type));
        }
    }
}

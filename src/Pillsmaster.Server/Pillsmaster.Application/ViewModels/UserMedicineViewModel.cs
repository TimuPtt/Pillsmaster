using AutoMapper;

using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class UserMedicineViewModel : IMapWith<UserMedicine>
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; }
        public int PharmaTypeId { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserMedicine, UserMedicineViewModel>()
                .ForMember(userMedicineVm => userMedicineVm.PharmaType,
                    opt =>
                        opt.MapFrom(medicine => medicine.PharmaType.Type))
                .ForMember(userMedicineVm => userMedicineVm.PharmaTypeId,
                    opt =>
                        opt.MapFrom(medicine => medicine.PharmaType.Id));
        }
    }
}

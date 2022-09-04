using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.UserMedicines.Commands.CreateUserMedicine;

namespace Pillsmaster.API.Dtos;

public class CreateUserMedicineDto : IMapWith<CreateUserMedicineCommand>
{
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int PharmaTypeId { get; set; }
    public int ActiveIngredientCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserMedicineDto, CreateUserMedicineCommand>();
    }
}
using AutoMapper;
using Pillsmaster.Application.Commands.Medicines.CreateMedicine;
using Pillsmaster.Application.Common.Mappings;

namespace Pillsmaster.API.Dtos;

public class CreateMedicineDto : IMapWith<CreateMedicineCommand>
{
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int PharmaTypeId { get; set; }
    public int ActiveIngredientCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMedicineDto, CreateMedicineCommand>();
    }
}
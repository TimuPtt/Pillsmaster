using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.UserMedicines.Commands.UpdateUserMedicine;

namespace Pillsmaster.API.Dtos;

public class UpdateUserMedicineDto : IMapWith<UpdateUserMedicineCommand>
{
    public Guid Id { get; set; }
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int PharmaTypeId { get; set; }
    public int ActiveIngredientCount { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserMedicineDto, UpdateUserMedicineCommand>();
    }
}
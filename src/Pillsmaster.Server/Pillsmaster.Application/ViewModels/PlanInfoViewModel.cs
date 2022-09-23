using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels;

public class PlanInfoViewModel : IMapWith<Plan>
{
    public Guid Id { get; set; }
    public string TradeName { get; set; }
    public string InternationalName { get; set; }
    public int ActiveIngredientCount { get; set; }
    public int PharmaTypeId { get; set; }
    public string PharmaType { get; set; }
    public int TakesPerDay { get; set; }
    public DateTime NextTakeTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Plan, PlanInfoViewModel>().ForMember(plan => plan.TradeName,
            opt =>
                opt.MapFrom(plan => plan.UserMedicine.TradeName))
            .ForMember(plan => plan.InternationalName,
            opt =>
                opt.MapFrom(plan => plan.UserMedicine.InternationalName))
            .ForMember(plan => plan.PharmaTypeId,
            opt =>
                opt.MapFrom(plan => plan.UserMedicine.PharmaTypeId))
            .ForMember(plan => plan.PharmaType,
            opt =>
                opt.MapFrom(plan => plan.UserMedicine.PharmaType.Type))
            .ForMember(plan => plan.TakesPerDay,
            opt =>
                opt.MapFrom(plan => plan.MedicationDay.TakesPerDay))
            .ForMember(plan => plan.ActiveIngredientCount,
                opt => 
                    opt.MapFrom(plan => plan.UserMedicine.ActiveIngredientCount));
    }
}
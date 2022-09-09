using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.Plans.Commands.CreatePlan;
using Pillsmaster.Application.Plans.Commands.UpdatePlan;

namespace Pillsmaster.API.Dtos;

public class UpdatePlanDto : IMapWith<UpdatePlanCommand>
{
    public Guid Id { get; set; }
    public int MedicineCount { get; set; }
    public int Duration { get; set; }
    public bool IsEnoughToFinish { get; set; }
    public int FoodStatusId { get; set; }
    public bool IsFoodDependent { get; set; }
    public int PlanStatusId { get; set; }
    public int CountPerTake { get; set; }
    public int TakesPerDay { get; set; }
    public int TakesCount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? NextTakeTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePlanDto, CreatePlanCommand>();
    }
}
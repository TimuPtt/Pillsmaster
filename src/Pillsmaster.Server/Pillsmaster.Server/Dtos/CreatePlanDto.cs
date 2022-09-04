using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.Plans.Commands.CreatePlan;

namespace Pillsmaster.API.Dtos;

public class CreatePlanDto : IMapWith<CreatePlanCommand>
{
    public Guid UserMedicineId { get; set; }
    public int MedicineCount { get; set; }
    public int Duration { get; set; }
    public bool IsEnoughToFinish { get; set; }
    public int FoodStatusId { get; set; }
    public bool IsFoodDependent { get; set; }
    public int PlanStatusId { get; set; }
    public MedicationDayDto? MedicationDay { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? NextTakeTime { get; set; }
    public List<TakeDto>? Takes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePlanDto, CreatePlanCommand>();
    }
}


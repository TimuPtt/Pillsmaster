using AutoMapper;

using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class PlanViewModel : IMapWith<Plan>
    {
        public Guid Id { get; set; }
        public int MedicineCount { get; set; }
        public int Duration { get; set; }
        public bool IsEnoughToFinish { get; set; }
        public string? FoodStatus { get; set; }
        public bool IsFoodDependent { get; set; }
        public string? PlanStatus { get; set; }
        public int TakesCount { get; set; }
        public MedicationDayViewModel? MedicationDay{ get; set; }
        public UserMedicineViewModel? UserMedicine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? NextTakeTime { get; set; }
        public List<TakeViewModel>? Takes { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Plan, PlanViewModel>()
                .ForMember(planVm => planVm.FoodStatus,
                    opt =>
                        opt.MapFrom(plan => plan.FoodStatus!.Status))
                .ForMember(planVm => planVm.PlanStatus,
                    opt =>
                        opt.MapFrom(plan => plan.PlanStatus!.Status));
        }
    }
}

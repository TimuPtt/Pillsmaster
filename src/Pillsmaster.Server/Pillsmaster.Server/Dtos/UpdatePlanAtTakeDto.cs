using AutoMapper;

using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Application.Plans.Commands.UpdatePlanAtTake;

namespace Pillsmaster.API.Dtos;

public class UpdatePlanAtTakeDto : IMapWith<UpdatePlanAtTakeCommand>
{
    public Guid Id { get; set; }
    public int MedicineCount { get; set; }
    public DateTime NextTakeTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePlanAtTakeDto, UpdatePlanAtTakeCommand>();
    }
}
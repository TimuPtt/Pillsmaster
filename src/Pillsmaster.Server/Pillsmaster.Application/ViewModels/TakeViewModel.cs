using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class TakeViewModel : IMapWith<Take>
    {
        public DateTime TakeTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Take, TakeViewModel>();
        }
    }
}

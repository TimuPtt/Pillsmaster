using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pillsmaster.Application.Common.Mappings;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class MedicationDayViewModel : IMapWith<MedicationDay>
    {
        public int TakesPerDay { get; set; }

        public double CountPerTake { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicationDay, MedicationDayViewModel>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pillsmaster.Core.Contracts;

namespace Pillsmaster.Core.Models
{
    internal class Plan : IPlan
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MedicationDayId { get; set; }
        public int MedicineCount { get; set; }
        public int Duration { get; set; }
        public bool IsEnoughToFinish { get; set; }
        public string? FoodStatus { get; set; }
        public string? PlanStatus { get; set; }
        public void TakeMedicine()
        {
            throw new NotImplementedException();
        }

        public void AddTakes(List<Take> takes)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Domain.Models
{
    public class MedicationDay
    {
        public Guid Id { get; set; }

        public int TakesPerDay { get; set; }

        public double CountPerTake { get; set; }

        public Guid PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}

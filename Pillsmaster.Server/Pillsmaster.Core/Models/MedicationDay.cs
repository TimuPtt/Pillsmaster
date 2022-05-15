using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Core.Models
{
    internal class MedicationDay
    {
        public Guid Id { get; set; }
        public int TakesPerDay { get; set; }
        public double CountPerTake { get; set; }
        public Queue<Take> Takes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Pillsmaster.Domain.Models
{
    public class MedicationDay
    {
        [Key]
        public Guid Id { get; set; }

        public int TakesPerDay { get; set; }

        public double CountPerTake { get; set; }

        public Plan Plan { get; set; }
    }
}

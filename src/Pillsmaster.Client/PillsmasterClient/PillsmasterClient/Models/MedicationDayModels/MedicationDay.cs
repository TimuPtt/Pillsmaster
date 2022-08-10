using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.MedicationDayModels
{
    public class MedicationDay
    {
        public Guid Id { get; set; }

        public int TakesPerDay { get; set; }

        public double CountPerTake { get; set; }
    }
}

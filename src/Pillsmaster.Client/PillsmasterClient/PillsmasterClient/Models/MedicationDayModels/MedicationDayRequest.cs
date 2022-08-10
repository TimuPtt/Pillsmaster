using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.MedicationDayModels
{
    public class MedicationDayRequest
    {
        public int TakesPerDay { get; set; }

        public double CountPerTake { get; set; }
    }
}

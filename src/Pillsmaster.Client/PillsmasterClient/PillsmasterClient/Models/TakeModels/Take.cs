using System;
using System.Collections.Generic;
using System.Text;

namespace PillsmasterClient.Models.TakeModels
{
    public class Take
    {
        public Guid Id { get; set; }

        public DateTime TakeTime { get; set; }

        public Guid PlanId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Domain.Models
{
    public class Take
    {
        public Guid Id { get; set; }

        public DateTime TakeDateTime { get; set; }

        public Guid PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}

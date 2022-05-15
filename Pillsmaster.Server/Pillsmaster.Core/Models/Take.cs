using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Core.Models
{
    internal class Take
    {
        public Guid Id { get; set; }
        public DateOnly TakeDate { get; set; }
        public TimeOnly TakeTime { get; set; }

    }
}

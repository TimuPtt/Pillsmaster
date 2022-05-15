using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Core.Models
{
    internal class Medicine
    {
        public Guid Id { get; set; }
        public string TradeName { get; set; }
        public string? InternationalName { get; set; }
        public string PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }
    }
}

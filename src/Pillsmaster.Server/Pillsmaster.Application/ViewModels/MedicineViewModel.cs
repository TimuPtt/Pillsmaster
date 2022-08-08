using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillsmaster.Application.ViewModels
{
    public class MedicineViewModel
    {
        public string TradeName { get; set; }

        public string InternationalName { get; set; } = string.Empty;

        public string PharmaType { get; set; } = string.Empty;

        public int ActiveIngredientCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pillsmaster.Core.Models;

namespace Pillsmaster.Core.Contracts
{
    internal interface IPlan
    {
        void TakeMedicine();

        void AddTakes(List<Take> takes);
    }
}

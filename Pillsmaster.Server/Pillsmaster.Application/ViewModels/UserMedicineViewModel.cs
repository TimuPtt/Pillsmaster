using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.ViewModels
{
    public class UserMedicineViewModel
    {
        public Guid UserId { get; set; }

        public Guid UserPlanId { get; set; }

        public Guid MedicineId { get; set; }
    }
}

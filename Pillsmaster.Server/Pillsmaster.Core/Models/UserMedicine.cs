

namespace Pillsmaster.Domain.Models
{
    public class UserMedicine 
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid UserPlanId { get; set; }

        public Guid MedicineId { get; set; }

        public Medicine? Medicine { get; set; }
    }
}

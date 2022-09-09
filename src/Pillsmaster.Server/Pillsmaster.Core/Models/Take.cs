
namespace Pillsmaster.Domain.Models
{
    public class Take
    {
        public Guid Id { get; set; }

        public DateTime TakeTime { get; set; }

        public Guid PlanId { get; set; }
    }
}

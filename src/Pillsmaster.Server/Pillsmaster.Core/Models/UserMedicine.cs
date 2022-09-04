using System.ComponentModel.DataAnnotations;

namespace Pillsmaster.Domain.Models
{
    public class UserMedicine 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TradeName { get; set; }
        public string InternationalName { get; set; } = string.Empty;
        public int PharmaTypeId { get; set; }
        public PharmaType? PharmaType { get; set; }
        public int ActiveIngredientCount { get; set; }
    }
}

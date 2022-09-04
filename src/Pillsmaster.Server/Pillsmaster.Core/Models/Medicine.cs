using System.ComponentModel.DataAnnotations;

namespace Pillsmaster.Domain.Models
{
    public class Medicine
    {
        public Guid Id { get; set; }

        [StringLength(30)]
        [Required]
        public string TradeName { get; set; }

        [StringLength(30)]
        public string InternationalName { get; set; } = string.Empty;
        
        public int PharmaTypeId { get; set; }
        public PharmaType? PharmaType { get; set; }

        public int ActiveIngredientCount { get; set; }
    }
}

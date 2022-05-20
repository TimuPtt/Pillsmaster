using Microsoft.EntityFrameworkCore;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Interfaces
{
    public interface IPillsmasterDbContext
    {
        DbSet<MedicationDay> MedicationDays { get; set; }
        DbSet<Medicine> Medicines { get; set; }
        DbSet<UserMedicine> UserMedicines { get; set; }
        DbSet<Plan> Plans { get; set; }
        DbSet<Take> Takes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

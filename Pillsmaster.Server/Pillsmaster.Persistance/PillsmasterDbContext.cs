using Microsoft.EntityFrameworkCore;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Domain.Models;


namespace Pillsmaster.Persistence
{
    public class PillsmasterDbContext : DbContext, IPillsmasterDbContext
    {
        public DbSet<MedicationDay> MedicationDays { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<UserMedicine> UserMedicines { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Take> Takes { get; set; }

        public PillsmasterDbContext(DbContextOptions<PillsmasterDbContext> options) : base(options) { }

    }
}

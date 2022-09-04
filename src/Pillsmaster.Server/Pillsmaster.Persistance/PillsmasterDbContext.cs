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
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<FoodStatus> FoodStatuses { get; set; }
        public DbSet<PharmaType> PharmaTypes { get; set; }
        public DbSet<PlanStatus> PlanStatuses { get; set; }

        public PillsmasterDbContext(DbContextOptions<PillsmasterDbContext> options) : base(options) { }
    }
}

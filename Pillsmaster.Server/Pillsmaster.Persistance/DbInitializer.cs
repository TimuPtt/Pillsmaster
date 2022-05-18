namespace Pillsmaster.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PillsmasterDbContext context) =>
            context.Database.EnsureCreated();
    }
}

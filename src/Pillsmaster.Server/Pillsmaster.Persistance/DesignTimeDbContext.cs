using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Pillsmaster.Persistence
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<PillsmasterDbContext>
    {
        public PillsmasterDbContext CreateDbContext(string[] args)
        {
            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder() as IConfigurationBuilder;
            //JsonConfigurationExtensions.AddJsonFile(configurationBuilder,
            //    Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            //IConfigurationRoot configuration = configurationBuilder.Build();

            var connectionString = "Server=localhost\\sqlexpress;Database=pillsmasterlocaldb;Trusted_connection=true";

            DbContextOptionsBuilder<PillsmasterDbContext> builder = new();
            builder.UseSqlServer(connectionString);

            return new PillsmasterDbContext(builder.Options);
        }
    }
}

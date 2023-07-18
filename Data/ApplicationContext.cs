using EgrnNet6;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NameGenerator
{
    public sealed class ApplicationContext : DbContext
    {
        internal ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        private ApplicationContext()
        {
        }

        internal DbSet<Endings> Endings { get; set; }

        internal DbSet<Language> Languages { get; set; }

        internal DbSet<LetterFrequency> LetterFrequencies { get; set; }

        internal DbSet<Letter> Letters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var configuration = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())
                //    .AddXmlFile("App.config")
                //    .Build();

                //if (configuration
                //    .Providers
                //    .FirstOrDefault()
                //    .TryGet("connectionStrings:add:Default:connectionString",
                //        out string connectionString))
                //{
                //    optionsBuilder.UseSqlite("Data Source=local.db;Mode=ReadWriteCreate;Cache=Shared");
                //}
                //else
                //{
                //    throw new Exception("The design-time connection string not found!");
                //}
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            string connectionString = SettingsHelper.GetString("ConnectionStrings:NameGenerator");
            optionsBuilder.UseSqlite(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
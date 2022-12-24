using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Model
{
    public sealed class ApplicationContext : DbContext
    {
        internal ApplicationContext()
        {
        }

        internal ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        internal DbSet<Endings> Endings { get; set; }

        internal DbSet<Language> Languages { get; set; }

        internal DbSet<Letter> Letters { get; set; }

        internal DbSet<LetterFrequency> LetterFrequencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                //optionsBuilder.UseSqlite(connectionString);

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config")
                    .Build();

                if (configuration
                    .Providers
                    .FirstOrDefault()
                    .TryGet("connectionStrings:add:Default:connectionString",
                        out string connectionString))
                {
                    optionsBuilder.UseSqlite("Data Source=local.db;Mode=ReadWriteCreate;Cache=Shared");
                }
                else
                {
                    throw new Exception("The design-time connection string not found!");
                }
            }
        }
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();

            if (configuration
                .Providers
                .FirstOrDefault()
                .TryGet("connectionStrings:add:Default:connectionString",
                    out string connectionString))
            {
                optionsBuilder.UseSqlite("Data Source=local.db;Mode=ReadWriteCreate;Cache=Shared");
                return new ApplicationContext(optionsBuilder.Options);
            }
            else
            {
                throw new Exception("The design-time connection string not found!");
            }
        }
    }
}
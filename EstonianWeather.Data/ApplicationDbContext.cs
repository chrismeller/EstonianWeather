using System.Data.Common;
using EstonianWeather.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EstonianWeather.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(BuildOptions(connectionString))
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        private static DbContextOptions<ApplicationDbContext> BuildOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinnishForecast>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<FinnishForecast>()
                .HasIndex(x => x.RequestId);

            modelBuilder.Entity<FinnishForecast>()
                .HasIndex(x => x.Time);

            modelBuilder.Entity<FinnishForecast>()
                .HasIndex(x => x.RequestedAt);
        }

        public DbConnection GetDbConnection()
        {
            return Database.GetDbConnection();
        }

        public DbSet<FinnishForecast> FinnishForecasts { get; set; }
    }
}
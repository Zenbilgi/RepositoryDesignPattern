using System;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternExample.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ormexample;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}


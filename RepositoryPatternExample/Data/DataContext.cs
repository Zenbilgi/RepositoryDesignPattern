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
            //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ormexample;Trusted_Connection=true;TrustServerCertificate=true;");
            //optionsBuilder.UseSqlServer("Server = localhost;Database = ormexample;User Id = sa; Password = Pass2022!;");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}


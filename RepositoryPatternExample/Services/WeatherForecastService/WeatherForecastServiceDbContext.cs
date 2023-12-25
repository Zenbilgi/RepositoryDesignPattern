using System;

namespace RepositoryPatternExample.Services.WeatherForecastService
{
	public class WeatherForecastServiceDbContext : IWeatherForecastService
	{
		public WeatherForecastServiceDbContext()
		{
		}

        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }
    }
}


using System;
using RepositoryPatternExample.Data;

namespace RepositoryPatternExample.Services.WeatherForecastService
{
	public class WeatherForecastServiceDbContext : IWeatherForecastService
	{
        private readonly DataContext _dataContext;

        public WeatherForecastServiceDbContext(DataContext dataContext)
		{
            _dataContext = dataContext;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return _dataContext.Forecasts.ToArray();
        }
    }
}


using System;
using System.IO;
using System.Linq;
using EstonianWeather.Provider.Estonia;
using EstonianWeather.Provider.Finland;
using System.Threading.Tasks;
using EstonianWeather.Data;
using EstonianWeather.Domain;
using Microsoft.Extensions.Configuration;

namespace EstonianWeather.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static async Task Test()
        {
            //var radarImages = await EstonianWeatherService.GetRadar();
            //var observations = await EstonianWeatherService.GetObservations();
            var estonianForecast = await EstonianWeatherService.GetForecast();

            var finnish = new FinnishMeteorologicalInstitute("5a1f4db3-a07e-49c9-9513-e4e574dedf9d");
            var forecasts = await finnish.GetForecasts("tallinn");

            var parameterNames = forecasts.Members.Where(x => x.BsWfsElement.Time.Contains("2019-01-25T09"))
                .Select(x => x.BsWfsElement.ParameterName);
        }

        private static async Task Run()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString =
                config.GetConnectionString("EstonianWeather.Data.ApplicationDbContext");

            using (var db = new ApplicationDbContext(connectionString))
            {
                var finnishForecastService = new FinnishForecastService(db);
                var finnish = new FinnishMeteorologicalInstitute(config.GetValue<string>("FinnishMeteorologicalInstitute.ApiKey"));

                var requestId = Guid.NewGuid();
                var requestTime = DateTimeOffset.UtcNow;
                var requestLocation = "tallinn";
                var forecasts = await finnish.GetForecasts(requestLocation);

                await finnishForecastService.Save(requestId, requestTime, requestLocation, forecasts);
            }
        }
    }
}

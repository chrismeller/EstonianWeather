using System.Threading.Tasks;
using EstonianWeather.Provider.Estonia;
using EstonianWeather.Provider.Finland;

namespace EstonianWeather.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static async Task Run()
        {
            //var radarImages = await EstonianWeatherService.GetRadar();
            //var observations = await EstonianWeatherService.GetObservations();
            //var forecasts = await EstonianWeatherService.GetForecast();

            var finnish = new FinnishMeteorologicalInstitute("5a1f4db3-a07e-49c9-9513-e4e574dedf9d");
            var forecasts = await finnish.GetForecasts("tallinn");
        }
    }
}

using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EstonianWeather.Data;
using EstonianWeather.Data.Models;
using EstonianWeather.Provider.Finland.DTOs;

namespace EstonianWeather.Domain
{
    public class FinnishForecastService
    {
        private readonly DbConnection _db;

        public FinnishForecastService(ApplicationDbContext dbContext)
        {
            _db = dbContext.GetDbConnection();
        }

        public async Task<bool> Create(FinnishForecast forecast)
        {
            var result =
                await _db.ExecuteAsync(@"
insert into FinnishForecasts (
    Id,
    RequestId,
    RequestLocation,
    RequestedAt,
    Time,
    Location,
    GeopHeight,
    Temperature,
    Pressure,
    Humidity,
    WindDirection,
    WindSpeedMS,
    WindUMS,
    WindVMS,
    MaximumWind,
    WindGust,
    DewPoint,
    TotalCloudCover,
    WeatherSymbol3,
    LowCloudCover,
    MediumCloudCover,
    HighCloudCover,
    Precipitation1h,
    PrecipitationAmount,
    RadiationGlobalAccumulation,
    RadiationLWAccumulation,
    RadiationNetSurfaceLWAccumulation,
    RadiationNetSurfaceSWAccumulation,
    RadiationDiffuseAccumulation,
    LandSeaMask
)
values (
    @Id,
    @RequestId,
    @RequestLocation,
    @RequestedAt,
    @Time,
    @Location,
    @GeopHeight,
    @Temperature,
    @Pressure,
    @Humidity,
    @WindDirection,
    @WindSpeedMS,
    @WindUMS,
    @WindVMS,
    @MaximumWind,
    @WindGust,
    @DewPoint,
    @TotalCloudCover,
    @WeatherSymbol3,
    @LowCloudCover,
    @MediumCloudCover,
    @HighCloudCover,
    @Precipitation1h,
    @PrecipitationAmount,
    @RadiationGlobalAccumulation,
    @RadiationLWAccumulation,
    @RadiationNetSurfaceLWAccumulation,
    @RadiationNetSurfaceSWAccumulation,
    @RadiationDiffuseAccumulation,
    @LandSeaMask
)", forecast);

            return result == 1;
        }

        public async Task<bool> Save(Guid requestId, DateTimeOffset requestedAt, string requestLocation,
            FeatureCollection forecast)
        {
            var hours = forecast.Members.GroupBy(x => x.BsWfsElement.Time);

            foreach (var hour in hours)
            {
                var dbForecast = new FinnishForecast()
                {
                    Id = Guid.NewGuid(),
                    RequestId = requestId,
                    RequestedAt = requestedAt,
                    Time = hour.Key,
                    DewPoint = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "DewPoint")?.BsWfsElement.ParameterValue,
                    GeopHeight = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "GeopHeight")?.BsWfsElement.ParameterValue,
                    HighCloudCover = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "HighCloudCover")?.BsWfsElement.ParameterValue,
                    Humidity = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "Humidity")?.BsWfsElement.ParameterValue,
                    LandSeaMask = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "LandSeaMask")?.BsWfsElement.ParameterValue,
                    Location = hour.First().BsWfsElement.Location.Point.Position,
                    LowCloudCover = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "LowCloudCover")?.BsWfsElement.ParameterValue,
                    MaximumWind = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "MaximumWind")?.BsWfsElement.ParameterValue,
                    MediumCloudCover = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "MediumCloudCover")?.BsWfsElement.ParameterValue,
                    Precipitation1h = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "Precipitation1h")?.BsWfsElement.ParameterValue,
                    PrecipitationAmount = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "PrecipitationAmount")?.BsWfsElement.ParameterValue,
                    Pressure = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "Pressure")?.BsWfsElement.ParameterValue,
                    RadiationDiffuseAccumulation = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "RadiationDiffuseAccumulation")?.BsWfsElement.ParameterValue,
                    RadiationGlobalAccumulation = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "RadiationGlobalAccumulation")?.BsWfsElement.ParameterValue,
                    RadiationLWAccumulation = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "RadiationLWAccumulation")?.BsWfsElement.ParameterValue,
                    RadiationNetSurfaceLWAccumulation = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "RadiationNetSurfaceLWAccumulation")?.BsWfsElement.ParameterValue,
                    RadiationNetSurfaceSWAccumulation = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "RadiationNetSurfaceSWAccumulation")?.BsWfsElement.ParameterValue,
                    RequestLocation = requestLocation,
                    Temperature = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "Temperature")?.BsWfsElement.ParameterValue,
                    TotalCloudCover = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "TotalCloudCover")?.BsWfsElement.ParameterValue,
                    WeatherSymbol3 = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WeatherSymbol3")?.BsWfsElement.ParameterValue,
                    WindDirection = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WindDirection")?.BsWfsElement.ParameterValue,
                    WindGust = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WindGust")?.BsWfsElement.ParameterValue,
                    WindSpeedMS = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WindSpeedMS")?.BsWfsElement.ParameterValue,
                    WindUMS = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WindUMS")?.BsWfsElement.ParameterValue,
                    WindVMS = hour.FirstOrDefault(x => x.BsWfsElement.ParameterName == "WindVMS")?.BsWfsElement.ParameterValue,
                };

                await Create(dbForecast);
            }

            return true;
        }
    }
}
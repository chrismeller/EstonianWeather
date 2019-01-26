using System;
using System.ComponentModel.DataAnnotations;

namespace EstonianWeather.Data.Models
{
    public class FinnishForecast
    {
        public Guid Id { get; set; }

        // this is the ID of the request so we can group together the forecasts that came in at the same time
        public Guid RequestId { get; set; }

        // this is the textual location we searched for
        public string RequestLocation { get; set; }

        public DateTimeOffset RequestedAt { get; set; }

        // this is the Time attribute on the result
        [MaxLength(20)]
        public string Time { get; set; }

        // this is the Location attribute on the result
        public string Location { get; set; }

        public string GeopHeight { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeedMS { get; set; }
        public string WindUMS { get; set; }
        public string WindVMS { get; set; }
        public string MaximumWind { get; set; }
        public string WindGust { get; set; }
        public string DewPoint { get; set; }
        public string TotalCloudCover { get; set; }
        public string WeatherSymbol3 { get; set; }
        public string LowCloudCover { get; set; }
        public string MediumCloudCover { get; set; }
        public string HighCloudCover { get; set; }
        public string Precipitation1h { get; set; }
        public string PrecipitationAmount { get; set; }
        public string RadiationGlobalAccumulation { get; set; }
        public string RadiationLWAccumulation { get; set; }
        public string RadiationNetSurfaceLWAccumulation { get; set; }
        public string RadiationNetSurfaceSWAccumulation { get; set; }
        public string RadiationDiffuseAccumulation { get; set; }
        public string LandSeaMask { get; set; }
    }
}
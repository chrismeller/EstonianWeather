using System;

namespace EstonianWeather.Provider.Estonia.DTOs
{
    public class RadarImage
    {
        public string ImageUrl { get; set; }
        public Int32 Timestamp { get; set; }
        public DateTimeOffset CapturedAt { get; set; }
    }
}
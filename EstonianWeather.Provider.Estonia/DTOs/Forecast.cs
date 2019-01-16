using System.Collections.Generic;
using System.Xml.Serialization;

namespace EstonianWeather.Provider.Estonia.DTOs
{
    [XmlRoot("forecasts")]
    public class ForecastsWrapper
    {
        [XmlElement("forecast")]
        public List<Forecast> Forecasts { get; set; }
    }

    public class Forecast
    {
        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlElement("night")]
        public Night Night { get; set; }

        [XmlElement("day")]
        public Day Day { get; set; }
    }

    public abstract class NightAndDay
    {
        [XmlElement("phenomenon")]
        public string Phenomenon { get; set; }

        [XmlElement("tempmin")]
        public string TempMin { get; set; }

        [XmlElement("tempmax")]
        public string TempMax { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("wind")]
        public List<Wind> WindMeasurements { get; set; }

        [XmlElement("sea")]
        public string Sea { get; set; }

        [XmlElement("peipsi")]
        public string LakePeipus { get; set; }
    }

    public class Night : NightAndDay
    { 
        [XmlElement("place")]
        public List<PlaceNight> Places { get; set; }
    }

    public class Day : NightAndDay
    {
        [XmlElement("place")]
        public List<PlaceDay> Places { get; set; }
    }

    public abstract class Place
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("phenomenon")]
        public string Phenomenon { get; set; }
    }

    public class PlaceNight : Place
    { 
        [XmlElement("tempmin")]
        public string TempMin { get; set; }
    }

    public class PlaceDay : Place
    {
        [XmlElement("tempmax")]
        public string TempMax { get; set; }
    }

    public class Wind
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("direction")]
        public string Direction { get; set; }

        [XmlElement("speedmin")]
        public string SpeedMin { get; set; }

        [XmlElement("speedmax")]
        public string SpeedMax { get; set; }

        [XmlElement("gust")]
        public string Gust { get; set; }
    }
}
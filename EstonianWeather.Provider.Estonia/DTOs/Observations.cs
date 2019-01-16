using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EstonianWeather.Provider.Estonia.DTOs
{
    [XmlRoot("observations")]
    public class Observations
    {
        [XmlElement("station")]
        public List<Station> Station { get; set; }

        [XmlAttribute("timestamp")]
        public Int32 Timestamp { get; set; }
    }


    public class Station
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("wmocode")]
        public string WmoCode { get; set; }

        [XmlElement("latitude")]
        public string Latitude { get; set; }

        [XmlElement("longitude")]
        public string Longitude { get; set; }

        [XmlElement("phenomenon")]
        public string Phenomenon { get; set; }

        [XmlElement("visibility")]
        public string Visibility { get; set; }

        [XmlElement("precipitations")]
        public string Precipitation { get; set; }

        [XmlElement("airpressure")]
        public string AirPressure { get; set; }

        [XmlElement("relativehumidity")]
        public string RelativeHumidity { get; set; }

        [XmlElement("airtemperature")]
        public string AirTemperature { get; set; }

        [XmlElement("winddirection")]
        public string WindDirection { get; set; }

        [XmlElement("windspeed")]
        public string WindSpeed { get; set; }

        [XmlElement("windspeedmax")]
        public string WindSpeedMax { get; set; }

        [XmlElement("waterlevel")]
        public string WaterLevel { get; set; }

        [XmlElement("waterlevel_eh2000")]
        public string WaterLevelEh2000 { get; set; }

        [XmlElement("watertemperature")]
        public string WaterTemperature { get; set; }

        [XmlElement("uvindex")]
        public string UvIndex { get; set; }
    }
}
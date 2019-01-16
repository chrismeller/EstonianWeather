using System.Collections.Generic;
using System.Xml.Serialization;

namespace EstonianWeather.Provider.Finland.DTOs
{
    [XmlRoot("FeatureCollection", Namespace = "http://www.opengis.net/wfs/2.0")]
    public class FeatureCollection
    {
        [XmlAttribute("timeStamp")]
        public string Timestamp { get; set; }
        [XmlAttribute("numberReturned")]
        public int NumberReturned { get; set; }
        [XmlAttribute("numberMatched")]
        public int NumberMatched { get; set; }

        [XmlElement("member", Namespace = "http://www.opengis.net/wfs/2.0")]
        public List<Member> Members { get; set; }
    }

    public class Member
    {
        [XmlElement("BsWfsElement", Namespace = "http://xml.fmi.fi/schema/wfs/2.0")]
        public BsWfsElement BsWfsElement { get; set; }
    }

    public class BsWfsElement
    {
        [XmlElement("Location", Namespace = "http://xml.fmi.fi/schema/wfs/2.0")]
        public Location Location { get; set; }

        [XmlElement("Time", Namespace = "http://xml.fmi.fi/schema/wfs/2.0")]
        public string Time { get; set; }

        [XmlElement("ParameterName", Namespace = "http://xml.fmi.fi/schema/wfs/2.0")]
        public string ParameterName { get; set; }

        [XmlElement("ParameterValue", Namespace = "http://xml.fmi.fi/schema/wfs/2.0")]
        public string ParameterValue { get; set; }
    }

    public class Location
    {
        [XmlElement("Point", Namespace = "http://www.opengis.net/gml/3.2")]
        public Point Point { get; set; }
    }

    public class Point
    {
        [XmlElement("pos", Namespace = "http://www.opengis.net/gml/3.2")]
        public string Position { get; set; }
    }
}
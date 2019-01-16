using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EstonianWeather.Provider.Estonia.DTOs;
using HtmlAgilityPack;

namespace EstonianWeather.Provider.Estonia
{
    public class EstonianWeatherService
    {
        public static async Task<Observations> GetObservations()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://www.ilmateenistus.ee/ilma_andmed/xml/observations.php");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var serializer = new XmlSerializer(typeof(Observations));
                var observations = (Observations)serializer.Deserialize(new StringReader(content));

                return observations;
            }
        }

        public static async Task<List<Forecast>> GetForecast()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://www.ilmateenistus.ee/ilma_andmed/xml/forecast.php?lang=eng");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var serializer = new XmlSerializer(typeof(ForecastsWrapper));
                var forecasts = (ForecastsWrapper)serializer.Deserialize(new StringReader(content));

                return forecasts.Forecasts;
            }
        }

        public static async Task<List<RadarImage>> GetRadar()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://www.ilmateenistus.ee/ilm/ilmavaatlused/radaripildid/komposiitpilt/?lang=en&ajax=1537947680747");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                doc.LoadHtml(content);

                var images = new List<RadarImage>();
                var imageNodes = doc.DocumentNode.SelectNodes(".//img[ contains( @class, 'radar-image' ) ]");
                foreach (var image in imageNodes)
                {
                    var src = image.GetAttributeValue("src", "");
                    var capturedTimestamp = image.GetAttributeValue("data-datetime", 0);

                    var capturedAt = (new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).AddSeconds(capturedTimestamp);

                    images.Add(new RadarImage()
                    {
                        ImageUrl = src,
                        Timestamp = capturedTimestamp,
                        CapturedAt = capturedAt,
                    });
                }

                return images;
            }
        }
    }
}
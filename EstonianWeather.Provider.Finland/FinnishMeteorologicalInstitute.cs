using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using EstonianWeather.Provider.Finland.DTOs;

namespace EstonianWeather.Provider.Finland
{
    public class FinnishMeteorologicalInstitute
    {
        private readonly string _apiKey;

        public FinnishMeteorologicalInstitute(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<FeatureCollection> GetForecasts(string location)
        {
            using (var client = new HttpClient())
            {
                var response =
                    await client.GetAsync(
                        $"https://data.fmi.fi/fmi-apikey/{_apiKey}/wfs?request=getFeature&storedquery_id=fmi::forecast::hirlam::surface::point::simple&place={location}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var serializer = new XmlSerializer(typeof(FeatureCollection));
                var forecasts = (FeatureCollection)serializer.Deserialize(new StringReader(content));

                return forecasts;
            }
        }
    }
}
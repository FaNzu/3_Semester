using System.Text.Json.Serialization;

namespace WeatherProxyApi.Models
{
    /// <summary>
    /// This is a model class, used when deserializing the JSON body retrieved from a request to the GeoCoding API.
    /// </summary>
    public class GeoData
    {

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }


        [JsonPropertyName("name")]
        public string CityName { get; set; } = string.Empty;
        [JsonPropertyName("country")]
        public string CountryName { get; set; } = string.Empty;
        [JsonPropertyName("state")]
        public string RegionName { get; set; } = string.Empty;
    }
}

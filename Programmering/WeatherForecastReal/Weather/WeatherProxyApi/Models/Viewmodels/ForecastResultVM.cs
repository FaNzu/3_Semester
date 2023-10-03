using System.Text.Json.Serialization;

namespace WeatherProxyApi.Models.Viewmodels
{
    public class ForecastResultVM
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public string CityName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;


        [JsonPropertyName("cod")]
        public string htmlResponse { get; set; }
        public int message { get; set; }
        [JsonPropertyName("cnt")]
        public int htmlCount { get; set; }
        [JsonPropertyName("list")]
        public List<WeatherDataList> weatherList { get; set; }
        public City city { get; set; }


        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
            public int population { get; set; }
            public int timezone { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Clouds
        {
            [JsonPropertyName("all")]
            public int cloudPercentage { get; set; }
            //cloud percantage
        }

        public class Coord
        {
            public double lat { get; set; } //lattitude
            public double lon { get; set; } //longitude
        }

        public class WeatherDataList //root
        {
            [JsonPropertyName("dt")]
            public int UnixTimestamp { get; set; } //unix date time for time
            [JsonPropertyName("main")]
            public WeatherMain weatherMain { get; set; } //main info temp, humid,pressure
            [JsonPropertyName("weather")]
            public List<WeatherType> weatherType { get; set; } //weather type + icon
            public Clouds clouds { get; set; } //cloud %
            public Wind wind { get; set; } //wind info
            public int visibility { get; set; } //how far you can see
            [JsonPropertyName("pop")]
            public double probabilityRain { get; set; } //Probability of precipitation %of rain
            [JsonPropertyName("sys")]
            public TimeCycle timeCycle { get; set; } //time of day, day or night
            [JsonPropertyName("dt_txt")]
            public string timeOfData { get; set; } //time of data in utc
        }

        public class WeatherMain
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }

            
        

        //sys
        public class TimeCycle
        {
            [JsonPropertyName("pod")]
            public string partOfDay { get; set; }
        }

        public class WeatherType
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }


    }
}

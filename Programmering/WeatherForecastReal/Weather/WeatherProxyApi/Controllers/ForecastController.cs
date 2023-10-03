using Microsoft.AspNetCore.Mvc;
using WeatherProxyApi.Models;
using WeatherProxyApi.Models.Viewmodels;

//using WeatherForecastAPI.Models.ViewModels;
//using WeatherForecastAPI.Utility;

namespace WeatherProxyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        #region constructor and variables
        private readonly ILogger<ForecastController> _logger;
        private readonly IConfiguration _config;
        private HttpClient _httpClient;
        string _apiKey;

        public ForecastController(ILogger<ForecastController> logger, HttpClient httpClient, IConfiguration config)
        {
            _logger = logger;
            _httpClient = httpClient;
            _config = config;

            _apiKey = config["apikey"];
        }
        
        #endregion


        [HttpGet, ActionName("Forecast")]
        public async Task<IActionResult> GetForecast(string cityName, string? unitType)
        {
            //why [] its a model, fordi man kan modtage mere end 1 geo data?
            GeoData[]? geoData = await _httpClient.GetFromJsonAsync<GeoData[]?>($"http://api.openweathermap.org/geo/1.0/direct?q={cityName},,&limit=1&appid={_apiKey}");

            if (geoData!.Count() == 0)
            {
                return BadRequest(); //http code 400 response
            }

            ForecastResultVM? forecastResults = await _httpClient.GetFromJsonAsync<ForecastResultVM?>($"https://api.openweathermap.org/data/2.5/forecast?lat={geoData[0].Latitude}&lon={geoData[0].Longitude}&cnt=38&units={unitType}&appid={_apiKey}");
            //skal modtage mængde dage for 
                
            if (forecastResults == null)
            {
                return BadRequest();
            }
            forecastResults.CityName = geoData[0].CityName;
            forecastResults.RegionName = geoData[0].RegionName;
            forecastResults.CountryName = geoData[0].CountryName;
            return Ok(forecastResults);
        }
    }
}

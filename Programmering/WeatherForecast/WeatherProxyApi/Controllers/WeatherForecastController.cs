using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;

namespace WeatherProxyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        static readonly HttpClient client = new HttpClient();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        //gem data senere
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get(int days, string unitType)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?lat=10.38831&lon=55.39594&cnt={days}&units={unitType}&appid=");//put api key here
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }


    }
}
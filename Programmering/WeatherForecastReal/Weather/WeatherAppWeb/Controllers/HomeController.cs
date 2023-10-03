using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherAppWeb.Models;

namespace WeatherAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ForecastDetails(string cityName, string? unitType)
        {
            if (unitType== null) { unitType = "metric"; }
            ForecastResultVM? forecast = await _httpClient.GetFromJsonAsync<ForecastResultVM>($"https://localhost:7086/api/Forecast?cityName={cityName}&unitType={unitType}");

            return View(forecast);
        }

        [ActionName("Forecast")]
        public IActionResult Forecast(ForecastRequestVM requestedForecast)
        {
            return RedirectToAction(nameof(ForecastDetails), new { requestedForecast.CityName, requestedForecast.UnitType });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
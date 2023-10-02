using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherForecastWeb.Models;

namespace WeatherForecastWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		static readonly HttpClient client = new HttpClient();


		public HomeController(ILogger<HomeController> logger)
		{

			_logger = logger;

		}
		public IActionResult Index()
		{
			return View();
        }

        public async Task<IActionResult> Weather(int? amountDays, string? currentfilter)
		{
            ViewData["amountDays"] = amountDays;
            ViewData["CurrentFilter"] = CategoryChosen(currentfilter);
            List<SelectListItem> unitItems = new List<SelectListItem>();

            unitItems.Add(new SelectListItem { Text = "Metric", Value = "metric" });
            unitItems.Add(new SelectListItem { Text = "Imperial", Value = "imperial" });
            unitItems.Add(new SelectListItem { Text = "scientific", Value = "standard" });
            ViewBag.UnitType = unitItems;

            if (amountDays==null || amountDays<=0){
                amountDays = 8;
            }
			else if (amountDays > 5)
			{
				amountDays = 5*8;
			}
			else { amountDays*=8; }

			if (currentfilter == null) 
				currentfilter = "metric";
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:7293/WeatherForecast?days={amountDays}&unitType={currentfilter}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Root? weatherForecast = JsonSerializer.Deserialize<Root>(responseBody);

            // Extract the city information
            City cityInfo = weatherForecast.city;

            // Handle the list of weather data
            List<List> weatherData = weatherForecast.list;

            return View(weatherForecast);
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

        List<Category> ConvertCategoryToList(IEnumerable<Category> dt)
        {
            return dt.ToList();
        }
    }
}
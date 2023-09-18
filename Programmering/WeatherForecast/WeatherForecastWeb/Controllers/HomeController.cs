using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
		public async Task<IActionResult> Index()
		{
            using HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=Kairo&APPID=5a84ff852b810936feb63cdb21d18b9f");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseBody);

            Root? weatherForecast =
                JsonSerializer.Deserialize<Root>(responseBody.ToString());


            //Console.WriteLine(weatherForecast);
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
	}
}
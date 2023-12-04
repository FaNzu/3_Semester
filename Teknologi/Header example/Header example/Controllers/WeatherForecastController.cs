using Microsoft.AspNetCore.Mvc;

namespace Header_example.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;


		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		//[HttpGet(Name = "GetWeatherForecast")]
		//public IEnumerable<WeatherForecast> Get()
		//{
		//	return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		//	{
		//		Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
		//		TemperatureC = Random.Shared.Next(-20, 55),
		//		Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		//	})
		//	.ToArray();
		//}

		[HttpGet(Name = "GetWeatherForecast")]
		public IActionResult Get()
		{
			if (Request.Headers.ContainsKey("X-Custom-Header"))
			{
				// Access the value of the custom header
				string customHeaderValue = Request.Headers["X-Custom-Header"];

				// Do something with the header value
				return Ok($"Custom Header Value: {customHeaderValue}");
			}
			else
			{
				// Custom header not found in the request
				return BadRequest("Custom header not present in the request");
			}
		}
	}
}

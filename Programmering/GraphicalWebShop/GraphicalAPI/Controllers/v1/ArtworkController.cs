using Microsoft.EntityFrameworkCore;
using GraphicalAPI.Data;
using GraphicalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace GraphicalAPI.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:ApiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class ArtworkController : Controller
	{
		#region Constructor and variables
		//private readonly ILogger<ArtworkController> _logger;
		private readonly IConfiguration _config;
		private HttpClient _httpClient;
		private readonly ArtworkApiContext _context;
        public ArtworkController(IConfiguration config, HttpClient httpClient, ArtworkApiContext context)
        {
			//_logger = logger;
			_config = config;
			_httpClient = httpClient;
			_context = context;
        }
		#endregion

		#region Get - Artworks
		[HttpGet("GetArtworks"), ActionName("GetArtworks")]
		public async Task<IActionResult> GetArtworks()
		{
			var resultArtworks = _context.Artwork;

			if (resultArtworks == null)
			{
				return NotFound();
			}

			return Ok(await resultArtworks.ToListAsync());
		}

		[HttpGet("GetArtwork"), ActionName("GetArtwork")]
		public async Task<IActionResult> GetArtwork(int id)
		{
			var resultArtworks = _context.Artwork;
			Artwork? resultArtwork = null;

			if (resultArtworks == null && id <=0)
			{
				return NotFound();
			}
			else
			{
				resultArtwork = resultArtworks.Find(id);
			}

			return Ok(resultArtwork);
		}
		#endregion

		#region POST - Artworks


		#endregion
	}
}

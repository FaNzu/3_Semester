using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphicalWebMVC.Data
{
	public class ArtworkMvcContext : DbContext
	{
		public ArtworkMvcContext(DbContextOptions<ArtworkMvcContext> options)
		: base(options)
		{
		}

		public DbSet<GraphicalAPI.Models.Artwork> Artwork { get; set; } = default!;
	}
}

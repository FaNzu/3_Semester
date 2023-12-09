using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphicalAPI.Data
{
	public class ArtworkApiContext : DbContext
	{
		public ArtworkApiContext(DbContextOptions<ArtworkApiContext> options)
		: base(options)
		{
		}

		public DbSet<GraphicalAPI.Models.Artwork> Artwork { get; set; } = default!;
	}
}

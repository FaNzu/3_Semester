using GraphicalAPI.Models;
using GraphicalWebMVC.Data;
using GraphicalWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphicalWebMVC.Models.Seeders
{
	public class SeedArtwork
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ArtworkMvcContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<ArtworkMvcContext>>()))
			{
				if (context.Artwork.Any())
				{
					Console.WriteLine("[ARTWORK SEEDER] Artwork have already been Seeded, continuing ...");
					return;
				}

				context.Artwork.AddRange(
					new Artwork(
						name: "karen",
						title: "Blomster 1",
						creationYear: new DateOnly(2012, 11, 12),
						price: 150,
						type: "Linografi",
						salesDate: null,
						location: "Skuffe"
					),
					new Artwork(
						name: "karen",
						title: "Blomster 2",
						creationYear: new DateOnly(2012, 10, 13),
						price: 250,
						type: "Linografi",
						salesDate: null,
						location: "Skuffe"
					),
					new Artwork(
						name: "karen",
						title: "Blomster 3",
						creationYear: new DateOnly(2013, 1, 12),
						price: 350,
						type: "Linografi",
						salesDate: new DateOnly(2013, 1, 14),
						location: "Skuffe"
					),
					new Artwork(
						name: "John",
						title: "Landskab 1",
						creationYear: new DateOnly(2015, 5, 20),
						price: 200,
						type: null,
						salesDate: null,
						location: "Væg"
					),
					new Artwork(
						name: "Alice",
						title: "Portræt 1",
						creationYear: new DateOnly(2020, 8, 10),
						price: 120,
						type: null,
						salesDate: null,
						location: null
				));
			}
		}
	}
}

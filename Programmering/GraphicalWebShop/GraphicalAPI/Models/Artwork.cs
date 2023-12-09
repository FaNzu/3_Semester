using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GraphicalAPI.Models
{
	public class Artwork
	{
        public Artwork()
        {
            
        }
		public Artwork(string name, string title, DateOnly creationYear, double price, string? type, DateOnly? salesDate, string addresse)
		{
			ArtworkId = 0;
			Name = name;
			Title = title;
			CreationYear = creationYear;
			Price = price;
			Type = type;
			SalesDate = salesDate;
			Addresse = addresse;
		}

		public int ArtworkId { get; set; }
		[StringLength(60)]
		[Required]
		public string Name { get; set; }
		[StringLength(60)]
		[Required]
		public string Title { get; set; }
		[Required]
        public DateOnly CreationYear { get; set; }
		[DataType(DataType.Currency)]
		[Required]
        public double Price { get; set; }
		[StringLength(60)]
        public string? Type { get; set; } //enum?
        public DateOnly? SalesDate { get; set; }
		public string Addresse { get; set; } //location model
		//[Timestamp]
		//public byte[] RowVersion { get; set; }
	}
}

namespace DependencyInjection.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public ICollection<Song> Songs { get; set; }
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
    }
}

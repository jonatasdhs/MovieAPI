using System.ComponentModel.DataAnnotations;


namespace MovieApi.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Watched { get; set; }
        public bool Active { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Updated_at { get; set; } = DateTime.Now.ToLocalTime();
        public string TemporaryField { get; set; }

        // Relacionamento com WatchedMovie
        public ICollection<WatchedMovie> WatchedMovies { get; set; }
    }

    public class WatchedMovie
    {
        // Foreign Key para UserModel
        public int UserId { get; set; }
        public UserModel User { get; set; }

        // Foreign Key para MovieModel
        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }
    }
}
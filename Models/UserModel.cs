namespace MovieApi.Models
{
    public class UserModel
    {
        public int Id { get; set; } // Chave primária
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        // Relacionamento com WatchedMovie
        public ICollection<WatchedMovie> WatchedMovies { get; set; }
    }
}
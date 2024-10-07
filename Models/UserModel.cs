using NuGet.Protocol.Plugins;

namespace MovieApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int? MovieId { get; set; }
        public MovieModel? Movies { get; set; }
    }
}
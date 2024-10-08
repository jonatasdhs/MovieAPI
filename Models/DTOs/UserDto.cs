namespace MovieApi.Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
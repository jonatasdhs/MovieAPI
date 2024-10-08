namespace MovieApi.Models.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
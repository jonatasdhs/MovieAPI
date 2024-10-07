using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class MovieModel
    {
        [Key]
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Watched { get; set; }
        public bool Active { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime Updated_at { get; set; } = DateTime.Now.ToLocalTime();

        public ICollection<UserModel> Users { get; } = new List<UserModel>();
    }
}
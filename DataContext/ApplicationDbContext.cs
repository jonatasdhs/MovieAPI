using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
namespace MovieApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
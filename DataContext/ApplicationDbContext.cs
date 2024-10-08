using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
namespace MovieApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<WatchedMovie> WatchedMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchedMovie>()
                .HasKey(wm => new {wm.UserId, wm.MovieId});

            modelBuilder.Entity<WatchedMovie>()
                .HasOne(wm => wm.User)
                .WithMany(u => u.WatchedMovies)
                .HasForeignKey(wm => wm.UserId);

            modelBuilder.Entity<WatchedMovie>()
                .HasOne(wm => wm.Movie)
                .WithMany(u => u.WatchedMovies)
                .HasForeignKey(wm => wm.MovieId);

        }
    }
}
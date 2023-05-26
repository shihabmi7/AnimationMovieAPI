using Microsoft.EntityFrameworkCore;

namespace AnimationMovieAPI.Models
{
    public class MovieContext :DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { 
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        //public DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
    }
}

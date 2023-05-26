using Microsoft.EntityFrameworkCore;

namespace AnimationMovieAPI.Models
{
    public class AspNetUsersContext : DbContext
    {
        public AspNetUsersContext(DbContextOptions<AspNetUsersContext> options) : base(options)
        {
        }

        public DbSet<AspNetUser> AspNetUsers{ get; set; } = null!;
    }
}

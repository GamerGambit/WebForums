using Microsoft.EntityFrameworkCore;

using WebForums.Models;

namespace WebForums.Data
{
	public class WebForumsContext : DbContext
    {
        public WebForumsContext (DbContextOptions<WebForumsContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Forum> Forum { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Thread> Thread { get; set; }

        public DbSet<User> User { get; set; }
    }
}

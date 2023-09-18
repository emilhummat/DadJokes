using Microsoft.EntityFrameworkCore;

namespace DadJokes.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Models.Joke> Joke{ get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace _3LayerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        { 

        }

        public DbSet<Models.Note> Notes { get; set; }
    }
}

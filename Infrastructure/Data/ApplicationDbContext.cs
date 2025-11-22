using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Aqui adicionaremos as entidades depois
        // public DbSet<Post> Posts { get; set; }
    }
}

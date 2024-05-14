using kodutoo.models;
using Microsoft.EntityFrameworkCore;

namespace kodutoo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Auto> Autod { get; set; }
        public DbSet<Rentija> Rentijad { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}

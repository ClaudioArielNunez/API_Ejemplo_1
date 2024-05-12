using ApiFotos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFotos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<MarvelFotos>Fotos{get; set;}
    }
}

using Microsoft.EntityFrameworkCore;
using StellantisSupportAPI.Models;

namespace StellantisSupportAPI.Data
{
    public class AppDbContext : DbContext // Herdar de DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; } // Definição do DbSet para Tickets
    }
}

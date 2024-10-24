using StellantisSupportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StellantisSupportAPI.Data
{
    public class CarroContext : DbContext
    {
        public CarroContext(DbContextOptions<CarroContext> options) : base(options) { }

        public DbSet<ConsumoDesempenho> ConsumoDesempenhos { get; set; }
        public DbSet<PesoDimensoes> PesoDimensoes { get; set; }
        public DbSet<Rodas> Rodas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsumoDesempenho>().ToTable("ConsumoDesempenho");
            modelBuilder.Entity<PesoDimensoes>().ToTable("PesoDimensoes");
            modelBuilder.Entity<Rodas>().ToTable("Rodas");
        }
    }
}

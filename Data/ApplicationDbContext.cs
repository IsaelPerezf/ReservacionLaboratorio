using Microsoft.EntityFrameworkCore;
using ReservacionLaboratorio.Models;

namespace ReservacionLaboratorio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Campus> Campus { get; set; }
        public DbSet<Edificios> Edificios { get; set; }
        public DbSet<TiposAulas> TiposAulas { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Reservaciones> Reservaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Define que Carnet debe ser NVARCHAR(50)
            modelBuilder.Entity<Usuarios>()
                .Property(u => u.Carnet)
                .HasColumnType("NVARCHAR(50)")
                .IsRequired();
        }
    }
}


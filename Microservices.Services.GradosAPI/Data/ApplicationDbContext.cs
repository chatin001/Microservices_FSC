using Microservices.Services.GradosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.GradosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Grado> Grados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 1,
                GradoCode = "100",
                GradoName = "Vicealmirante",
                GradoAbrev = "Valm."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 2,
                GradoCode = "200",
                GradoName = "Contralmirante",
                GradoAbrev = "Contralm."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 3,
                GradoCode = "300",
                GradoName = "Capitan de Navio",
                GradoAbrev = "C.de N."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 4,
                GradoCode = "400",
                GradoName = "Capitan de Fragata",
                GradoAbrev = "C.de F."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 5,
                GradoCode = "500",
                GradoName = "Capitan de Corbeta",
                GradoAbrev = "C.de C."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 6,
                GradoCode = "600",
                GradoName = "Teniente Primero",
                GradoAbrev = "Tte. 1"
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 7,
                GradoCode = "600",
                GradoName = "Teniente Segundo",
                GradoAbrev = "Tte. 2"
            });


            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 8,
                GradoCode = "800",
                GradoName = "Alferez de Frataga  ",
                GradoAbrev = "Afgta."
            });

            modelBuilder.Entity<Grado>().HasData(new Grado
            {
                GradoId = 9,
                GradoCode = "1000",
                GradoName = "Servidor Publico A",
                GradoAbrev = "SPA"
            });
        }
    }
}

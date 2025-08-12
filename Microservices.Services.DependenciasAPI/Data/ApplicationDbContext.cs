using Microservices.Services.DependenciasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.DependenciasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Dependencia> Dependencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 1,
                DependenciaName = "Direccion General de Economia",
                DependenciaAbrev = "DIRECOMAR"
            });

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 2,
                DependenciaName = "Direccion de Administracion de Personal",
                DependenciaAbrev = "DIPERADMON"
            });

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 3,
                DependenciaName = "Escuela Naval del Peru",
                DependenciaAbrev = "DIRESNA"
            });

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 4,
                DependenciaName = "Fuerza de Infanteria de la Marina",
                DependenciaAbrev = "COMFUIMAR"
            });

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 5,
                DependenciaName = "Fuerza de Operacines Especiales",
                DependenciaAbrev = "COMFOES"
            });

            modelBuilder.Entity<Dependencia>().HasData(new Dependencia
            {
                DependenciaId = 6,
                DependenciaName = "Fondo de Seguro y Cesacion",
                DependenciaAbrev = "DIFOSECE"
            });

        }

    }
}

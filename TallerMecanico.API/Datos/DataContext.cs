using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Datos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Procedimiento>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.Descripcion).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Descripcion).IsUnique();
        }

    }
}

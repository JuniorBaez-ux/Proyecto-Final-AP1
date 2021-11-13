using Microsoft.EntityFrameworkCore;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Data
{
    public class Contexto : DbContext
    {
        DbSet<Clientes> Cliente { get; set; }
        DbSet<Prestamos> Prestamos { get; set; }
        DbSet<Garantes> Garantes { get; set; }
        DbSet<Cobros> Cobros { get; set; }
        DbSet<Empleados> Empleados { get; set; }
        DbSet<Negocios> Negocios { get; set; }
        DbSet<Administradores> Administradores { get; set; }
        DbSet<InformacionesContables> InformacionesContables { get; set; }
        DbSet<Sexos> Sexos { get; set; }
        DbSet<Viviendas> Viviendas { get; set; }
        DbSet<EstadosCiviles> EstadosCiviles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = data\prestamoscontrol.db"); ;
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sexos>().HasData(
            new Sexos { SexoId = 1, Descripcion = "Masculino" },
            new Sexos { SexoId = 2, Descripcion = "Femenino" }

            );



            modelBuilder.Entity<Viviendas>().HasData(
            new Viviendas { ViviendaId = 1, Descripcion = "Alquilada" },
            new Viviendas { ViviendaId = 2, Descripcion = "Casa propia" }
            );



            modelBuilder.Entity<EstadosCiviles>().HasData(
            new EstadosCiviles { EstadoCivilId = 1, Descripcion = "Soltero/a" },
            new EstadosCiviles { EstadoCivilId = 2, Descripcion = "Casado/a" },
            new EstadosCiviles { EstadoCivilId = 3, Descripcion = "Divorciado/a" },
            new EstadosCiviles { EstadoCivilId = 4, Descripcion = "Viuda/o" },
            new EstadosCiviles { EstadoCivilId = 5, Descripcion = "Union Libre" }
            );
        }
    }
}


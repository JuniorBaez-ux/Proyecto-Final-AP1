using Microsoft.EntityFrameworkCore;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.DAL
{
    public class Contexto : DbContext
    {
       public DbSet<Clientes> Cliente { get; set; }
       public DbSet<Prestamos> Prestamos { get; set; }
       public  DbSet<Garantes> Garantes { get; set; }
       public  DbSet<Cobros> Cobros { get; set; }
       public  DbSet<Empleados> Empleados { get; set; }
       public  DbSet<Negocios> Negocios { get; set; }
       public  DbSet<Administradores> Administradores { get; set; }
       public  DbSet<InformacionesContables> InformacionesContables { get; set; }
       public  DbSet<Sexos> Sexos { get; set; }
       public  DbSet<Viviendas> Viviendas { get; set; }
       public  DbSet<EstadosCiviles> EstadosCiviles { get; set; }



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


using Microsoft.EntityFrameworkCore;
using Proyecto_Final_AP1.BLL;
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
        public DbSet<Cobros> Cobros { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<Garantes> Garantes { get; set; }
        public DbSet<Moras> Moras { get; set; }
        public DbSet<Negocios> Negocios { get; set; }
        public DbSet<Ocupaciones> Ocupaciones { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Sexos> Sexos { get; set; }
        public DbSet<TipoNegocios> TipoNegocios { get; set; }
        public DbSet<TipoViviendas> TipoViviendas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<PrestamosDetalle> PrestamosDetalle { get; set; }
        public DbSet<UsuariosDetalle> UsuariosDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = data\prestamoscontrol.db"); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios { UsuarioId = 1, Nombres = "Diego" , Clave = UsuariosBLL.SHA1("1234") }
            

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sexos>().HasData(
            new Sexos { SexoId = 1, Descripcion = "Masculino" },
            new Sexos { SexoId = 2, Descripcion = "Femenino" }

            );



            modelBuilder.Entity<TipoViviendas>().HasData(
            new TipoViviendas { TipoViviendasId = 1, Descripcion = "Alquilada" },
            new TipoViviendas { TipoViviendasId = 2, Descripcion = "Casa propia" }
            );



            modelBuilder.Entity<EstadosCiviles>().HasData(
            new EstadosCiviles { EstadoCivilId = 1, Descripcion = "Soltero/a" },
            new EstadosCiviles { EstadoCivilId = 2, Descripcion = "Casado/a" },
            new EstadosCiviles { EstadoCivilId = 3, Descripcion = "Divorciado/a" },
            new EstadosCiviles { EstadoCivilId = 4, Descripcion = "Viuda/o" },
            new EstadosCiviles { EstadoCivilId = 5, Descripcion = "Union Libre" }
            );



            modelBuilder.Entity<Ocupaciones>().HasData(
           new Ocupaciones { OcupacionId = 1, Descripcion = "Ingeniero/a" },
           new Ocupaciones { OcupacionId = 2, Descripcion = "Doctor/a" },
           new Ocupaciones { OcupacionId = 3, Descripcion = "Abogado/a" },
           new Ocupaciones { OcupacionId = 4, Descripcion = "Arquitecto/a" },
           new Ocupaciones { OcupacionId = 5, Descripcion = "Contable" },
           new Ocupaciones { OcupacionId = 6, Descripcion = "Desarrolador Web" },
           new Ocupaciones { OcupacionId = 7, Descripcion = "Asistente Medico" },
           new Ocupaciones { OcupacionId = 8, Descripcion = "Diseñador Grafico" },
           new Ocupaciones { OcupacionId = 9, Descripcion = "Consultor de Ciberseguridad" },
           new Ocupaciones { OcupacionId = 10, Descripcion = "Asesor Financiero" },
           new Ocupaciones { OcupacionId = 11, Descripcion = "Representante de ventas" },
           new Ocupaciones { OcupacionId = 12, Descripcion = "Odontologo" }
           );



            modelBuilder.Entity<TipoNegocios>().HasData(
          new TipoNegocios { TipoNegocioId = 1, Descripcion = "Colmado" },
          new TipoNegocios { TipoNegocioId = 2, Descripcion = "Hospital" },
          new TipoNegocios { TipoNegocioId = 3, Descripcion = "Almacen" },
          new TipoNegocios { TipoNegocioId = 4, Descripcion = "Oficina" },
          new TipoNegocios { TipoNegocioId = 5, Descripcion = "Banco" },
          new TipoNegocios { TipoNegocioId = 6, Descripcion = "Guarderia" },
          new TipoNegocios { TipoNegocioId = 7, Descripcion = "Supermercado" },
          new TipoNegocios { TipoNegocioId = 8, Descripcion = "Libreria" },
          new TipoNegocios { TipoNegocioId = 9, Descripcion = "Veterinaria" },
          new TipoNegocios { TipoNegocioId = 10, Descripcion = "Botica" },
          new TipoNegocios { TipoNegocioId = 11, Descripcion = "Farmacia" },
          new TipoNegocios { TipoNegocioId = 12, Descripcion = "Clinica" }
          );



            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permisos>().HasData(
                new Permisos() { PermisoId = 1, Nombre = "Modifica", Descripcion = "Este permiso puede modificar datos" },
                new Permisos() { PermisoId = 2, Nombre = "Elimina", Descripcion = "Este permiso puede eliminar datos" },
                new Permisos() { PermisoId = 3, Nombre = "Agrega", Descripcion = "Este permiso puede agregar datos" }
            );
        }
    }
}


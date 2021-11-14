using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final_AP1.DAL;
using Proyecto_Final_AP1.Entidades;

namespace Proyecto_Final_AP1.BLL
{
  public  class EmpleadosBLL
    {
        public static bool Guardar(Empleados empleado)
        {
            if (!Existe(empleado.EmpleadoId))
            {
                return Insertar(empleado);
            }
            else
            {
                return Modificar(empleado);
            }
        }

        public static bool Insertar(Empleados empleado)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Empleados.Add(empleado);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Empleados empleado)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where EmpleadoId ={empleado.EmpleadoId}");
                foreach (var item in empleado.Contraseña)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(empleado).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Empleados = contexto.Empleados.Find(id);
                if (Empleados != null)
                {
                    contexto.Entry(Empleados).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Empleados.Any(e => e.EmpleadoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static Empleados Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Empleados empleado;
            try
            {
                empleado = contexto.Empleados.Include(e => e.Contraseña).Where(p => p.EmpleadoId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return empleado;
        }

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> criterio)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Empleados.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Empleados> GetViviendas()
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Empleados.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
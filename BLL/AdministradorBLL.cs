using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final_AP1.Entidades;
using Proyecto_Final_AP1.DAL;

namespace Proyecto_Final_AP1.BLL
{
   public   class AdministradorBLL
    {
        public static bool Guardar(Administradores administrador)
        {
            if (!Existe(administrador.AdministradorId))
            {
                return Insertar(administrador);
            }
            else
            {
                return Modificar(administrador);
            }
        }

        public static bool Insertar(Administradores administrador)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Administradores.Add(administrador);
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

        public static bool Modificar(Administradores administrador)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle Where AdministradorId ={administrador.AdministradorId}");
                foreach (var item in administrador.Contraseña)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(administrador).State = EntityState.Modified;
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
                var Administradores = contexto.Administradores.Find(id);
                if (Administradores != null)
                {
                    contexto.Entry(Administradores).State = EntityState.Deleted;
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
                encontrado = contexto.Administradores.Any(e => e.AdministradorId == id);
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

        public static Administradores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Administradores cliente;
            try
            {
                cliente = contexto.Administradores.Include(e => e.Contraseña).Where(p => p.AdministradorId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static List<Administradores> GetList(Expression<Func<Administradores, bool>> criterio)
        {
            List<Administradores> lista = new List<Administradores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Administradores.Where(criterio).ToList();
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

        public static List<Administradores> GetViviendas()
        {
            List<Administradores> lista = new List<Administradores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Administradores.ToList();
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

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
    public class NegociosBLL
    {
        public static bool Guardar(Negocios negocio)
        {
            negocio.UsuarioId = MainWindow.user.UsuarioId;
            if (!Existe(negocio.NegocioId))
            {
                if (!ExisteNombre(negocio.Nombre))
                {
                    if (!ExisteTelefono(negocio.Telefono))
                    {
                        return Insertar(negocio);
                    }
                    return false;
                }
                return false;
            }
            else
            {
                return Modificar(negocio);
            }

        }

        public static bool Insertar(Negocios negocio)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Negocios.Add(negocio);
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

        public static bool Modificar(Negocios negocio)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(negocio).State = EntityState.Modified;
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
                Negocios negocio = contexto.Negocios.Find(id);
                if (Existe(id))
                {
                    negocio.UsuarioId = MainWindow.user.UsuarioId;
                    contexto.Negocios.Remove(negocio);
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
                encontrado = contexto.Negocios.Any(e => e.NegocioId == id);
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

        public static Negocios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Negocios negocio;
            try
            {
                negocio = contexto.Negocios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return negocio;
        }
        public static Negocios Buscar(int id, string Telefono)
        {
            Contexto contexto = new Contexto();
            Negocios negocio;
            try
            {
                negocio = contexto.Negocios.FirstOrDefault(x => x.NegocioId == id && x.Telefono.Equals(Telefono));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return negocio;
        }

        public static List<Negocios> GetList(Expression<Func<Negocios, bool>> criterio)
        {
            List<Negocios> lista = new List<Negocios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Negocios.Where(criterio).ToList();
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

        public static bool ExisteNombre(string Nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Negocios.Any(e => e.Nombre.ToLower() == Nombre.ToLower());
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
        public static bool ExisteTelefono(string Telefono)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.Negocios.Any(e => e.Telefono.ToLower() == Telefono.ToLower());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
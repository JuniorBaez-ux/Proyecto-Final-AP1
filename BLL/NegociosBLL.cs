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
            if (!Existe(negocio.NegocioId))
            {
                return Insertar(negocio);
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
                var Negocios = contexto.Negocios.Find(id);
                if (Negocios != null)
                {
                    contexto.Entry(Negocios).State = EntityState.Deleted;
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

        public static List<Negocios> GetViviendas()
        {
            List<Negocios> lista = new List<Negocios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Negocios.ToList();
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
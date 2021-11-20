using Microsoft.EntityFrameworkCore;
using Proyecto_Final_AP1.DAL;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.BLL
{
    public class SexosBLL
    {
         public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Sexos.Any(e => e.SexoId == id);
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
        private static bool Insertar(Sexos sexos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Add(sexos);
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

        private static bool Modificar(Sexos sexos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(sexos).State = EntityState.Modified;
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

        public static bool Guardar(Sexos sexos)
        {
            if (!Existe(sexos.SexoId))
                return Insertar(sexos);
            else
                return Modificar(sexos);
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Sexos = contexto.Sexos.Find(id);
                if (Sexos != null)
                {
                    contexto.Entry(Sexos).State = EntityState.Deleted;
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

        public static Sexos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Sexos sexos;

            try
            {
                sexos = contexto.Sexos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return sexos;
        }
        public static List<Sexos> GetList(Expression<Func<Sexos, bool>> criterio)
        {
            List<Sexos> lista = new List<Sexos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Sexos.Where(criterio).ToList();
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

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
    public class EstadosCivilesBLL
    {

        public static bool Guardar(EstadosCiviles estadosCiviles)
        {
            if (!Existe(estadosCiviles.EstadoCivilId))
            {
                return Insertar(estadosCiviles);
            }
            else
            {
                return Modificar(estadosCiviles);
            }
        }

        public static bool Insertar(EstadosCiviles estadosCiviles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.EstadosCiviles.Add(estadosCiviles);
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

        public static bool Modificar(EstadosCiviles estadosCiviles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(estadosCiviles).State = EntityState.Modified;
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
                var EstadosCiviles = contexto.EstadosCiviles.Find(id);
                if (EstadosCiviles != null)
                {
                    contexto.Entry(EstadosCiviles).State = EntityState.Deleted;
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
                encontrado = contexto.EstadosCiviles.Any(e => e.EstadoCivilId == id);
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

        public static EstadosCiviles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EstadosCiviles estadosCiviles;
            try
            {
                estadosCiviles = contexto.EstadosCiviles.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estadosCiviles;
        }

        

        public static List<EstadosCiviles> GetList(Expression<Func<EstadosCiviles, bool>> criterio)
        {
            List<EstadosCiviles> lista = new List<EstadosCiviles>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.EstadosCiviles.Where(criterio).ToList();
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

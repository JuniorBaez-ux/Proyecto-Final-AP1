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
    public class PrestamosDetalleBLL
    {
        public static PrestamosDetalle Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PrestamosDetalle prestamosdetalle;
            try
            {
                prestamosdetalle = contexto.PrestamosDetalle.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamosdetalle;
        }

        public static List<PrestamosDetalle> GetPrestamosDetalle()
        {
            List<PrestamosDetalle> lista = new List<PrestamosDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.PrestamosDetalle.ToList();
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

        public static List<PrestamosDetalle> GetList(Expression<Func<PrestamosDetalle, bool>> criterio)
        {
            List<PrestamosDetalle> lista = new List<PrestamosDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.PrestamosDetalle.Where(criterio).ToList();
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

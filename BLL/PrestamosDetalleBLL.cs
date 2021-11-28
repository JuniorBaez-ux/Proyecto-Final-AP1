using Proyecto_Final_AP1.DAL;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

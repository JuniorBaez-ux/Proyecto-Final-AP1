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

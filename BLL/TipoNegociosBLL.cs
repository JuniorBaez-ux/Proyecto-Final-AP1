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
    public class TipoNegociosBLL
    {
        public static List<TipoNegocios> GetList(Expression<Func<TipoNegocios, bool>> criterio)
        {
            List<TipoNegocios> lista = new List<TipoNegocios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoNegocios.Where(criterio).ToList();
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

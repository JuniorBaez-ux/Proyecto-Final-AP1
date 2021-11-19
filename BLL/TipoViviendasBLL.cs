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
    public class TipoViviendasBLL
    {
        public static List<TipoViviendas> GetList(Expression<Func<TipoViviendas, bool>> criterio)
        {
            List<TipoViviendas> lista = new List<TipoViviendas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Viviendas.Where(criterio).ToList();
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

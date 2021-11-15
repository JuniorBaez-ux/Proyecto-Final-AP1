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
    public class ViviendasBLL
    {
        public static List<Viviendas> GetList(Expression<Func<Viviendas, bool>> criterio)
        {
            List<Viviendas> lista = new List<Viviendas>();
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

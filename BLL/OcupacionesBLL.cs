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
    public class OcupacionesBLL
    {
        public static List<Ocupaciones> GetList(Expression<Func<Ocupaciones, bool>> criterio)
        {
            List<Ocupaciones> lista = new List<Ocupaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ocupaciones.Where(criterio).ToList();
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

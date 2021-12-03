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
    public class UsuariosDetalleBLL
    {
        public static UsuariosDetalle Buscar(int id)
        {
            Contexto db = new Contexto();
            UsuariosDetalle usuariosdetalle;
            try
            {
                usuariosdetalle = db.UsuariosDetalle.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return usuariosdetalle;
        }

        public static List<UsuariosDetalle> GetUsuariosDetalle()
        {
            List<UsuariosDetalle> lista = new List<UsuariosDetalle>();
            Contexto db = new Contexto();
            try
            {
                lista = db.UsuariosDetalle.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<UsuariosDetalle> GetList(Expression<Func<UsuariosDetalle, bool>> criterio)
        {
            List<UsuariosDetalle> lista = new List<UsuariosDetalle>();
            Contexto db = new Contexto();
            try
            {
                lista = db.UsuariosDetalle.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}

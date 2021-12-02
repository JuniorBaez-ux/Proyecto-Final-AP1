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
    public class TipoViviendasBLL
    {

        public static bool Guardar(TipoViviendas tipoViviendas)
        {
            if (!Existe(tipoViviendas.TipoViviendasId))
            {
                return Insertar(tipoViviendas);
            }
            else
            {
                return Modificar(tipoViviendas);
            }
        }

        public static bool Insertar(TipoViviendas tipoViviendas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.TipoViviendas.Add(tipoViviendas);
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

        public static bool Modificar(TipoViviendas tipoViviendas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tipoViviendas).State = EntityState.Modified;
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
                var TipoViviendas = contexto.TipoViviendas.Find(id);
                if (TipoViviendas != null)
                {
                    contexto.Entry(TipoViviendas).State = EntityState.Deleted;
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
                encontrado = contexto.TipoViviendas.Any(e => e.TipoViviendasId == id);
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

        public static TipoViviendas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TipoViviendas tipoViviendas;
            try
            {
                tipoViviendas = contexto.TipoViviendas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tipoViviendas;
        }





        public static List<TipoViviendas> GetList(Expression<Func<TipoViviendas, bool>> criterio)
        {
            List<TipoViviendas> lista = new List<TipoViviendas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoViviendas.Where(criterio).ToList();
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

        public static List<TipoViviendas> GetTipoViviendas()
        {
            List<TipoViviendas> lista = new List<TipoViviendas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoViviendas.ToList();
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
        public static bool ExisteDescripcion(string descripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.TipoViviendas.Any(e => e.Descripcion.ToLower() == descripcion.ToLower());
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
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final_AP1.Entidades;
using Proyecto_Final_AP1.DAL;

namespace Proyecto_Final_AP1.BLL
{
   public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            if (!Existe(cobro.CobroId))
            {
                return Insertar(cobro);
            }
            else
            {
                return Modificar(cobro);
            }
        }

        public static bool Insertar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Cobros.Add(cobro);
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

        public static bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM CobrosDetalle Where CobrosId ={cobro.CobroId}");
                foreach (var item in cobro.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(cobro).State = EntityState.Modified;
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
                var Cobros = contexto.Cobros.Find(id);
                if (Cobros != null)
                {
                    contexto.Entry(Cobros).State = EntityState.Deleted;
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
                encontrado = contexto.Cobros.Any(e => e.CobroId == id);
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

        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobro;
            try
            {
                cobro = contexto.Cobros.Include(e => e.Detalle).Where(p => p.CobroId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cobro;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> criterio)
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cobros.Where(criterio).ToList();
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

        public static List<Cobros> GetCobros()
        {
            List<Cobros> lista = new List<Cobros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cobros.ToList();
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
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
   public class GarantesBLL
    {
       
        public static bool Guardar(Garantes garante)
        {
            garante.UsuarioId = MainWindow.user.UsuarioId;

            if (!Existe(garante.GaranteId))
            {
                return Insertar(garante);
            }
            else
            {
                return Modificar(garante);
            }
        }

        public static bool Insertar(Garantes garante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Garantes.Add(garante);
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

        public static bool Modificar(Garantes garante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(garante).State = EntityState.Modified;
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
                var Garantes = contexto.Garantes.Find(id);
                if (Garantes != null)
                {
                    contexto.Entry(Garantes).State = EntityState.Deleted;
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
                encontrado = contexto.Garantes.Any(e => e.GaranteId == id);
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

        public static Garantes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Garantes garante;
            try
            {
                garante = contexto.Garantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return garante;
        }

        public static List<Garantes> GetList(Expression<Func<Garantes, bool>> criterio)
        {
            List<Garantes> lista = new List<Garantes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Garantes.Where(criterio).ToList();
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

        public static List<Garantes> GetGarantes()
        {
            List<Garantes> lista = new List<Garantes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Garantes.ToList();
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
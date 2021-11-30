using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Final_AP1.DAL;
using Proyecto_Final_AP1.Entidades;

namespace Proyecto_Final_AP1.BLL
{
   public class ClientesBLL
    {
        static Clientes clientes = new Clientes();
        public static bool Guardar(Clientes cliente)
        {
            clientes.UsuarioId = MainWindow.user.UsuarioId;   
            if (!Existe(cliente.ClienteId))
            {
                return Insertar(cliente);
            }
            else
            {
                return Modificar(cliente);
            }
        }

        public static bool Insertar(Clientes cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Cliente.Add(cliente);
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

        public static bool Modificar(Clientes cliente)
        {
            clientes.UsuarioId = MainWindow.user.UsuarioId;
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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
            clientes.UsuarioId = MainWindow.user.UsuarioId;
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Clientes = contexto.Cliente.Find(id);
                if (Clientes != null)
                {
                    contexto.Entry(Clientes).State = EntityState.Deleted;
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
                encontrado = contexto.Cliente.Any(e => e.ClienteId == id);
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

        public static bool ExisteNombre(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Cliente.Any(e => e.Nombres.ToLower() == nombre.ToLower());
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

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente;
            try
            {
                cliente = contexto.Cliente.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cliente.Where(criterio).ToList();
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

        public static List<Clientes> GetViviendas()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cliente.ToList();
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
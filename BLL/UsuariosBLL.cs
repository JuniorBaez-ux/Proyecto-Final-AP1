using Microsoft.EntityFrameworkCore;
using Proyecto_Final_AP1.DAL;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.BLL
{
    public class UsuariosBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base de datos
        /// </summary>

        public static bool Guardar(Usuarios usuario)
        {
            usuario.UsuarioId = MainWindow.user.UsuarioId;
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }
        private static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                foreach (var item in usuario.Detalle)
                {
                    var permiso = db.Permisos.Find(item.PermisoId);
                    permiso.VecesAsignado++;
                    db.Entry(permiso).State = EntityState.Modified;
                }

                if (db.Usuarios.Add(usuario) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Modificar una entidad en la base de datos
        /// </summary>
        private static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var usuarioAnterior = db.Usuarios.Where(x => x.UsuarioId == usuario.UsuarioId).Include(x => x.Detalle).AsNoTracking().FirstOrDefault();
                foreach (var item in usuarioAnterior.Detalle)
                {
                    var permiso = db.Permisos.Find(item.PermisoId);
                    permiso.VecesAsignado--;
                    db.Entry(permiso).State = EntityState.Modified;
                }


                //busca la entidad en la base de datos y la elimina
                db.Database.ExecuteSqlRaw($"Delete FROM UsuariosDetalle Where UsuarioId={usuario.UsuarioId}");

                foreach (var item in usuario.Detalle)
                {
                    item.Id = 0;
                    var permiso = db.Permisos.Find(item.PermisoId);
                    permiso.VecesAsignado++;
                    db.Entry(permiso).State = EntityState.Modified;
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(usuario).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (Existe(id))
                {

                    Usuarios usuario = Buscar(id);
                    usuario.UsuarioId = MainWindow.user.UsuarioId;
                    foreach (var item in usuario.Detalle)
                    {
                        var permiso = db.Permisos.Find(item.PermisoId);
                        permiso.VecesAsignado--;
                        db.Entry(permiso).State = EntityState.Modified;
                    }


                    db.Usuarios.Remove(usuario);
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        public static Usuarios Buscar(int id)
        {
            Contexto db = new Contexto();
            Usuarios usuario = new Usuarios();
            try
            {
                usuario = db.Usuarios.Include(x => x.Detalle).Where(x => x.UsuarioId == id).SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuario;
        }
        /// <summary>
        /// Permite extraer una lista de Usuarios de la base de datos
        /// </summary>
        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> Usuarios = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                Usuarios = db.Usuarios.Where(expression).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Usuarios;
        }
        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Usuarios.Any(x => x.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static Usuarios BuscarPorNombre(string Nombres)
        {
            Contexto db = new Contexto();
            Usuarios Usuario = new Usuarios();
            try
            {
                Usuario = db.Usuarios.Where(x => Nombres.ToLower() == x.Nombres.ToLower()).SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Usuario;
        }

        public static bool Login(string Nombres, string contraseña)
        {
            Usuarios usuario = BuscarPorNombre(Nombres);

            if (usuario != null)
            {
                return usuario.Clave.Equals(contraseña);
            }
            else
                return false;

        }
        public static string SHA1(string contraseña)
        {
            using (SHA1Managed SHa1 = new SHA1Managed())
            {
                var hash = SHa1.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

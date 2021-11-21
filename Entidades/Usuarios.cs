using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }


        public List<UsuariosDetalle> Detalle { get; set; }

        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }

        public int PermisoId { get; set; }
        [ForeignKey("PermisoId")]
        public virtual Permisos Permiso { get; set; }

        public Usuarios()
        {
            RolId = 0;
            UsuarioId = 0;
            FechaCreacion = DateTime.Now;
            Clave = "";
            Nombres = string.Empty;
            Email = string.Empty;
            Activo = false;
            Detalle = new List<UsuariosDetalle>();
        }
    }
}

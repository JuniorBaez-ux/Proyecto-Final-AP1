using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class UsuariosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PermisoId { get; set; }


        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }


        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }
        public int RolId { get; internal set; }
    }
}

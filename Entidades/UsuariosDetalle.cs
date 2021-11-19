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
        public int PermisoId { get; set; }


        [ForeignKey("RolId")]
        public List<Roles> Roles { get; set; }


        [ForeignKey("UsuarioId")]
        public List<Usuarios> Usuarios { get; set; }
    }
}

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
        public string Email { get; set; }
        public bool Activo { get; set; }


        [ForeignKey("DetalleId")]
        public List<UsuariosDetalle> Detalle { get; set; }


        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }

    }
}

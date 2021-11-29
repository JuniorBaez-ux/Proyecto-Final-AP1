using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public virtual Usuarios Usuarios { get; set; }

        public Roles()
        {
            RolId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;

        }
    }
}

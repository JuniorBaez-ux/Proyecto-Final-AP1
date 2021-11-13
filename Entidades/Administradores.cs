using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Administradores
    {
        [Key]
        public int AdministradorId { get; set; }
        public string Nombres { get; set; }
        public string Contraseña { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleados Empleados { get; set; }
    }
}

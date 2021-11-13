using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Contraseña { get; set; }

        [ForeignKey("CobroId")]
        public virtual Cobros Cobros { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos Prestamos { get; set; }

        [ForeignKey("NegocioId")]
        public virtual Negocios Negocios { get; set; }

        [ForeignKey("GaranteId")]
        public virtual Garantes Garantes { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }
    }
}

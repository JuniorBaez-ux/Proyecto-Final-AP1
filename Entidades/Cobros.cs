using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int Monto { get; set; }

        public int ClienteId { get; set; }

        public Cobros()
        {
            CobroId = 0;
            Monto = 0;
            Detalle = new List<CobrosDetalle>();
        }

        [ForeignKey("DetalleId")]
        public List<CobrosDetalle> Detalle { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos Prestamos { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }
    }
}

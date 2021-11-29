using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public int PrestamoId { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos Prestamos { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Clientes Clientes { get; set; }


    }
}

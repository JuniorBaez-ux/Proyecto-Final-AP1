using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("CobroId")]
        public virtual Cobros Cobros{ get; set; }
    }
}

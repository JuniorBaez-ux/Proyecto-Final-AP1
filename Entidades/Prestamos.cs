using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public double Monto { get; set; }
        public int Cuotas { get; set; }
        public double Interes { get; set; }
        public float Balance { get; set; }

        [ForeignKey("DetalleId")]
        public List<PrestamosDetalle> Detalle { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class PrestamosDetalle
    {
        [Key]
        public int CuotaId { get; set; }
        public int NumeroCuota { get; set; }
        public DateTime FechaCuota { get; set; }
        public double Interes { get; set; }
        public int Capital { get; set; }
        public int BalanceInteres { get; set; }
        public int BalanceCapital { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos Prestamos { get; set; }
    }
}

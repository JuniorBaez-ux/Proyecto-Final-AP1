using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class PrestamosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
    }
}

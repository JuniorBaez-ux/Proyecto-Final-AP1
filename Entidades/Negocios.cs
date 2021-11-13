using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Negocios
    {
        [Key]
        public int NegocioId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Actividad { get; set; }
        public int TiempoLaborando { get; set; }
        public double Ingresos { get; set; }
        public string Direccion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Garantes
    {
        [Key]
        public int GaranteId { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Parentesco { get; set; }
        public int Ingresos { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

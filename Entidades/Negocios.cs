using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime FechaN { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        [ForeignKey("TipoNegocioId")]
        public virtual TipoNegocios TipoNegocios { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }
    }
}

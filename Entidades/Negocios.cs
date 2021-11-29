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
        public DateTime FechaN { get; set; } = DateTime.Now;
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int TipoNegocioId { get; set; } 
        [ForeignKey("TipoNegocioId")]
        public virtual TipoNegocios TipoNegocios { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public int ClientesId { get; set; }

        [ForeignKey("ClientesId")]
        public virtual Clientes Clientes { get; set; }
    }
}

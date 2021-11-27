using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Apodo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Dependientes { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Vivienda { get; set; }
        public string Ocupacion { get; set; }

        [ForeignKey("NegocioId")]
        public virtual Negocios Negocios { get; set; }

        [ForeignKey("GaranteId")]
        public virtual Garantes Garantes { get; set; }

        [ForeignKey("TipoViviendasId")]
        public virtual TipoViviendas Viviendas { get; set; }

        [ForeignKey("SexoId")]
        public virtual Sexos Sexos { get; set; }

        [ForeignKey("EstadoCivilId")]
        public virtual EstadosCiviles EstadosCiviles { get; set; }

        [ForeignKey("OcupacionId")]
        public virtual Ocupaciones Ocupaciones{ get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios{ get; set; }
    }
}

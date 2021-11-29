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

        public int NumeroCuota { get; set; }

        public decimal ValorCuota { get; set; }

        public CobrosDetalle()
        {
            NumeroCuota = 0;
            ValorCuota = 0;
            BalanceCuota = 0;
        }

        public CobrosDetalle(int numeroCuota, decimal valorCuota, decimal balanceCuota)
        {
            NumeroCuota = numeroCuota;
            ValorCuota = valorCuota;
            BalanceCuota = balanceCuota;
        }

        public CobrosDetalle(int detalleId, int numeroCuota, decimal valorCuota, decimal balanceCuota, Cobros cobros)
        {
            DetalleId = detalleId;
            NumeroCuota = numeroCuota;
            ValorCuota = valorCuota;
            BalanceCuota = balanceCuota;
            Cobros = cobros;
        }

        public decimal BalanceCuota { get; set; }

        [ForeignKey("CobroId")]
        public virtual Cobros Cobros{ get; set; }
    }
}

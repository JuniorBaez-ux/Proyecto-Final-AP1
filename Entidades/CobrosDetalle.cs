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
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroCuota { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal BalanceCapital { get; set; }
        public decimal BalanceInteres { get; set; }
        public decimal BalanceCuota { get; set; }

        [ForeignKey("CobroId")]
        public int CobroId { get; set; }
        public virtual Cobros Cobros { get; set; }

        public CobrosDetalle()
        {
            Id = 0;
            Fecha = DateTime.Now;
            NumeroCuota = 0;
            ValorCuota = 0;
            Capital = 0;
            Interes = 0;
            BalanceCapital = 0;
            BalanceInteres = 0;
            BalanceCuota = 0;
            CobroId = 0;
        }

        public CobrosDetalle(int detalleId, DateTime fecha, int numeroCuota, decimal valorCuota, decimal capital, decimal interes, decimal balanceCapital, decimal balanceInteres, decimal balanceCuota, Cobros cobros)
        {
            Id = detalleId;
            Fecha = fecha;
            NumeroCuota = numeroCuota;
            ValorCuota = valorCuota;
            Capital = capital;
            Interes = interes;
            BalanceCapital = balanceCapital;
            BalanceInteres = balanceInteres;
            BalanceCuota = balanceCuota;
            Cobros = cobros;
        }
    }
}

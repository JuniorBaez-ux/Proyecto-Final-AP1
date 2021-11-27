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
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal BalanceCuota { get; set; }
        public decimal BalanceInteres { get; set; }
        public decimal BalanceCapital { get; set; }

        [ForeignKey("PrestamoId")]
        public int PrestamoId { get; set; }
        public virtual Prestamos Prestamos { get; set; }

        public PrestamosDetalle()
        {
            CuotaId = 0;
            NumeroCuota = 0;
            FechaCuota = DateTime.Now;
            ValorCuota = 0;
            Interes = 0;
            Capital = 0;
            BalanceInteres = 0;
            BalanceCapital = 0;
            BalanceCuota = 0;
        }

        public PrestamosDetalle(int cuotaId, int numeroCuota, DateTime fechaCuota, decimal interes, decimal capital, decimal valorCuota, decimal saldoCapital, decimal balanceInteres, decimal balanceCapital, int prestamoId, Prestamos prestamos
            )
        {
            CuotaId = cuotaId;
            NumeroCuota = numeroCuota;
            FechaCuota = fechaCuota;
            Interes = interes;
            Capital = capital;
            ValorCuota = valorCuota;
            BalanceCuota = saldoCapital;
            BalanceInteres = balanceInteres;
            BalanceCapital = balanceCapital;
            PrestamoId = prestamoId;
            Prestamos = prestamos;
        }
    }
}

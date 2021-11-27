using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.BLL
{

    public static class Utilidades
    {
        public static int ToInt(this string valor)
        {
            int retorno;

            int.TryParse(valor, out retorno);

            return retorno;
        }
        public static Decimal ToDecimal(this string valor)
        {
            Decimal retorno;

            Decimal.TryParse(valor, out retorno);

            return retorno;
        }
        public static double ToDouble(this object valor)
        {
            double retorno;

            double.TryParse(valor.ToString(), out retorno);

            return retorno;
        }
        public static decimal Pow(object x,object y)
        {
            decimal retorno;

            retorno = Math.Pow(x.ToDouble(), y.ToDouble()).ToString().ToDecimal();

            return retorno;
        }
    }
}
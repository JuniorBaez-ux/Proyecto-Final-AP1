﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.BLL
{

    public class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno;

            int.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
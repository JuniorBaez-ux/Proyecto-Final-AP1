﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_AP1.Entidades
{
    public class InformacionesContables
    {
        [Key]
        public int InformacionContableId { get; set; }
        public float Ingresos { get; set; }
        public DateTime FechaIngresos { get; set; }
    }
}
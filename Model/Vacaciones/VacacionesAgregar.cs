﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Model.Vacaciones
{
    public class VacacionesAgregar
    {
        [Display(Name = "ID Empleado")]
        public int empleadoID { get; set; }

        [Display(Name = "Fecha Solicitud")]
        public DateFormat fechaSolicitud { get; set; }

        [Display(Name = "Dias Solicitados")]
        public int diasSolicitados { get; set; }

        [Display(Name = "Fecha Salida")]
        public DateFormat fechaSalida { get; set; }

        [Display(Name = "Fecha Entrada")]
        public DateFormat fechaEntrada { get; set; }

    }
}
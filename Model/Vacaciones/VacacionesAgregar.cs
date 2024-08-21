using System;
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
        public int? empleadoID { get; set; }

        [Display(Name = "Fecha Solicitud")]
        public DateTime? fechaSolicitud { get; set; }

        [Display(Name = "Dias Solicitados")]
        public int? diasSolicitados { get; set; }

        [Display(Name = "Fecha Salida")]
        public DateTime? fechaSalida { get; set; }

        [Display(Name = "Fecha Entrada")]
        public DateTime? fechaEntrada { get; set; }

        public string? Resultado { get; set; }



    }
}

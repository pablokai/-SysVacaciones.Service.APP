using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Vacaciones
{
    public class VacacionesDetalle
    {
        public int ID { get; set; }

        public int empleadoID { get; set; }

        public DateFormat fechaSolicitud { get; set; }

        public int diasSolicitados { get; set; }

        public DateFormat fechaSalida { get; set; }

        public DateFormat fechaEntrada { get; set; }
    }
}

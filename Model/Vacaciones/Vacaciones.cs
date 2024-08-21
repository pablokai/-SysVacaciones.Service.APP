using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Vacaciones
{
    public class Vacaciones
    {
        public int ID { get; set; }

        public int empleadoID { get; set; }

        public DateTime fechaSolicitud { get; set; }

        public int diasSolicitados { get; set; }

        public DateTime fechaSalida { get; set; }

        public DateTime fechaEntrada { get; set; }
        
        public string Nombre { get; set; }

        public string Cedula { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiasDisponibles
{
    public class DisponiblesEditar
    {
        [Display(Name = "ID Días Disponibles")]
        public int disponiblesID { get; set; }

        [Display(Name = "ID Empleado")]
        public int empleadoId { get; set; }

        [Display(Name = "Días Disponibles")]
        public int diasDisponibles { get; set; }
    }
}

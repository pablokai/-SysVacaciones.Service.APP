using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiasDisponibles
{
    public class DisponiblesAgregar
    {
        [Display(Name = "ID Empleado")]
        public int Id { get; set; } 

        [Display(Name = "Días Disponibles")]
        public int diasDisponibles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DiasDisponibles
{
    public class Disponibles
    {
        public int disponiblesID { get; set; }

        public int empleadoId { get; set; }

        public int diasDisponibles { get; set; }
    }
}

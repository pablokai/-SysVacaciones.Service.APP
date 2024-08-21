using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Empleados
{
    public class Empleados
    {
        public int Id { get; set; }

        public string cedula { get; set; }

        public string primerNombre { get; set; }

        public string segundoNombre { get; set; }

        public string primerApellido { get; set; }

        public string segundoApellido { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public DateTime fechaIngreso { get; set; }

        public string telefono { get; set; }

        public string correoElectronico { get; set; }

        public string direccion { get; set; }

        public string puesto { get; set; }

        public decimal salario { get; set; }

        public string estado { get; set; }
        public int? diasDisponibles { get; set; }
    }
}

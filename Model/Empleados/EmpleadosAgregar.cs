using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Empleados
{
    public class EmpleadosAgregar
    {
        [Display(Name = "Cedula")]
        public string cedula { get; set; }

        [Display(Name = "Primer Nombre")]
        public string primerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string segundoNombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string primerApellido { get; set; }

        [Display(Name = "Primer Apellido")]
        public string segundoApellido { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateFormat fechaNacimiento { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateFormat fechaIngreso { get; set; }

        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = " Correo Electrónico")]
        public string correoElectronico { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Puesto")]
        public string puesto { get; set; }

        [Display(Name = "Salario")]
        public decimal salario { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }
    }
}

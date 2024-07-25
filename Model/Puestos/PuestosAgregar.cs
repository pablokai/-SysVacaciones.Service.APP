using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Puestos
{
    public class PuestosAgregar
    {
        [Display(Name ="Nombre Puesto")]
        public string nombrePuesto { get; set; }
    }
}

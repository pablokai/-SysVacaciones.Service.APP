using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Puestos
{
    public class PuestosEditar
    {
        [Display(Name = "ID Puesto")]
        public int puestoID { get; set; }

        [Display(Name = "Nombre Puesto")]
        public string nombrePuesto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SysVacacionesMODEL.Empleados
{
    public class EmpleadosInactivar
    {
        [Display(Name = "ID Empleado")]
        public int Id {  get; set; }
    }
}

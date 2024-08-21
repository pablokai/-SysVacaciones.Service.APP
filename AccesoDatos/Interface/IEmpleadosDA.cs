using Model.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesMODEL;
using SysVacacionesMODEL.Empleados;

namespace SysVacacionesDAL.Interface
{
    public interface IEmpleadosDA
    {
        Task<List<Empleados>> listarEmpleados();

        Task<Respuesta> insertarEmpleado(Empleados empleado);
        Task<Respuesta> editarEmpleado(Empleados empleado);
        Task<EmpleadosDetalles> obtenerEmpleado(Empleados empleado);
        Task<EmpleadosDetalles> buscarEmpleado(Empleados empleado);

        Task<EmpleadosInactivar> inactivarEmpleados(Empleados empleados);
    }
}

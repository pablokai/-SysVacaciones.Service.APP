using Model.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;
using SysVacacionesMODEL.Empleados;

namespace SysVacacionesBL
{
    public class EmpleadosBL
    {
        private readonly IEmpleadosDA empleadoDA;

        public EmpleadosBL(IEmpleadosDA empleadoDA)
        {
            this.empleadoDA = empleadoDA;
        }

        public async Task<List<Empleados>> listarEmpleados()
        {
            return await empleadoDA.listarEmpleados();
        }

        public async Task<EmpleadosAgregar> insertarEmpleado(Empleados empleado)
        {
            return await empleadoDA.insertarEmpleado(empleado);
        }

        public async Task<EmpleadosEditar> editarEmpleado(Empleados empleado)
        {
            return await empleadoDA.editarEmpleado(empleado);
        }

        public async Task<EmpleadosDetalles> obtenerEmpleados(Empleados empleado)
        {
            return await empleadoDA.obtenerEmpleado(empleado);
        }

        public async Task<EmpleadosDetalles> buscarEmpleado(Empleados empleado)
        {
            return await empleadoDA.buscarEmpleado(empleado);
        }


        public async Task<EmpleadosInactivar> inactivarEmpleados(Empleados empleados)
        {
            return await empleadoDA.inactivarEmpleados(empleados);
        }
    }
}

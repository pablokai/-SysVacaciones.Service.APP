using Model.Empleados;
using Model.Vacaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;

namespace SysVacacionesBL
{
    public class VacacionesBL
    {
        private readonly IVacacionesDA vacacionesDA;

        public VacacionesBL(IVacacionesDA vacacionesDA)
        {
            this.vacacionesDA = vacacionesDA;
        }

        public async Task<List<Vacaciones>> listarVacaciones()
        {
            return await vacacionesDA.listarVacaciones();
        }

        public async Task<Respuesta> insertarVacaciones(VacacionesAgregar vacaciones)
        {
            return await vacacionesDA.insertarVacaciones(vacaciones);
        }

        public async Task<VacacionesEditar> editarVacaciones(Vacaciones vacaciones)
        {
            return await vacacionesDA.editarVacaciones(vacaciones);
        }

        public async Task<VacacionesDetalle> obtenerVacaciones(Vacaciones vacaciones)
        {
            return await vacacionesDA.obtenerVacaciones(vacaciones);
        }
    }
}

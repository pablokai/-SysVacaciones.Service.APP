using Model.DiasDisponibles;
using Model.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;

namespace SysVacacionesBL
{
    public class DisponiblesBL
    {
        private readonly IDisponiblesDA disponibleDA;

        public DisponiblesBL(IDisponiblesDA disponibleDA)
        {
            this.disponibleDA = disponibleDA;
        }

        public async Task<List<Disponibles>> listarDisponibles()
        {
            return await disponibleDA.listarDisponibles();
        }

        public async Task<DisponiblesAgregar> insertarDisponibles(Disponibles disponibles)
        {
            return await disponibleDA.InsertarDisponible(disponibles);
        }

        public async Task<DisponiblesEditar> editarDisponibles(Disponibles disponibles)
        {
            return await disponibleDA.editarDisponible(disponibles);
        }

        public async Task<DisponibleDetalle> obtenerDisponibles(Disponibles disponibles)
        {
            return await disponibleDA.obtenerDisponible(disponibles);
        }
    }
}

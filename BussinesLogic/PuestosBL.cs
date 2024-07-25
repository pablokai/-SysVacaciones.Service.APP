using Model.Empleados;
using Model.Puestos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesDAL.Interface;
using SysVacacionesMODEL;

namespace SysVacacionesBL
{
    public class PuestosBL
    {
        private readonly IPuestosDA puestoDA;

        public PuestosBL(IPuestosDA puestosDA)
        {
            this.puestoDA = puestosDA;
        }

        public async Task<List<Puestos>> listarPuestos()
        {
            return await puestoDA.listarPuesto();
        }

        public async Task<PuestosAgregar> insertarPuestos(Puestos puestos)
        {
            return await puestoDA.insertarPuesto(puestos);
        }

        public async Task<PuestosEditar> editarPuestos(Puestos puestos)
        {
            return await puestoDA.editarPuesto(puestos);
        }

        public async Task<PuestosDetalle> obtenerPuestos(Puestos puestos)
        {
            return await puestoDA.obtenerPuesto(puestos);
        }
    }
}

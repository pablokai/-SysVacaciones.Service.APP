using Model.Puestos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysVacacionesMODEL;

namespace SysVacacionesDAL.Interface
{
    public interface IPuestosDA
    {
        Task<List<Puestos>> listarPuesto();

        Task<PuestosAgregar> insertarPuesto(Puestos puesto);
        Task<PuestosEditar> editarPuesto(Puestos puesto);
        Task<PuestosDetalle> obtenerPuesto(Puestos puesto);
    }
}

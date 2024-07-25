using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Vacaciones;
using SysVacacionesMODEL;

namespace SysVacacionesDAL.Interface
{
    public interface IVacacionesDA
    {
        Task<List<Vacaciones>> listarVacaciones();
        Task<VacacionesAgregar> insertarVacaciones(Vacaciones vacaciones);
        Task<VacacionesEditar> editarVacaciones(Vacaciones vacaciones);
        Task<VacacionesDetalle> obtenerVacaciones(Vacaciones vacaciones);
    }
}

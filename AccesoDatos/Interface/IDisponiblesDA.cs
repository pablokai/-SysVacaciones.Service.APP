using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DiasDisponibles;
using SysVacacionesMODEL;


namespace SysVacacionesDAL.Interface
{
    public interface IDisponiblesDA
    {
        Task<List<Disponibles>> listarDisponibles();

        Task<DisponiblesAgregar> InsertarDisponible(Disponibles disponible);
        Task<DisponiblesEditar>  editarDisponible(Disponibles disponible);
        Task<DisponibleDetalle> obtenerDisponible(Disponibles disponible);

    }
}

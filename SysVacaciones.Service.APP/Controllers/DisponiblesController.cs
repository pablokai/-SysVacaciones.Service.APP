using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DiasDisponibles;
using Model.Empleados;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesDAL;

namespace SysVacaciones.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponiblesController : ControllerBase
    {
        private readonly DisponiblesBL disponiblesBL;
        private readonly EmpleadosBL empleadosBL;

        public DisponiblesController(IDisponiblesDA disponiblesDA, EmpleadosDA empleadosDA)
        {
            disponiblesBL = new DisponiblesBL(disponiblesDA);
            empleadosBL = new EmpleadosBL(empleadosDA);
        }


    }
}

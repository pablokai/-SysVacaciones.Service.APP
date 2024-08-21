using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Empleados;
using Model.Vacaciones;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesDAL;

namespace SysVacaciones.Service.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacacionesController : ControllerBase
    {
        private readonly VacacionesBL vacacionesBL;

        public VacacionesController(IVacacionesDA vacacionesDA)
        {
            vacacionesBL = new VacacionesBL(vacacionesDA);
        }

        [HttpGet]
        [Route("ListarVacaciones")]
        public async Task<ActionResult> ListarVacaciones()
        {
            try
            {
                var empleados = await vacacionesBL.listarVacaciones();

                return StatusCode(200, empleados);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("SolicitarVacaciones")]
        public async Task<ActionResult> SolicitarVacaciones(VacacionesAgregar vacaciones)
        {
            try
            {
                DateTime fechaHoy = DateTime.Now;
                vacaciones.fechaSolicitud = fechaHoy;
                var respuesta = await vacacionesBL.insertarVacaciones(vacaciones);


                return StatusCode(200, respuesta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

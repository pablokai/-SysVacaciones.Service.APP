using Microsoft.AspNetCore.Mvc;
using Model.Puestos;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;

namespace SysVacaciones.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly PuestosBL puestosBL;

        public PuestosController(IPuestosDA puestosDA)
        {
            puestosBL = new PuestosBL(puestosDA);
        }
        [HttpGet]
        [Route("ListarPuestos")]
        public async Task<ActionResult> ListarPuestos()
        {
            try
            {
                var puestos = await puestosBL.listarPuestos();

                return StatusCode(200, puestos);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

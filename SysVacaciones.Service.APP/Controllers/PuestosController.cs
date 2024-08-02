using Microsoft.AspNetCore.Mvc;
using Model.Puestos;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;

namespace SysVacaciones.Service.Controllers
{
    public class PuestosController : Controller
    {
        private readonly PuestosBL puestosBL;

        public PuestosController(IPuestosDA puestosDA)
        {
            puestosBL = new PuestosBL(puestosDA);
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var puestos = await puestosBL.listarPuestos();
                if (puestos != null)
                {
                    return View(puestos);
                }
                else
                {
                    return View(new List<Puestos>());
                }
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        public async Task<ActionResult> Details()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PuestosAgregar puestos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(puestos);
                }
                Puestos nuevoPuesto = new Puestos()
                {
                    nombrePuesto = puestos.nombrePuesto
                };

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajePorceso = "Se creo el nuevo puesto";

                return View(puestos);

            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajePorceso = "No se pudo crear el nuevo puesto " + ex;
                return View(puestos);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                PuestosEditar puestos = new PuestosEditar();
                Puestos nuevoPuesto = new Puestos()
                {
                    puestoID = id,
                };
                var respuesta = await puestosBL.obtenerPuestos(nuevoPuesto);
                return View(puestos);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PuestosEditar puestos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(puestos);
                }
                Puestos nuevoPuesto = new Puestos()
                {
                    puestoID = puestos.puestoID,
                    nombrePuesto = puestos.nombrePuesto
                };
                var respuesta = await puestosBL.editarPuestos(nuevoPuesto);

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Puesto acualizado satisfactoriamente";

                return View(puestos);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajeProceso = "Error al editar el puesto" + ex.Message;
                return View(puestos);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DiasDisponibles;
using Model.Empleados;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesDAL;

namespace SysVacaciones.Service.Controllers
{
    public class DisponiblesController : Controller
    {
        private readonly DisponiblesBL disponiblesBL;
        private readonly EmpleadosBL empleadosBL;

        public DisponiblesController(IDisponiblesDA disponiblesDA, EmpleadosDA empleadosDA)
        {
            disponiblesBL = new DisponiblesBL(disponiblesDA);
            empleadosBL = new EmpleadosBL(empleadosDA);
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var disponibles = await disponiblesBL.listarDisponibles();
                if (disponibles != null)
                {
                    return View(disponibles);
                }
                else
                {
                    return View(new List<Disponibles>());
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
            ViewBag.empleados = await obtenerEmpleados();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DisponiblesAgregar disponibles)
        {
            try
            {
                ViewBag.empleados = await obtenerEmpleados();
                if (!ModelState.IsValid)
                {
                    return View(disponibles);
                }
                Disponibles nuevoDisponible = new Disponibles()
                {
                    empleadoId = disponibles.Id,
                    disponiblesID = disponibles.diasDisponibles
                };

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajePorceso = "Se agregaron los días disponibles";

                return View(disponibles);

            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajePorceso = "No se pudieron agregar días disponibles " + ex;
                return View(disponibles);
            }
        }

        public async Task<List<SelectListItem>> obtenerEmpleados()
        {
            List<Empleados> respuesta = await empleadosBL.listarEmpleados();

            if (respuesta != null)
            {
                List<SelectListItem> dropdown = respuesta.Select(x => new SelectListItem
                {
                    Text = x.cedula,
                    Value = x.Id.ToString(),
                }).ToList();

                return dropdown;
            }

            return new List<SelectListItem>();
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ViewBag.empleados = await obtenerEmpleados();
                DisponiblesEditar disponibles = new DisponiblesEditar();
                Disponibles nuevoDisponible = new Disponibles()
                {
                    disponiblesID = id,
                };
                var respuesta = await disponiblesBL.obtenerDisponibles(nuevoDisponible);
                return View(disponibles);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DisponiblesEditar disponibles)
        {
            try
            {
                ViewBag.empleados = await obtenerEmpleados();

                if (!ModelState.IsValid)
                {
                    return View(disponibles);
                }
                Disponibles nuevoDisponible = new Disponibles()
                {
                    disponiblesID = disponibles.disponiblesID,
                    empleadoId = disponibles.empleadoId,
                    diasDisponibles = disponibles.diasDisponibles
                };
                var respuesta = await disponiblesBL.editarDisponibles(nuevoDisponible);

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Días disponibles acualizados satisfactoriamente";

                return View(disponibles);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajeProceso = "Error al editar los días disponibles" + ex.Message;
                return View(disponibles);
            }
        }
    }
}

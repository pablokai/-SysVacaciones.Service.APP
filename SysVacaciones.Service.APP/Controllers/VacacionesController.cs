using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Empleados;
using Model.Vacaciones;
using SysVacacionesBL;
using SysVacacionesDAL.Interface;
using SysVacacionesDAL;

namespace SysVacaciones.Service.APP.Controllers
{
    public class VacacionesController : Controller
    {
        private readonly VacacionesBL vacacionesBL;
        private readonly EmpleadosBL empleadosBL;

        public VacacionesController(IVacacionesDA vacacionesDA, EmpleadosDA empleadosDA)
        {
            vacacionesBL = new VacacionesBL(vacacionesDA);
            empleadosBL = new EmpleadosBL(empleadosDA);
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var vacaciones = await vacacionesBL.listarVacaciones();
                if (vacaciones != null)
                {
                    return View(vacaciones);
                }
                else
                {
                    return View(new List<Vacaciones>());
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
        public async Task<ActionResult> Create(VacacionesAgregar vacaciones)
        {
            try
            {
                ViewBag.empleados = await obtenerEmpleados();
                if (!ModelState.IsValid)
                {
                    return View(vacaciones);
                }
                Vacaciones nuevaVacacion = new Vacaciones()
                {
                    empleadoID = vacaciones.empleadoID,
                    fechaSolicitud = vacaciones.fechaSolicitud,
                    diasSolicitados = vacaciones.diasSolicitados,
                    fechaSalida = vacaciones.fechaSalida,
                    fechaEntrada = vacaciones.fechaEntrada
                };

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajePorceso = "Se creo la solicitud de vacaciones";

                return View(vacaciones);

            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajePorceso = "No se pudo crear la solicitud de vacaciones " + ex;
                return View(vacaciones);
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
                VacacionesEditar vacaciones = new VacacionesEditar();
                Vacaciones nuevaVacacion = new Vacaciones()
                {
                    ID = id,
                };
                var respuesta = await vacacionesBL.obtenerVacaciones(nuevaVacacion);
                return View(vacaciones);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(VacacionesEditar vacaciones)
        {
            try
            {
                ViewBag.empleados = await obtenerEmpleados();

                if (!ModelState.IsValid)
                {
                    return View(vacaciones);
                }
                Vacaciones nuevaVacacion = new Vacaciones()
                {
                    ID = vacaciones.ID,
                    empleadoID = vacaciones.empleadoID,
                    fechaSolicitud = vacaciones.fechaSolicitud,
                    diasSolicitados = vacaciones.diasSolicitados,
                    fechaSalida = vacaciones.fechaSalida,
                    fechaEntrada = vacaciones.fechaEntrada,
                };
                var respuesta = await vacacionesBL.editarVacaciones(nuevaVacacion);

                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Vacaciones acualizadas satisfactoriamente";

                return View(vacaciones);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 1;
                ViewBag.MensajeProceso = "Error al editar la solicitud de vacaciones" + ex.Message;
                return View(vacaciones);
            }
        }
    }
}
